using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace SVA_SParam_Tool
{
    public partial class MainWindow : Form
    {

        private readonly TCPService _tcp;
        private Boolean s11_measure = false;
        private double[] freqs;
        private Complex[] trace_s11, trace_s21;


        public MainWindow(TCPService tcp)
        {
            InitializeComponent();
            _tcp = tcp;

            // Register TCP Event Handlers
            _tcp.ConnectionChanged += Tcp_ConnectionChanged;
            _tcp.Error += Tcp_Error;

            // Register UI Event Handler
            btn_tcp_connect.Click += Btn_tcp_connect_Click;
            btn_tcp_refresh.Click += Btn_tcp_refresh_Click;
            btn_mode_vna.Click += Btn_mode_vna_Click;
            btn_plot_smith.Click += Btn_plot_smith_Click;
            btn_measure_s11.Click += Btn_measure_s11_Click;
            btn_measure_s21.Click += Btn_measure_s21_Click;
            btn_load_data.Click += Btn_load_data_Click;
            btn_save_s1p.Click += Btn_save_s1p_Click;
            btn_save_s2p.Click += Btn_save_s2p_Click;

            //Init UI Elements
            UpdateUiConnected(false);

            //Initial Plot of Smith Scale
            var smith_s11 = smith_plot_s11.Plot.Add.SmithChartAxis();
            var smith_s21 = smith_plot_s21.Plot.Add.SmithChartAxis();

        }

        private async void Btn_tcp_connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_tcp.IsConnected)
                {
                    string ip = edit_tcp_ip.Text.Trim();

                    if (!int.TryParse(edit_tcp_port.Text.Trim(), out int port) || port < 1 || port > 65535)
                    {
                        MessageBox.Show("Port invalid (1-65535).");
                        return;
                    }

                    btn_tcp_connect.Enabled = false;
                    await _tcp.ConnectAsync(ip, port); //Open TCP Connection
                }
                else
                {
                    _tcp.Disconnect(); // Close TCP Connection
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection faild: {ex.Message}");
            }
            finally
            {
                btn_tcp_connect.Enabled = true;
            }
        }

        private async void Btn_tcp_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                btn_tcp_refresh.Enabled = false;
                _ = QueryInstrumentStateAsync(); // Refresh Instrument State
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Refresh failed: {ex.Message}");
            }
            finally
            {
                btn_tcp_refresh.Enabled = true;
            }
        }


        private async void Btn_mode_vna_Click(object sender, EventArgs e)
        {
            try
            {
                btn_mode_vna.Enabled = false;
                // Set Instrument Mode to VNA
                await _tcp.SendCommandAsync(":INSTrument:SELect VNA\n", expectResponse: false);
                _ = QueryInstrumentStateAsync(); // Refresh Instrument State

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Set VNA-Mode failed: {ex.Message}");
            }
            finally
            {
                btn_mode_vna.Enabled = true;
            }
        }


        private async void Btn_plot_smith_Click(object sender, EventArgs e)
        {
            try
            {
                btn_plot_smith.Enabled = false;
                // Switch to Smith Plot
                await _tcp.SendCommandAsync(":CALCulate1:SELected:FORMat SMIT\n", expectResponse: false);
                _ = QueryInstrumentStateAsync(); // Refresh Instrument State

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Set Smith Plot failed: {ex.Message}");
            }
            finally
            {
                btn_plot_smith.Enabled = true;
            }
        }

        private async void Btn_measure_s11_Click(object sender, EventArgs e)
        {
            try
            {
                btn_measure_s11.Enabled = false;
                // Set S11 Measure
                await _tcp.SendCommandAsync(":CALCulate1:PARameter1:DEFine S11\n", expectResponse: false);
                _ = QueryInstrumentStateAsync(); // Refresh Instrument State

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Set S11-Measure failed: {ex.Message}");
            }
            finally
            {
                btn_measure_s11.Enabled = true;
            }
        }

        private async void Btn_measure_s21_Click(object sender, EventArgs e)
        {
            try
            {
                btn_measure_s21.Enabled = false;
                // Set S21 Measure
                await _tcp.SendCommandAsync(":CALCulate1:PARameter1:DEFine S21\n", expectResponse: false);
                _ = QueryInstrumentStateAsync(); // Refresh Instrument State

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Set S21-Measure failed: {ex.Message}");
            }
            finally
            {
                btn_measure_s21.Enabled = true;
            }
        }

        private async void Btn_load_data_Click(object sender, EventArgs e)
        {
            try
            {
                btn_load_data.Enabled = false;
                // Get Trace Data
                string response = await _tcp.SendCommandAsync(":TRACe:DATA? 1\n", expectResponse: true);

                if (s11_measure)
                {
                    trace_s11 = ParseComplexTrace(response ?? "");
                    PlotOnSmith(trace_s11, smith_plot_s11);
                    btn_save_s1p.Enabled = true;
                }
                else
                {
                    trace_s21 = ParseComplexTrace(response ?? "");
                    PlotOnSmith(trace_s21, smith_plot_s21);
                    btn_save_s2p.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Get Trace Data failed: {ex.Message}");
            }
            finally
            {
                btn_load_data.Enabled = true;
            }
        }

        private async void Btn_save_s1p_Click(object sender, EventArgs e)
        {
            try
            {
                btn_save_s1p.Enabled = false;

                //Open Save Dialog
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Touchstone S1P File (*.s1p)|*.s1p|All Files (*.*)|*.*";
                    saveDialog.Title = "Save S11 Touchstone File";
                    saveDialog.DefaultExt = "s1p";
                    saveDialog.AddExtension = true;
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveDialog.FileName;
                        TouchstoneWriter.WriteS1P(filePath, freqs, trace_s11);
                        //MessageBox.Show($"Saved S11 File in: {filePath}");
                    }
                }


            }
            catch (Exception ex)
            {
                // Bei Fehlern: beide eher "nicht OK" anzeigen
                MessageBox.Show($"Save S1P-File failed: {ex.Message}");
            }
            finally
            {
                btn_save_s1p.Enabled = true;
            }
        }

        private async void Btn_save_s2p_Click(object sender, EventArgs e)
        {
            try
            {
                btn_save_s2p.Enabled = false;

                //Open Save Dialog
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Touchstone S1P File (*.s2p)|*.s2p|All Files (*.*)|*.*";
                    saveDialog.Title = "Save S2P Touchstone File";
                    saveDialog.DefaultExt = "s2p";
                    saveDialog.AddExtension = true;
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveDialog.FileName;
                        TouchstoneWriter.WriteS2P(filePath, freqs, trace_s21, trace_s11);
                        //MessageBox.Show($"Saved S21 File in: {filePath}");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save S2P-File failed: {ex.Message}");
            }
            finally
            {
                btn_save_s2p.Enabled = true;
            }
        }

        private async Task QueryInstrumentStateAsync()
        {
            try
            {
                // 1) Get Instrument Mode
                string mode =
                    (await _tcp.SendCommandAsync(":INSTrument:SELect?\n", expectResponse: true))
                    ?.Trim() ?? "";

                Debug.WriteLine($"Mode = '{mode}'");

                bool isVna = mode.Equals("VNA", StringComparison.OrdinalIgnoreCase);
                SetButtonColor(btn_mode_vna, isVna ? Color.LightGreen : Color.IndianRed);

                //Enable Smith Button if VNA Mode
                btn_plot_smith.Enabled = isVna;

                if (!isVna)
                {
                    SetButtonColor(btn_plot_smith, SystemColors.Control);
                    return;
                }

                // 2) If VNA Mode: Get Plot-Format and Sweep Data
                string format =
                    (await _tcp.SendCommandAsync(":CALCulate1:SELected:FORMat?\n", expectResponse: true))
                    ?.Trim() ?? "";

                string start_freq =
                    (await _tcp.SendCommandAsync(":FREQuency:STARt?\n", expectResponse: true))
                    ?.Trim() ?? "";

                string stop_freq =
                    (await _tcp.SendCommandAsync(":FREQuency:STOP?\n", expectResponse: true))
                    ?.Trim() ?? "";

                string sweep_points =
                    (await _tcp.SendCommandAsync(":SWEep:POINts?\n", expectResponse: true))
                    ?.Trim() ?? "";

                Debug.WriteLine($"Format = '{format}'");
                Debug.WriteLine($"Start Freq = '{start_freq}'");
                Debug.WriteLine($"Stop Freq = '{stop_freq}'");

                bool isSmith = format.Equals("SMIT", StringComparison.OrdinalIgnoreCase);
                SetButtonColor(btn_plot_smith, isSmith ? Color.LightGreen : Color.IndianRed);


                freqs = BuildFrequencyArray(start_freq, stop_freq, sweep_points);
                text_start_freq.Text = freqs.Min().ToString();
                text_stop_freq.Text = freqs.Max().ToString();
                text_sweep_points.Text = freqs.Length.ToString();

                

                btn_measure_s11.Enabled = isSmith;
                btn_measure_s21.Enabled = isSmith;
                btn_load_data.Enabled = isSmith;


                if (!isSmith)
                {
                    SetButtonColor(btn_measure_s11, SystemColors.Control);
                    SetButtonColor(btn_measure_s21, SystemColors.Control);
                    return;
                }

                // 3) If is Smith-Plot: Get Measure (S11/S21)
                string measure =
                    (await _tcp.SendCommandAsync(":CALCulate1:PARameter1:DEFine?\n", expectResponse: true))
                    ?.Trim() ?? "";

                Debug.WriteLine($"Measure = '{measure}'");

                bool isS11 = measure.Equals("S11", StringComparison.OrdinalIgnoreCase);
                bool isS21 = measure.Equals("S21", StringComparison.OrdinalIgnoreCase);
                SetButtonColor(btn_measure_s11, isS11 ? Color.LightGreen : SystemColors.Control);
                SetButtonColor(btn_measure_s21, isS21 ? Color.LightGreen : SystemColors.Control);

                s11_measure = isS11;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"State query failed: {ex.Message}");

                SetButtonColor(btn_mode_vna, SystemColors.Control);
                SetButtonColor(btn_plot_smith, SystemColors.Control);
                SetButtonColor(btn_measure_s11, SystemColors.Control);
                SetButtonColor(btn_measure_s21, SystemColors.Control);
            }
        }

        public static double[] BuildFrequencyArray(string start_freq, string stop_freq, string sweep_points)
        {
            var ci = CultureInfo.InvariantCulture;

            double start = double.Parse(start_freq, ci);
            double stop = double.Parse(stop_freq, ci);
            int points = int.Parse(sweep_points, ci);

            if (points < 2)
                throw new ArgumentException("Sweep points must be >= 2.");

            double[] freqs = new double[points];

            double step = (stop - start) / (points - 1);

            for (int i = 0; i < points; i++)
            {
                freqs[i] = start + i * step;
            }

            return freqs;
        }

        public static Complex[] ParseComplexTrace(string response)
        {
            if (string.IsNullOrWhiteSpace(response))
                throw new ArgumentException("Response is empty.");

            // Remove Control Characters
            response = response.Trim();

            // Split Response
            string[] parts = response.Split(
                new[] { ',', '\t' },
                StringSplitOptions.RemoveEmptyEntries
            );

            if (parts.Length % 2 != 0)
                throw new FormatException("Uneven number of Values?! – No Real/Imag pair.");

            var ci = CultureInfo.InvariantCulture;

            int complexCount = parts.Length / 2;
            Complex[] result = new Complex[complexCount];

            for (int i = 0; i < complexCount; i++)
            {
                double real = double.Parse(parts[2 * i], ci);
                double imag = double.Parse(parts[2 * i + 1], ci);

                result[i] = new Complex(real, imag);
            }

            return result;
        }


        public void PlotOnSmith(Complex[] trace, FormsPlot plot_form)
        {
            ScottPlot.Plottables.SmithChartAxis smithAxis;
            ScottPlot.Plottables.Scatter traceScatter;

            var plt = plot_form.Plot;

            plt.Clear();

            // 1) Redraw Smith Chart Axis
            smithAxis = plt.Add.SmithChartAxis();

            // 2) Map Complex Data to Smith Chart Coordinates
            Coordinates[] coords = new Coordinates[trace.Length];

            for (int i = 0; i < trace.Length; i++)
            {
                Complex g = trace[i];

                Complex z = (1 + g) / (1 - g); // Normalize Impedance
                double r = z.Real;
                double x = z.Imaginary;

                coords[i] = smithAxis.GetCoordinates(r, x);
            }

            // 3) Plot Scatter Line
            traceScatter = plt.Add.ScatterLine(coords);
            traceScatter.LineWidth = 3;
            traceScatter.Color = ScottPlot.Colors.Red;

            plot_form.Refresh();
        }

        private void SetButtonColor(Button button, Color color)
        {
            if (button.InvokeRequired)
            {
                button.BeginInvoke(new Action(() => SetButtonColor(button, color)));
                return;
            }

            button.UseVisualStyleBackColor = false;
            button.BackColor = color;
        }


        private void Tcp_ConnectionChanged(object sender, bool connected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateUiConnected(connected)));
                return;
            }

            UpdateUiConnected(connected);
        }

        private void Tcp_Error(object sender, Exception ex)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => MessageBox.Show($"TCP Fehler: {ex.Message}")));
                return;
            }
            MessageBox.Show($"TCP Fehler: {ex.Message}");
        }

        private void UpdateUiConnected(bool connected)
        {
            btn_tcp_connect.Text = connected ? "Disconnect" : "Connect";

            edit_tcp_ip.Enabled = !connected;
            edit_tcp_port.Enabled = !connected;

            btn_tcp_refresh.Enabled = connected;
            btn_mode_vna.Enabled = connected;


            if (connected)
            {
                // Get Instrument State after Connect
                _ = QueryInstrumentStateAsync();
            }
            else
            {
                // Reset UI after Disconnect
                SetButtonColor(btn_mode_vna, SystemColors.Control);
                SetButtonColor(btn_plot_smith, SystemColors.Control);
                SetButtonColor(btn_measure_s11, SystemColors.Control);
                SetButtonColor(btn_measure_s21, SystemColors.Control);

                btn_plot_smith.Enabled = false;
                btn_measure_s11.Enabled = false;
                btn_measure_s21.Enabled = false;
                btn_save_s1p.Enabled = false;
                btn_save_s2p.Enabled = false;
                btn_load_data.Enabled = false;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _tcp.Dispose();
            base.OnFormClosing(e);
        }
    }
}
