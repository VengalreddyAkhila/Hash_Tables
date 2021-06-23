using System;

namespace Hash_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HashTable Problem");            
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To");
            hash.Add("1", "Be");
            hash.Add("2", "Or");
            hash.Add("3", "Not");
            hash.Add("4", "To");
            hash.Add("5", "Be");           
            Console.WriteLine(hash.Find("5"));
            Console.WriteLine(hash.Find("0"));
            Console.WriteLine(hash.Find("3"));
        }
    }
}
