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
            var mainWindow = container.Get<MainWindow>();
            application.Run(mainWindow);
        }

        private static void ConfigureContainer(IKernel kernel) 
        { 

        }
    }
}
