using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMatch3.Interfaces
{
    public interface IDrawer
    {
        void Draw(string[,] map, int size);

        void Message(int score);

        void GameOver(int totalScore);
    }
}
