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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _4thYearAppliedProject.Memory
{
    public sealed partial class Sequential : Page
    {
        //- Setting up the constant variables for the 4 colour options, the game length and the info strings.
        const int NUM_OF_COLOURS = 4;
        const int RED_COLOUR = 1;
        const int BLUE_COLOUR = 2;
        const int YELLOW_COLOUR = 3;
        const int GREEN_COLOUR = 4;
        const int MAX_SEQUENCE_COUNT = 30;
        const String START_STRING = "Click to start!";
        const String WIN_STRING = "YOU WIN!";

        //- Keeps track of the current number of colours in the sequence.
        int sequenceCount = 0;

        //- Variables for setting up the arrays for the sequences.
        Random randNum;
        int[] rightColourSequence;
        int[] userColourSequence;
        int rightColourSequenceIndex = 0;
        int userColourSequenceIndex = 0;

        //- Variables to keep track of the game state.
        Boolean isUserTurn = true;
        Boolean isSequenceRight = false;
        Boolean isGameStarted = false;
        Boolean isDoingAnimation = false;

        //- Variables for the timing of the game.
        long timeStart, timeEnd, timeDifference;

        public Sequential()
        {
            this.InitializeComponent();

            randNum = new Random();

            //- This sets up the arrays to the size of the MAX_SEQUENCE_COUNT which is 30.
            rightColourSequence = new int[MAX_SEQUENCE_COUNT];
            userColourSequence = new int[MAX_SEQUENCE_COUNT];
            initColourSequence();

            //- This makes the textblock transparent.
            txtBlkRoundNum.Opacity = 0;
            txtBlkStart.Opacity = 100;
        }//- End of Sequential()

        private void BackAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MemoryNav));
        }//- End of BackAppBarBtn_Click

        private void MainMenuAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }//- End of MainMenuAppBarBtn_Click

        private void gameStart()
        {
            sequenceCount = 0;
            txtBlkRoundNum.Text = sequenceCount.ToString();
            txtBlkRoundNum.Foreground = new SolidColorBrush(Colors.Black);
            txtBlkRoundNum.Opacity = 100;
            txtBlkRoundNum.Opacity = 0;
            isGameStarted = true;
            userColourSequenceIndex = 0;
            initColourSequence();
            isUserTurn = false;
            gameContinue();
        }//- End of gameStart()

        private void gameContinue()
        {
            //- This for loop checks if the user input sequence is right. 
            isSequenceRight = true;
            for (int i = 0; i < userColourSequenceIndex; i++)
            {
                if (rightColourSequence[i] == userColourSequence[i])
                {
                    //- If sequence is right, do nothing and leave isSequenceRight as true.
                }
                else
                {
                    //- If sequence is wrong, set isSequenceRight to false and break the loop.
                    isSequenceRight = false;
                    break;
                }//- End of if/else
            }//- End of for

            //- If isSequenceRight still is true after the for loop.
            if (isSequenceRight)
            {
                if (userColourSequenceIndex >= sequenceCount)
                {
                    sequenceCount++;
                    if (sequenceCount < MAX_SEQUENCE_COUNT)
                    {
                        //- If the current sequenceCount is less than the max then display the count.
                        txtBlkRoundNum.Text = sequenceCount.ToString();
                    }
                    else
                    {
                        //- If the current sequenceCount is greater than or equal to the max then end the game.
                        gameOver(WIN_STRING);
                    }//- End of inner inner if/else
                }
                else
                {
                    //- If the userColourSequenceIndex is less than the sequenceCount then set isUserTurn to true. 
                    //playerColorSequenceIndex++; 
                    isUserTurn = true;
                }//- End of inner if/else
            }
            else
            {
                //- If isSequenceRight is false, then end the game.
                gameOver(START_STRING);
            }//- End of outer if/else
        }//- End of gameContinue()

        private void txtBlkStart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txtBlkStart.Text.Equals(START_STRING))
            {
                //- If the text in txtBlkStart is the START_STRING, start the game.
                if (txtBlkStart.Opacity != 0)
                {
                    //- If txtBlkStart is visible (not transparent), then start the game.
                    gameStart();
                }//- End of inner if
            }
            else if (txtBlkStart.Text.Equals(WIN_STRING))
            {
                //- If the text in txtBlkStart is the WIN_STRING, end the game.
                gameOver(START_STRING);
            }
            else
            {
                //- Otherwise do nothing.
            }//- End of if/elseif
        }//- End of txtBlkStart_Tapped

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (txtBlkStart.Text.Equals(START_STRING))
            {
                //- If the text in txtBlkStart is the START_STRING, start the game.
                if (txtBlkStart.Opacity != 0)
                {
                    //- If txtBlkStart is visible (not transparent), then start the game.
                    gameStart();
                }//- End of inner if
            }
            else if (txtBlkStart.Text.Equals(WIN_STRING))
            {
                //- If the text in txtBlkStart is the WIN_STRING, end the game.
                gameOver(START_STRING);
            }
            else
            {
                //- Otherwise do nothing.
            }//- End of if/elseif
        }//- End of btnStart_Click

        private void redRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (isUserTurn)
            {
                storyboardRedRectanglePlayer.Begin();

                if (isGameStarted)
                {
                    userColourSequence[userColourSequenceIndex++] = RED_COLOUR;
                    isUserTurn = false;
                    gameContinue();
                }//- End of inner if
            }//- End of if
        }//- End of redRectangle_Tapped

        private void blueRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (isUserTurn)
            {
                storyboardBlueRectanglePlayer.Begin();

                if (isGameStarted)
                {
                    userColourSequence[userColourSequenceIndex++] = BLUE_COLOUR;
                    isUserTurn = false;
                    gameContinue();
                }//- End of inner if
            }//- End of if
        }//- End of blueRectangle_Tapped

        private void yellowRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (isUserTurn)
            {
                storyboardYellowRectanglePlayer.Begin();

                if (isGameStarted)
                {
                    userColourSequence[userColourSequenceIndex++] = YELLOW_COLOUR;
                    isUserTurn = false;
                    gameContinue();
                }//- End of inner if
            }//- End of if
        }//- End of yellowRectangle_Tapped

        private void greenRectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (isUserTurn)
            {
                storyboardGreenRectanglePlayer.Begin();

                if (isGameStarted)
                {
                    userColourSequence[userColourSequenceIndex++] = GREEN_COLOUR;
                    isUserTurn = false;
                    gameContinue();
                }//- End of inner if
            }//- End of if
        }//- End of greenRectangle_Tapped

        private void storyboardRedRectangle_Completed(object sender, object e)
        {
            if (rightColourSequenceIndex < sequenceCount)
            {
                doNextAnimation();
            }
            else
            {
                isDoingAnimation = false;
                isUserTurn = true;
                rightColourSequenceIndex = 0;
                userColourSequenceIndex = 0;
            }//- End of if/else
        }//- End of storyboardRedRectangle_Completed

        private void storyboardBlueRectangle_Completed(object sender, object e)
        {
            if (rightColourSequenceIndex < sequenceCount)
            {
                doNextAnimation();
            }
            else
            {
                isDoingAnimation = false;
                isUserTurn = true;
                rightColourSequenceIndex = 0;
                userColourSequenceIndex = 0;
            }//- End of if/else
        }//- End of storyboardBlueRectangle_Completed

        private void storyboardYellowRectangle_Completed(object sender, object e)
        {
            if (rightColourSequenceIndex < sequenceCount)
            {
                doNextAnimation();
            }
            else
            {
                isDoingAnimation = false;
                isUserTurn = true;
                rightColourSequenceIndex = 0;
                userColourSequenceIndex = 0;
            }//- End of if/else
        }//- End of storyboardYellowRectangle_Completed

        private void storyboardGreenRectangle_Completed(object sender, object e)
        {
            if (rightColourSequenceIndex < sequenceCount)
            {
                doNextAnimation();
            }
            else
            {
                isDoingAnimation = false;
                isUserTurn = true;
                rightColourSequenceIndex = 0;
                userColourSequenceIndex = 0;
            }//- End of if/else
        }//- End of storyboardGreenRectangle_Completed

        private void gameOver(String gameOverMessage)
        {
            isGameStarted = false;
            txtBlkStart.Text = gameOverMessage;
            txtBlkStart.Opacity = 100;
            txtBlkRoundNum.Foreground = new SolidColorBrush(Colors.Gray);
            txtBlkRoundNum.Opacity = 40;
            isUserTurn = true;
        }

        private void initColourSequence()
        {
            for (int i = 0; i < MAX_SEQUENCE_COUNT; i++)
            {
                rightColourSequence[i] = randNum.Next(1, NUM_OF_COLOURS);
                userColourSequence[i] = 0;
            }//- End of for
        }//- End of initColourSequence()

        private void doNextAnimation()
        {
            switch (rightColourSequence[rightColourSequenceIndex])
            {
                case 1:
                    storyboardRedRectangle.Begin();
                    isDoingAnimation = true;
                    break;
                case 2:
                    storyboardBlueRectangle.Begin();
                    isDoingAnimation = true;
                    break;
                case 3:
                    storyboardYellowRectangle.Begin();
                    isDoingAnimation = true;
                    break;
                case 4:
                    storyboardGreenRectangle.Begin();
                    isDoingAnimation = true;
                    break;
                default:
                    break;
            }//- End of switch

            /*if (rightColourSequence[rightColourSequenceIndex] == 1)
            {
                storyboardRedRectangle.Begin();
                isDoingAnimation = true;
            }
            else if (rightColourSequence[rightColourSequenceIndex] == 2)
            {
                storyboardBlueRectangle.Begin();
                isDoingAnimation = true;
            }
            else if (rightColourSequence[rightColourSequenceIndex] == 3)
            {
                storyboardYellowRectangle.Begin();
                isDoingAnimation = true;
            }
            else if (rightColourSequence[rightColourSequenceIndex] == 4)
            {
                storyboardGreenRectangle.Begin();
                isDoingAnimation = true;
            }//- End of if/elseif
            */

            rightColourSequenceIndex++;
        }//- End of doNextAnimation()

        private void waitMilliseconds(int waitTime) // Not used 
        {
            timeStart = DateTime.Now.Ticks;

            long totalWaitTimeInTicks = waitTime * 10000;

            do
            {
                timeEnd = DateTime.Now.Ticks;
                timeDifference = timeEnd - timeStart;
            } while (timeDifference < totalWaitTimeInTicks);
        }//- End of waitMilliseconds

    }//- End of Sequential
}
