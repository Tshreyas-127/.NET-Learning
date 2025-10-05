using System.Security.Cryptography.X509Certificates;

namespace Task_day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee o1 = new Employee("Shreyas",24000, 101);
            Employee o2 = new Employee("Sumit", 33000);
            Employee o3 = new Employee("Om");
            Employee o4 = new Employee();

            o1.display();
            o2.display();
            o3.display();
            o4.display();

        }

        // Move EmpNo_generator inside Employee class and make it static
        public class Employee

        {
            private string Name;
            private static int NextEmpNo=1;
            private decimal Basic;
            private short DeptNo;
            

            public int EmpNo{ get; }

            public Employee(string Name = "Amaan", decimal Basic = 50000, short DeptNo = 0)
            {
                this.Name = Name;
                EmpNo = NextEmpNo;
                NextEmpNo++;
                this.Basic = Basic;
                this.DeptNo = DeptNo;
               
            }
            public decimal GetNetSalary()
            {
                return Basic * 2.1M;
            }
            public void display()
            {
                Console.WriteLine($"Name: {Name},EmpNo:{EmpNo},Basic: {Basic} ,DeptNo: {DeptNo}");
            }

            
            
        }
        
         
    }
    
}
