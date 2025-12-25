using System;
using System.Windows.Forms;

namespace SVA_SParam_Tool
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var tcp = new TCPService();
            Application.Run(new MainWindow(tcp));
        }
    }
}
