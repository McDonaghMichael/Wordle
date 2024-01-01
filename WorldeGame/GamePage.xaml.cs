using System;
using System.Reflection;

namespace WorldeGame
{
    public partial class GamePage : ContentPage
    {
        private int currentRow = 0;
        private int currentColumn = 0;
        private int lettersClicked = 0;
        private int score = 0;
        char[] lettersArray = { '-', '-', '-', '-', '-' };
        string[] randomWords = { "AAAAA", "BBBBB", "Birds", "Death", "Silly" };

        Label label = new Label
        {
            Text = "dsfd",
            Margin = new Thickness(0, 0, 0, 20)
        };

        public GamePage()
        {
            InitializeComponent();

            lettersGrid.Children.Add(label);

        }

        private void OnLetterButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if(lettersClicked < 5)
                {
         
                    char selectedLetter = button.Text.Length > 0 ? button.Text[0] : 'A';
                    AddLetterToGrid(selectedLetter);
                    lettersClicked++;
                }
                
            }

            
        }

        private void OnBackspaceButtonClicked(object sender, EventArgs e)
        {
            RemoveLastLetterFromGrid();
        }


        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {


            char firstLetter = randomWords[currentRow].Length > 0 ? randomWords[currentRow][0] : '\0';
            char secondLetter = randomWords[currentRow].Length > 1 ? randomWords[currentRow][1] : '\0';
            char thirdLetter = randomWords[currentRow].Length > 2 ? randomWords[currentRow][2] : '\0';
            char fourthLetter = randomWords[currentRow].Length > 3 ? randomWords[currentRow][3] : '\0';
            char fifthLetter = randomWords[currentRow].Length > 4 ? randomWords[currentRow][4] : '\0';

            if(lettersArray[0] == firstLetter && lettersArray[1] == secondLetter && lettersArray[2] == thirdLetter && lettersArray[3] == fourthLetter && lettersArray[4] == fifthLetter)
            {
                score++;

                label.Text = score + "";
            }



            currentRow++;
            currentColumn = 0;
            lettersClicked = 0;
        }

        private void AddLetterToGrid(char letter)
        {

            lettersArray[currentColumn] = letter;
            var label = new Label
            {
                Text = letter + "",
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            Grid.SetRow(label, currentRow);
            Grid.SetColumn(label, currentColumn);
            lettersGrid.Children.Add(label);


            currentColumn++;
           
        }


        private void RemoveLastLetterFromGrid()
        {
            if (lettersGrid.Children.Count > 0)
            {
            
                lettersGrid.Children.RemoveAt(lettersGrid.Children.Count - 1);

                currentColumn--;
                lettersClicked--;


                if (currentColumn < 0)
                {
                    currentRow--;


                    if (currentRow >= 0)
                    {
                        currentColumn = lettersGrid.ColumnDefinitions.Count - 1;
                    }
                    else
                    {
                        currentRow = 0; 
                        currentColumn = 0;  
                    }
                }
            }
        }


    }
}