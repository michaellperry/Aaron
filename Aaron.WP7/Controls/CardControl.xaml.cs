using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Aaron.WP7.ViewModels;
using UpdateControls.XAML;

namespace Aaron.WP7.Controls
{
    public partial class CardControl : UserControl
    {
        public CardControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Selected += ViewModel_Selected;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Selected -= ViewModel_Selected;
        }

        private void ViewModel_Selected(object sender, EventArgs e)
        {
            ((Storyboard)Resources["FlipForward"]).Begin();
        }

        private void FlipForward_Completed(object sender, EventArgs e)
        {
            ViewModel.FlipBackward += ViewModel_FlipBackward;
            ViewModel.RaiseFlipForward();
        }

        private void ViewModel_FlipBackward(object sender, EventArgs e)
        {
            ViewModel.FlipBackward -= ViewModel_FlipBackward;
            ((Storyboard)Resources["FlipBackward"]).Begin();
        }

        private CardViewModel ViewModel
        {
            get { return ForView.Unwrap<CardViewModel>(DataContext); }
        }
    }
}
