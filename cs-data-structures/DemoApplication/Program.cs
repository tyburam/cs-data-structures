using System;
using DataStructures;

namespace DemoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var da = new DynamicArray<int>();
            for(var i = 0; i < 20; i++) {
                da.Add(i);
            }
            Console.WriteLine(da);
            Console.WriteLine("Element at index 10 = {0}", da[10]);
            Console.WriteLine("Dynamic array afer removing 5");
            da.Remove(5);
            Console.WriteLine(da);
            Console.WriteLine("Index of elemnt with value 7 = {0}", da.IndexOf(7));
        }
    }
}
