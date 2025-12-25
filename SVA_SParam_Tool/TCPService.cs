#nullable enable

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVA_SParam_Tool
{
    public class TCPService : IDisposable
    {
        private TcpClient? _client;
        private CancellationTokenSource? _cts;

        public bool IsConnected => _client?.Connected == true;

        public event EventHandler<bool>? ConnectionChanged; // true=connected, false=disconnected
        public event EventHandler<Exception>? Error;

        public async Task ConnectAsync(string ip, int port)
        {
            if (IsConnected) return;

            _client = new TcpClient();
            _cts = new CancellationTokenSource();

            try
            {
                await _client.ConnectAsync(ip, port);

                ConnectionChanged?.Invoke(this, true);

                // Background-Loop to monitor connection
                _ = Task.Run(async () =>
                {
                    try
                    {
                        while (!_cts!.IsCancellationRequested && _client!.Connected)
                        {
                            await Task.Delay(500, _cts.Token);
                        }
                    }
                    catch { /* ignore */ }
                    finally
                    {
                        // If timeout reached -> disconnected
                        if (!IsConnected)
                            ConnectionChanged?.Invoke(this, false);
                    }
                });
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, ex);
                Disconnect();
                throw;
            }
        }

        public async Task<string?> SendCommandAsync(string command, bool expectResponse)
        {
            if (_client == null || !_client.Connected)
                throw new InvalidOperationException("TCP nicht verbunden.");

            NetworkStream stream = _client.GetStream();

            // --- SEND ---
            byte[] tx = Encoding.ASCII.GetBytes(command);
            await stream.WriteAsync(tx, 0, tx.Length);
            await stream.FlushAsync();

            Debug.WriteLine($"TX: {command.Trim()}");

            if (!expectResponse)
                return null;

            // --- RECEIVE (till \n) ---
            var buffer = new byte[1];
            var sb = new StringBuilder();

            while (true)
            {
                int read = await stream.ReadAsync(buffer, 0, 1);
                if (read == 0)
                    throw new IOException("Verbindung getrennt.");

                char c = (char)buffer[0];
                sb.Append(c);

                if (c == '\n')
                    break;
            }

            string response = sb.ToString();
            Debug.WriteLine($"RX: {response.Trim()}");

            return response;
        }

        public void Disconnect()
        {
            try { _cts?.Cancel(); } catch { /* ignore */ }

            try { _client?.Close(); } catch { /* ignore */ }
            try { _client?.Dispose(); } catch { /* ignore */ }

            _client = null;
            _cts?.Dispose();
            _cts = null;

            ConnectionChanged?.Invoke(this, false);
        }

        public void Dispose() => Disconnect();
    }

}
