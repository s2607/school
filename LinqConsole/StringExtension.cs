using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    //we will write an extension to the class "String"
    //we will create a method
    public static class StringExtension 
    {
        //just like golang :D
        //normally you would not put these in your user interface project:
        //you would create your own project just for extensions
        //                          V --- special modifier
        public static string Left(this string name, int length)
        {
            //alot of times you will return one of two things
            // the name if the length isn't logn enough or part of the name if it isnt
            // ternery operators explained
            return name == null ? null : name.Length <length ? name : name.Substring(0,length);
        }

        public static string Right(this string name, int length)
        {
            return name == null ? null : name.Length < length ? name : name.Substring(length);
        }
    }
}
