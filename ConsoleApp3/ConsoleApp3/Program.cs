using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n1, n2;
            bool bothEven;
            Console.WriteLine( "input first number" );
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input second number");
            n2 = Convert.ToInt32(Console.ReadLine());
            bothEven = ((n1 % 2 == 0) && (n2 % 2 == 0)) ? true : false; 
            Console.WriteLine(bothEven ? "there are both number even" :"there are both nuiimber odd");
            Console.ReadLine();
        }
    }   
}
