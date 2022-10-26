using TestMatch3.Interfaces;

namespace TestMatch3
{
    public class Match3Game
    {
        private readonly int _size = 9;
        private string[,] map;
        private bool[,] sequencesMap;
        private readonly IDrawer _drawer;
        private Random random = new Random();

        public Match3Game(IDrawer drawer)
        {
            _drawer = drawer;
            map = new string[_size, _size];
        }

        public void Run()
        {
            int totalScore = 0;
            int roundScore = 0;

            do
            {
                SetBoxes();
                _drawer.Draw(map, _size);
                _drawer.Message(totalScore);
                Console.ReadLine();

                roundScore = CheckSequences();
                totalScore += roundScore;
                CleanSequences(sequencesMap);
                _drawer.Draw(map, _size);

                _drawer.Message(totalScore);
                Console.ReadLine();

                SlideDown();
                _drawer.Draw(map, _size);

                if (GameIsOver(roundScore))
                {
                    break;
                }

                _drawer.Message(totalScore);
                Console.ReadLine();
            } while (true);

            _drawer.GameOver(totalScore);
        }

        private bool GameIsOver(int roundScore)
        {
            return roundScore == 0;
        }

        private void SlideDown()
        {
            for (int y = 0; y < _size; y++)
            {
                int targetX = -1; //default to check
                int targetY = -1;

                for (int x = _size - 1; x >= 0; x--)
                {
                    if (BoxIsEmpty(x, y) && targetX == -1)
                    {
                        targetX = x;
                        targetY = y;
                    }
                    else if (!BoxIsEmpty(x, y) && targetX != -1)
                    {
                        string tempValue = map[x, y];
                        map[x, y] = map[targetX, targetY];
                        map[targetX, targetY] = tempValue;

                        x = _size - 1; // return down
                        targetX = -1;
                        targetY = -1;
                    }
                }
            }
        }

        private bool BoxIsEmpty(int x, int y) => map[x, y] == " " || map[x, y] == null;

        private void CleanSequences(bool[,] sequencesMap)
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    if (sequencesMap[x, y])
                    {
                        CleanBox(x, y);
                    }
                }
            }
        }

        private int CheckSequences()
        {
            sequencesMap = new bool[_size, _size];

            int count = 0;

            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    count += CheckSequence(x, y, 0, 1);
                    count += CheckSequence(x, y, 1, 0);
                }
            }

            return count;
        }

        private int CheckSequence(int x, int y, int stepX, int stepY)
        {
            string box = map[x, y];
            int count = 0;

            for (int x0 = x, y0 = y; GetBox(x0, y0) == box; x0 += stepX, y0 += stepY)
            {
                count++;
            }

            if (count > 2)
            {
                for (int x0 = x, y0 = y; GetBox(x0, y0) == box; x0 += stepX, y0 += stepY)
                {
                    sequencesMap[x0, y0] = true;
                }

                return count;
            }

            return 0;
        }

        private string GetBox(int x, int y)
        {
            if (!OnMap(x, y))
            {
                return " ";
            }

            return map[x, y];
        }

        private bool OnMap(int x, int y) =>  x >= 0 && y >= 0 && x < _size && y < _size;

        private void SetBoxes()
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    if (BoxIsEmpty(x, y))
                    {
                        map[x, y] = random.Next(0, 4).ToString();
                    }
                }
            }
        }

        private void CleanBox(int x, int y)
        {
            map[x, y] = " ";
        }
    }
}