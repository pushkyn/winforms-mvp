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

            var container = new IoCContainer();
            container.Register<ICustomerRepository, CustomerXmlRepository>();
            container.Register<ICustomerView, CustomerForm>();

            var view = container.Resolve<ICustomerView>();
            var presenter = new CustomerPresenter(view, container.Resolve<ICustomerRepository>());
            Application.Run((Form) view);
        }
    }
}
