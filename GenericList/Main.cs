// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;

namespace myGenericList
{
    public class Program
    { 
        static void Main(string[] args)
        {
            int sum=0;
            Random random = new Random();

            GenericList<int> genericList = new GenericList<int>();
            for (int i = 0; i < 10; i++)
            {
                //Console.WriteLine(random.Next());
                genericList.Add(random.Next() % 100);
            }

            int max = genericList.Head.Data;
            int min = genericList.Head.Data;

            genericList.ForEach(i => Console.Write(i + " "));
            genericList.ForEach(n => sum = sum + n);
            genericList.ForEach(n => { max = max > n ? max : n; });
            genericList.ForEach(n => { min = min < n ? min : n; });     //lambda表达式"=>"
            Console.WriteLine();
            Console.WriteLine("The maximum values are: " + max);
            Console.WriteLine("The minimum values are: " + min);
            Console.WriteLine("The sum is: " + sum);
        }
    }
}