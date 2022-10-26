using TestMatch3.Interfaces;

namespace TestMatch3
{
    public class Drawer : IDrawer
    {
        public void Draw(string[,] map, int size)
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    switch (map[x, y])
                    {
                        case "0":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "2":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "3":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }

                    Console.Write($"({map[x, y]})");
                    Console.ResetColor();
                    Console.Write(" ");
                }

                Console.WriteLine("\n");
            }
        }

        public void NewLine()
        {
            Console.WriteLine("------------------------------------");
        }

        public void Message(int score)
        {
            NewLine();
            Console.WriteLine($"To continue press Enter. Current Score: {score}");
            NewLine();
        }

        public void GameOver(int totalScore)
        {
            string gameOver =
                "░██████╗░░█████╗░███╗░░░███╗███████╗░░░░░█████╗░██╗░░░██╗███████╗██████╗░██╗\r\n" +
                "██╔════╝░██╔══██╗████╗░████║██╔════╝░░░░██╔══██╗██║░░░██║██╔════╝██╔══██╗██║\r\n" +
                "██║░░██╗░███████║██╔████╔██║█████╗░░░░░░██║░░██║╚██╗░██╔╝█████╗░░██████╔╝██║\r\n" +
                "██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░░░░░██║░░██║░╚████╔╝░██╔══╝░░██╔══██╗╚═╝\r\n" +
                "╚██████╔╝██║░░██║██║░╚═╝░██║███████╗░░░░╚█████╔╝░░╚██╔╝░░███████╗██║░░██║██╗\r\n" +
                "░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝░░░░░╚════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝";
            NewLine();
            Console.WriteLine(gameOver);
            Console.WriteLine($"Your score is: {totalScore}");
            NewLine();
        }
    }
}
