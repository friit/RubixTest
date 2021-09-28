using System;

namespace Rubix
{
    class Program
    {
        static void Main(string[] args)
        {
            var cube = new Cube();

            cube.Print();

            while (true)
            {
                Console.WriteLine("Enter a command");
                var input = Console.ReadLine();
            }
        }
    }
}
