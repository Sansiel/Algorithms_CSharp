using System;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            string choose = "";
            while (choose != "stop") {
                Console.WriteLine("Choose - Fast (f) / Merge (m) / Count (c) / Radix (r) / Gnome (g)");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "f":
                        FastSorting.MainSort();
                        break;
                    case "m":
                        MergeSorting.MainSort();
                        break;
                    case "c":
                        CountSorting.MainSort();
                        break;
                    case "r":
                        RadixSorting.MainSort();
                        break;
                    case "g":
                        GnomeSorting.MainSort();
                        break;
                }
                Console.WriteLine("To end program type 'stop'");
            }
        }
    }
}
