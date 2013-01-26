using System;
using System.Windows.Forms;
using WinformsMVP.Model;
using WinformsMVP.Presenter;
using WinformsMVP.View;

namespace WinformsMVP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new CustomerForm();
            var presenter = new CustomerPresenter(view, new CustomerXmlRepository());
            Application.Run(view);
        }
    }
}
