using System;
using System.Windows;
using System.Windows.Controls;

namespace XvsO
{
    public partial class MainWindow : Window
    {
        private char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private bool player = true;
        private int choice;
        private int flag = 0;
        private bool isEnd = false;
        private int isPlayerTurn = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            arr = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            player = true;
            isEnd = false;
            flag = 0;
            isPlayerTurn++;

            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;
            btn6.IsEnabled = true;
            btn7.IsEnabled = true;
            btn8.IsEnabled = true;
            btn9.IsEnabled = true;
            btn1.Content = string.Empty;
            btn2.Content = string.Empty;
            btn3.Content = string.Empty;
            btn4.Content = string.Empty;
            btn5.Content = string.Empty;
            btn6.Content = string.Empty;
            btn7.Content = string.Empty;
            btn8.Content = string.Empty;
            btn9.Content = string.Empty;

            if (isPlayerTurn % 2 == 0)
            {
                Button button = (Button)sender;
                choice = BotMove();
                button = (Button)FindName("btn" + choice);
                arr[choice] = 'X';
                button.Content = 'X';
                player = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char[] delete = { 'b', 't', 'n' };
            Button button = (Button)sender;

            choice = int.Parse(button.Name.ToString().TrimStart(delete));
            if (arr[choice] != 'X' && arr[choice] != 'O' && player == true)
            {
                if (isPlayerTurn % 2 != 0)
                {
                    arr[choice] = 'X';
                    button.Content = 'X';
                }
                else
                {
                    arr[choice] = 'O';
                    button.Content = 'O';
                }
                player = false;

                flag = CheckWin();
                if (flag == 1)
                {
                    MessageBox.Show("Ты победил");
                    DisableButtons();
                    isEnd = true;
                }
                else if (flag == -1)
                {
                    MessageBox.Show("Ничья");
                    DisableButtons();
                }

                else if (player == false)
                {
                    choice = BotMove();
                    button = (Button)FindName("btn" + choice);
                    if (isPlayerTurn % 2 == 0)
                    {
                        arr[choice] = 'X';
                        button.Content = 'X';
                    }
                    else 
                    {
                        arr[choice] = 'O';
                        button.Content = 'O';
                    }
                    player = true;
                }
                if (isEnd == false)
                {
                    flag = CheckWin();
                    if (flag == 1)
                    {
                        MessageBox.Show("Бот умнее");
                        DisableButtons();
                    }
                    else if (flag == -1)
                    {
                        MessageBox.Show("Ничья");
                        DisableButtons();
                    }
                }
            }
        }

        private int CheckWin()
        {
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int BotMove()
        {
            int move = 0;
            if (arr[5] == '5')
            {
                move = 5;
            }
            else
            {
                move = RandomMove();
            }
            return move;
        }

        private int RandomMove()
        {
            Random r = new Random();
            int move = r.Next(1, 10);
            while (arr[move] == 'X' || arr[move] == 'O')
            {
                move = r.Next(1, 10);
            }
            return move;
        }

        private void DisableButtons()
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            btn7.IsEnabled = false;
            btn8.IsEnabled = false;
            btn9.IsEnabled = false;
        }

    }
}
