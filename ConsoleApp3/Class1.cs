using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate int MyDelegate(int number, string text);
namespace ConsoleApp3
{
    internal class Class1
    {
        MyDelegate myDelegate = (x, y) => x + 2;
        MyDelegate myDelegate2 = MyMethod;

       public static int MyMethod(int x, string y)
        {
            return x + 2;
        }
    }
}
