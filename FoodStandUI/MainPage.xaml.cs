﻿using CommunityToolkit.Mvvm.Messaging;
using FoodMeasuringAPI;
using FoodStandUI.Resources;
using FoodStandUI.Resources.Messages;
using FoodStandUI.View.Dialog;
using FoodStandUI.ViewModel.Components;

namespace FoodStandUI
{
    public partial class MainPage : ContentPage
    {
        MainWindowViewModel VM;
        public MainPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            SizeChanged += MainPage_SizeChanged;
            WeakReferenceMessenger.Default.Register<MainPage, ContainerViewModelMessage>(this, static (r, msg) => r.ReadMessageFromContainerVM(msg));
            WeakReferenceMessenger.Default.Register<MainPage, ContainerSettingsViewMessage>(this, static (r, msg) => r.ReadMessageFromContainerSettingsView(msg));
            //WeakReferenceMessenger.Default.Register<ContainerViewModel>(this, MessageType.ContainerSettingsButtonClicked.Value, x => CreateContainerSettingsView(x));
        }

        private void ReadMessageFromContainerSettingsView(ContainerSettingsViewMessage message)
        {
            switch (message.Type)
            {
                case ContainerSettingsViewMessage.Action.CancelSettings:
                    Overlay.IsVisible = false;
                    break;
                default:
                    break;
            }
        }

        private void ReadMessageFromContainerVM(ContainerViewModelMessage message)
        {
            switch (message.Type)
            {
                case ContainerViewModelMessage.Action.OpenSettings:
                    ContainerSettingsView.BindingContext = message.ViewModel;
                    Overlay.IsVisible = true;
                    break;
                default:
                    break;
            }
        }

        private void MainPage_SizeChanged(object? sender, EventArgs e)
        {
            if(Width != -1 && Height != -1 && VM is not null)
            {
                VM.Heigth = Height;
                VM.Width = Width;
            }
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            VM = new MainWindowViewModel();
            VM.Width = Width;
            VM.Heigth = Height;
            BindingContext = VM;
        }
    }

}
