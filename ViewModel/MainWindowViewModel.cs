﻿using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Features.Itinerario;
using Project._04_LineasAutobuses.Features.Linea;
using Project._04_LineasAutobuses.ViewModel.Forms;
using Project._04_LineasAutobuses.Views;
using Project._04_LineasAutobuses.Views.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ItinerarioViewModel _itinerarioViewModel = new ItinerarioViewModel();
        private readonly ParadasViewModel _paradasViewModel = new ParadasViewModel();

        public event PropertyChangedEventHandler? PropertyChanged;

        private static readonly Lazy<MainWindowViewModel> instance = new Lazy<MainWindowViewModel>(() => new MainWindowViewModel());
        public static long NumeroLineaSeleccionada { get; set; }

        public static MainWindowViewModel Instance => instance.Value;

        public ICommand NavigateToLineasCommand =>
            new RelayCommand(() => NavigateToLineas());

        public ICommand NavigateToItinerarioCommand =>
            new RelayCommand(() => NavigateTo(new ItinerarioView(_itinerarioViewModel, NumeroLineaSeleccionada)));

        public ICommand NavigateToParadasCommand =>
            new RelayCommand(() => NavigateTo(new ParadasView(_paradasViewModel, NumeroLineaSeleccionada)));

        public ICommand NavigateToInicioCommand =>
            new RelayCommand(() => NavigateTo(new InicioView()));

        public ICommand NavigateToAboutCommand =>
            new RelayCommand(() => NavigateTo(new AboutView()));

        public ICommand NavigateToNewLineFormCommand =>
            new RelayCommand(() => NavigateTo(new NewLineForm()));

        private void NavigateToLineas()
        {
            var lineaViewModel = new LineaViewModel();
            lineaViewModel.LoadLineas();
            NavigateTo(new LineasView(lineaViewModel));
        }

        private void NavigateTo(Page page)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainFrame.Navigate(page);
            }
        }
    }
}
