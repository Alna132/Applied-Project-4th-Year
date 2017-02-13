using AppliedProject4thYear;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _4thYearAppliedProject.Memory
{
    public sealed partial class Sequential : Page
    {
        public Sequential()
        {
            this.InitializeComponent();
            //- Add a colour to the list.
            pattern.Add(rand.Next(0, 4));

        }//- End of Sequential()

        int onInList = 0;
        List<int> pattern = new List<int>();
        Random rand = new Random();
        bool playingBack = false;

        private void BackAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MemoryNav));
        }//- End of BackAppBarBtn_Click

        private void MainMenuAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }//- End of MainMenuAppBarBtn_Click

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.Content = "";
            txtBlkRoundNum.Text = ("0");
            playback();
            //new Task(playback).Start();
        }//- End of btnStart_Click

        private void redRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            storyboardRedRectanglePlayer.Begin();
            testCorrect(0);
        }//- End of redRectangle_Tapped

        private void blueRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            storyboardBlueRectanglePlayer.Begin();
            testCorrect(1);
        }//- End of blueRectangle_Tapped

        private void yellowRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            storyboardYellowRectanglePlayer.Begin();
            testCorrect(2);
        }//- End of yellowRectangle_Tapped

        private void greenRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            storyboardGreenRectanglePlayer.Begin();
            testCorrect(3);
        }//- End of greenRectangle_Tapped

        private void storyboardRedRectangle_Completed(object sender, object e)
        {

        }//- End of storyboardRedRectangle_Completed

        private void storyboardBlueRectangle_Completed(object sender, object e)
        {

        }//- End of storyboardBlueRectangle_Completed

        private void storyboardYellowRectangle_Completed(object sender, object e)
        {

        }//- End of storyboardYellowRectangle_Completed

        private void storyboardGreenRectangle_Completed(object sender, object e)
        {

        }//- End of storyboardGreenRectangle_Completed

        private async void testCorrect(int Colour)
        {
            if (playingBack)
                return;

            if (pattern[onInList] == Colour)
                onInList++;
            else
            {
                var dialog = new MessageDialog("Wrong Colour! Game Over. Final Score: " + pattern.Count.ToString());
                await dialog.ShowAsync();
                onInList = 0;
                pattern = new List<int>();
                btnStart.Content = "Click to Start!";
                txtBlkRoundNum.Text = ("");
            }//- End of if/else

            if (onInList >= pattern.Count)
            {
                pattern.Add(rand.Next(0, 4));
                onInList = 0;
                playback();
            }//- End of if

            txtBlkRoundNum.Text = (pattern.Count.ToString());
        }//- End of testCorrect()

        private async void playback()
        {
            playingBack = true;
            foreach (int colour in pattern)
            {
                switch (colour)
                {
                    case 0:
                        storyboardRedRectangle.Begin();
                        //redRectangle.Opacity = 0;
                        await Task.Delay(200);
                        //redRectangle.Opacity = 100;
                        break;
                    case 1:
                        storyboardBlueRectangle.Begin();
                        //blueRectangle.Opacity = 0;
                        await Task.Delay(200);
                        //blueRectangle.Opacity = 100;
                        break;
                    case 2:
                        storyboardYellowRectangle.Begin();
                        //yellowRectangle.Opacity = 0;
                        await Task.Delay(200);
                        //yellowRectangle.Opacity = 100;
                        break;
                    case 3:
                        storyboardGreenRectangle.Begin();
                        //greenRectangle.Opacity = 0;
                        await Task.Delay(200);
                        //greenRectangle.Opacity = 100;
                        break;
                }//- End of switch
                await Task.Delay(200);
            }//- end of foreach

            playingBack = false;
        }//- End of playback()

    }//- End of Sequential
}
