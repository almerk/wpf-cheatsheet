using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudyWPF.ViewModels;

namespace StudyWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ViewModels.Application ViewModel { get; }

        public bool CanHandleExceptions { get { return ViewModel?.CanHandleExceptions ?? false; } }

        public void HandleExcepion(Exception ex) 
        {
            ViewModel.HandleException(ex);
        }

        public MainWindow(ViewModels.Application application)
        {
            this.ViewModel = application;
            InitializeComponent();
        }
    }
}
