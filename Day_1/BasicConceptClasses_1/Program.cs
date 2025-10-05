using System.Runtime.InteropServices;

namespace Day1
{
    internal class Program
    {
        static void Main()
        {
            Class obj = new Class();

            obj.i = ++obj.i + obj.i++ - --obj.i - obj.i--;
            obj.Seti(obj.Geti() + 1);
            
            obj.Seti(70); // This will print "Value too large"                                                                                          
            Console.WriteLine(obj.Geti());
        }
        
        public class Class
        {
            public int i = 1;

            public void Seti(int value)
            {
                if (value <= 100)
                {
                    i = value;
                }
                else
                {
                    Console.WriteLine("Value too large");
                }
            }
            public int Geti()
            {
                return i;
            }

        }
    }
}
