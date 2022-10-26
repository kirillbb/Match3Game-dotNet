using TestMatch3.Interfaces;

namespace TestMatch3
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            IDrawer drawer = new Drawer();
            Match3Game starter = new Match3Game(drawer);
            starter.Run();
            Console.ReadLine();
        }
    }
}