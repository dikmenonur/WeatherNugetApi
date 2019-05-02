using System;
using System.Text;

namespace Atom.Weather.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherCore weactherCore = new WeatherCore();
            Console.WriteLine(weactherCore.SendRequest().ToJson());
        }
    }
}
