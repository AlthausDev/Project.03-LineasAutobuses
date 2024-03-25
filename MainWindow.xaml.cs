﻿using Project._04_LineasAutobuses.Features.Linea;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;
using Project._04_LineasAutobuses.ViewModel;
using Project._04_LineasAutobuses.Views;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project._04_LineasAutobuses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeMainWindow();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void InitializeMainWindow()
        {
            try
            {
                DataContext = new MainWindowViewModel();
                MainFrame.Navigate(new InicioView());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la ventana principal: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close(); 
            }
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BarraControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 8);          
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}