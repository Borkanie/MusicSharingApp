﻿using FoodMeasuringAPI;
using FoodStandUI.ViewModel.Components;

namespace FoodStandUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            FoodMap = new FoodMapViewModel();
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }


        internal FoodMapViewModel FoodMap
        {
            get;
            set;
        }
    }

}
