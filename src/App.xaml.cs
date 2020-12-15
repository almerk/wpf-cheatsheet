using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudyWPF
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class App : Application
    {
        private static MainWindow _mainWindow;

        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [System.STAThread]
        [System.Diagnostics.DebuggerNonUserCode]
        public static void Main()
        {
            IKernel container = new StandardKernel();//Container of dependencies
            ConfigureContainer(container);
            
            var application = new App();
            application.DispatcherUnhandledException += Application_DispatcherUnhandledException;
            _mainWindow = container.Get<MainWindow>();
            application.Run(_mainWindow);
        }

        private static void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (_mainWindow.CanHandleExceptions)
            {
                _mainWindow.HandleExcepion(e.Exception);
                e.Handled = true;
            }
            else 
            {
                Console.WriteLine(e.Exception.Message);
            }
            
        }

        private static void ConfigureContainer(IKernel kernel) 
        { 

        }
    }
}
