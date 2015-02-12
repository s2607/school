using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    class Program
    {
        static void waitkey()
        {
            Console.WriteLine("press any key");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            String foo = "bar baz";
            Console.WriteLine("foo.left(33) returned {0}", foo.Left(33));
            Console.WriteLine("foo.left(3) returned {0}", foo.Left(3));
            Console.WriteLine("foo.right(3) returned {0}", foo.Right(3));
            Console.WriteLine("foo.right(33) returned {0}", foo.Right(33));
          // waitkey();
  
        }
    }
}
