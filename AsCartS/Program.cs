using System;
using System.Windows.Forms;

namespace AsCartS
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataBase.CriarDiretório();
            Application.Run(new Form1());
        }
    }
}
