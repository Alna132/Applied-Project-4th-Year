using AppliedProject4thYear;
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

namespace AppliedProject4thYear.Memory
{
    public sealed partial class ShoppingList : Page
    {

        //- Setting up the constant variables for the 10 shopping item options, the game length and the info strings.
        const int NUM_OF_ITEMS = 10;
        const int CARROTS = 1;
        const int STEAK = 2;
        const int MILK = 3;
        const int BREAD = 4;
        const int COOKIES = 5;
        const int JUICE = 6;
        const int CEREAL = 7;
        const int ORANGE = 8;
        const int PASTA = 9;
        const int CHOCOLATE = 10;

        const int MAX_ITEM_COUNT = 50;
        const String START_STRING = "Click to start!";
        const String WIN_STRING = "YOU WIN!";

        //- Keeps track of the current number of items in the shopping list.
        int shoppingListItemCount = 0;

        //- Variables for setting up the arrays for the shopping list.
        Random randNum;
        int[] rightItemSequence;
        int[] userItemSequence;
        int rightItemSequenceIndex = 0;
        int userItemSequenceIndex = 0;

        //- Variables to keep track of the game state.
        Boolean isUserTurn = true;
        Boolean isListRight = false;
        Boolean isGameStarted = false;
        Boolean isDoingAnimation = false;

        public ShoppingList()
        {
            this.InitializeComponent();

            randNum = new Random();

            rightItemSequence = new int[MAX_ITEM_COUNT];
            userItemSequence = new int[MAX_ITEM_COUNT];
            initItemSequence();

            txtBlkRoundNum.Opacity = 0;
            Correct.Opacity = 0;
            Incorrect.Opacity = 0;
        }//- End of ShoppingList()

        private void initItemSequence()
        {
            //- Alter this to start with 3 Items and add the users choices to the list and then check against it.
            for (int i = 0; i < 4; i++)
            {
                rightItemSequence[i] = randNum.Next(1, NUM_OF_ITEMS);
                userItemSequence[i] = 0;
            }//- End of for
        }//- End of initItemSequence()

        private void gameStart()
        {
            shoppingListItemCount = 0;
            txtBlkRoundNum.Text = shoppingListItemCount.ToString();
            txtBlkRoundNum.Foreground = new SolidColorBrush(Colors.Black);
            txtBlkRoundNum.Opacity = 100;
            txtBlkRoundNum.Opacity = 0;
            Correct.Opacity = 0;
            Incorrect.Opacity = 0;
            isGameStarted = true;
            userItemSequenceIndex = 0;
            initItemSequence();
            isUserTurn = false;
            gameContinue();
        }//- End of gameStart()

        private void gameContinue()
        {
            isListRight = true;
            for (int i = 0; i < (userItemSequenceIndex - 1); i++)
            {
                if (rightItemSequence[i] == userItemSequence[i])
                {
                    //- If sequence is right, add the new item to the rightItemSequence and leave isListRight as true.
                    rightItemSequence = userItemSequence;
                    Correct.Opacity = 100;
                }
                else
                {
                    //- If sequence is wrong, set isListRight to false and break the loop.
                    isListRight = false;
                    Incorrect.Opacity = 100;
                    break;
                }//- End of if/else
            }
            if (isListRight)
            {
                if (userItemSequenceIndex >= shoppingListItemCount)
                {
                    shoppingListItemCount++;
                    if (shoppingListItemCount < MAX_ITEM_COUNT)
                    {
                        //- If the current sequenceCount is less than the max then display the count.
                        txtBlkRoundNum.Text = shoppingListItemCount.ToString();
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
                    Correct.Opacity = 0;
                    Incorrect.Opacity = 0;
                    isUserTurn = true;
                }//- End of inner if/else
            }
            else
            {
                //- If isSequenceRight is false, then end the game.
                gameOver(START_STRING);
            }//- End of outer if/else
        }//- End of gameContinue()

        private void gameOver(String gameOverMessage)
        {
            isGameStarted = false;
            txtBlkStart.Text = gameOverMessage;
            txtBlkStart.Opacity = 100;
            txtBlkRoundNum.Foreground = new SolidColorBrush(Colors.Gray);
            txtBlkRoundNum.Opacity = 40;
            isUserTurn = true;
        }//- End of gameOver()

        /*        private void doStartAnimation() //Not finished!!
                {
                    switch (rightItemSequence[rightItemSequenceIndex])
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

                    rightItemSequenceIndex++;
                }//- End of doNextAnimation()*/

        private void MainMenuAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }//- End of MainMenuAppBarBtn_Click

        private void BackAppBarBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MemoryNav));
        }//- End of BackAppBarBtn_Click


    }//- End of ShoppingList
}//- End of AppliedProject4thYear.Memory
