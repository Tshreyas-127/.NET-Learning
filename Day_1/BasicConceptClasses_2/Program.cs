using System.Security.Claims;

namespace nested_classes
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Class obj;
            obj = new Class();

            Class obj2 = new Class();

            obj2.Display();
            obj.Display();

        }

        static void Main(string[] args)
        {

            Class obj= new Class();

            obj.Display();
            obj.Display("Shreyas");

            Console.WriteLine(obj.Add());
            Console.WriteLine(obj.Add(10));
            Console.WriteLine(obj.Add(10,20));
            Console.WriteLine(obj.Add(10,20,30));
        }

        public class Class {

            public void Display()
            {
                Console.WriteLine("Display called");
            }
            //func overloading - same func name, diff parameters
            public void Display(string s)
            {
                Console.WriteLine("Display called " + s);
            }

            public int Add(int a=0, int b=0, int c=0)
            { 
                return a + b + c; 
            }
        }
    }
}
