using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Aaron.WP7.ViewModels;
using Microsoft.Phone.Controls;
using UpdateControls.XAML;

namespace Aaron.WP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.FlipForward += ViewModel_FlipForward;
        }

        private void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModel.FlipForward -= ViewModel_FlipForward;
        }

        private void ViewModel_FlipForward(object sender, EventArgs e)
        {
            ((Storyboard)Resources["FlipForward"]).Begin();
        }

        private void FlipBackward_Completed(object sender, EventArgs e)
        {
            ViewModel.RaiseFlipBackward();
        }

        private BoardViewModel ViewModel
        {
            get { return ForView.Unwrap<BoardViewModel>(DataContext); }
        }
    }
}