using AppliedProject4thYear.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace AppliedProject4thYear
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //btnAttention.Visibility = Visibility.Collapsed;
            //btnProblemSolving.Visibility = Visibility.Collapsed;
            //btnSpeed.Visibility = Visibility.Collapsed;
            //btnMemory.Visibility = Visibility.Collapsed;

            /*if (btnAttention.Visibility == Visibility.Collapsed && btnProblemSolving.Visibility == Visibility.Collapsed 
            && btnSpeed.Visibility == Visibility.Collapsed && btnMemory.Visibility == Visibility.Collapsed)
            {
                btnLogin.Visibility = Visibility.Visible;
            }*/
        }//- End of MainPage()

        private void btnAttention_Click(object sender, RoutedEventArgs e)
        {
            //Nav Destinations not working.
            //Frame.Navigate(typeof(AttentionLevel1));
        }//- End of btnAttention_Click

        private void btnProblemSolving_Click(object sender, RoutedEventArgs e)
        {
            //Nav Destinations not working.
            //this.Frame.Navigate(typeof(ProblemSolvingGames), null);
        }//- End of btnProblemSolving_Click

        private void btnSpeed_Click(object sender, RoutedEventArgs e)
        {
            //Nav Destinations not working.
            //Frame.Navigate(typeof(EverythingHasAPorpoise));
        }//- End of btnSpeed_Click

        private void btnMemory_Click(object sender, RoutedEventArgs e)
        {
            //Nav Destinations not working.
            Frame.Navigate(typeof(ShoppingList));
        }//- End of btnMemory_Click

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

        }//- End of btnOk_Click

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }//- End of btnCancel_Click
    }//- End of MainPage
}//- End of AppliedProject4thYear
