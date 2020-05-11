using BLL_Kvest.Infostructure;
using BLL_Kvest.Interfaces;
using BLL_Kvest.Services;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using System;
using System.Web.Mvc;
using System.Windows.Forms;
using UI_Kvest.Util;

namespace UI_Kvest
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());

            NinjectModule kvestModule = new KvestRoomModule();
            NinjectModule serviceModule = new ServiceModule("DbConnection");

            var kerneltwo = new StandardKernel(kvestModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kerneltwo));

            NinjectModule statusModule = new StatusModule();
            NinjectModule serviceTwoModule = new ServiceModule("DbConnection");

            var kernel = new StandardKernel(statusModule, serviceTwoModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
