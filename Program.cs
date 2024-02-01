using System;

namespace TicTacToe
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Player1: X and Player2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");
                Board();

                string? input = Console.ReadLine(); // Déclaration de la variable input comme nullable
                if (input != null && int.TryParse(input, out choice) && choice >= 1 && choice <= 9)
                {
                    if (arr[choice] != 'X' && arr[choice] != 'O')
                    {
                        if (player % 2 == 0)
                        {
                            arr[choice] = 'O';
                            player++;
                        }
                        else
                        {
                            arr[choice] = 'X';
                            player++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, the row {0} is already marked with {1}", choice, arr[choice]);
                        Console.WriteLine("\n");
                        Console.WriteLine("Please wait 2 seconds, the board is loading again...");
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 seconds, the board is loading again...");
                    System.Threading.Thread.Sleep(2000);
                }
                flag = CheckWin();
            } while (flag != 1 && flag != -1);

            // Console.Clear(); // Nettoie la console après que le jeu est terminé
            Board(); // Affiche le tableau final
            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }

        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin()
        {
            if (arr[1] == arr[2] && arr[2] == arr[3] || arr[4] == arr[5] && arr[5] == arr[6] || arr[7] == arr[8] && arr[8] == arr[9] || // Horizontal
                arr[1] == arr[4] && arr[4] == arr[7] || arr[2] == arr[5] && arr[5] == arr[8] || arr[3] == arr[6] && arr[6] == arr[9] || // Vertical
                arr[1] == arr[5] && arr[5] == arr[9] || arr[3] == arr[5] && arr[5] == arr[7]) // Diagonal
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
    }
}

