using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char ch,sel;
            char i;


            List<Employee> listemployee = new List<Employee>();

           

              
                    Console.WriteLine("\n****************************");
                    do
                    {
                        Console.WriteLine("\n***********Add New Employee***********");
                        Console.WriteLine($"EmployeeId:{listemployee.Count}");
                        listemployee.Add(AddEmployee());
                        Console.Write("\nAdd Employee('y':'n')?");
                        ch = char.ToLower(Console.ReadKey().KeyChar);
                        Console.WriteLine("\n****************************");

                    } while (ch.Equals('y'));

            Console.Write("\n\n\r**************************\n\r'e''=>Edit\n\r'r'=>Remove\n\r\n\rOperation: ");
            i = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine("\n\n");
            do
            {
                switch (i)
                {

                    case 'e': EditEmployee(listemployee); break;

                    case 'r': RemoveEmployee(listemployee); break;

                    default: Console.WriteLine("\n Wrong Character"); break;



                }
             Console.Write("\nSelect Another Operation('y'|'n')? ");
                 sel = char.ToLower(Console.ReadKey().KeyChar);
            } while (sel.Equals('y'));
            PrintEmployee(listemployee);
           
        }


        //Add Data
        static Employee AddEmployee( )
        {
            Employee emp = new Employee();

            var properties = emp.GetType().GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                if (prop.PropertyType == typeof(Address))
        {
            Address addr = new Address();

        Console.Write("Street: ");
            addr.Street = Console.ReadLine();

            Console.Write("City: ");
            addr.City = Console.ReadLine();

            Console.Write("State: ");
            addr.State = Console.ReadLine();

            Console.Write("Country: ");
            addr.Country = Console.ReadLine();

            prop.SetValue(emp, addr);
        }
        else
        {
            Console.Write($"{prop.Name}: ");
            var value = Console.ReadLine();

            if (prop.PropertyType == typeof(double))
            {
                if (double.TryParse(value, out double d))
                    prop.SetValue(emp, d);
            }
            else
{
    prop.SetValue(emp, value);
}
        }
    }

           
           
            return emp;
}

        //Edit
        static List<Employee> EditEmployee(List<Employee> listEmployee)
        {
            char ch;
            Console.WriteLine("\n***********Edit Employee***********");
            foreach(Employee emp in listEmployee)
            {
                var properties= emp.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach(var property in properties)
                {
                    Console.Write($"{property.Name}:Edit('y':'n')?");
                    ch = char.ToLower(Console.ReadKey().KeyChar);
                    Console.WriteLine("\n");
                    if (ch.Equals('y'))
                    {
                        if (property.PropertyType == typeof(Address))
                        {
                            Address addr = new Address();

                            Console.Write("Street: ");
                            addr.Street = Console.ReadLine();

                            Console.Write("City: ");
                            addr.City = Console.ReadLine();

                            Console.Write("State: ");
                            addr.State = Console.ReadLine();

                            Console.Write("Country: ");
                            addr.Country = Console.ReadLine();

                            property.SetValue(emp, addr);
                        }
                        else
                        {
                            Console.Write($"{property.Name}: ");
                            var value = Console.ReadLine();

                            if (property.PropertyType == typeof(double))
                            {
                                if (double.TryParse(value, out double d))
                                    property.SetValue(emp, d);
                            }
                            else
                            {
                                property.SetValue(emp, value);
                            }
                        }
                    }
                    else { continue; }

                }

            }

            return listEmployee;
        }
        //Delete
        static List<Employee> RemoveEmployee(List<Employee> listEmployee)
        {
            char ch;
            Console.WriteLine("\n***********Remove Employee***********");
            if (listEmployee.Count >= 0) {
            //PrintEmployee(listEmployee);
                Console.Write("\n\r c=>Index\n\r r=>Range\n\rv=>Value\n\rother=>clear\n\rRemove BY:");
                ch = char.ToLower(Console.ReadKey().KeyChar);
                switch (ch) 
                {
                    case 'c':
                        Console.Write("\nIndex:");
                        string i = (Console.ReadLine());
                        if(int.TryParse(i, out int n))
                            listEmployee.RemoveAt(n);
                        break;
                    case 'r':
                        Console.WriteLine("\nRange:");
                        Console.Write("\nFrom:");
                        string x= (Console.ReadLine());
                        Console.Write("\nTo:");
                        string y = (Console.ReadLine());
                        if (int.TryParse(x, out int value1))
                            if(int.TryParse(y, out int value2))
                     
                            listEmployee.RemoveRange(value1,value2);
                        break;
                    
                    case 'v':

                        Console.Write("\nProperty Name: ");
                        string propName = Console.ReadLine();

                        Console.Write("Value: ");
                        string value = Console.ReadLine();

                        listEmployee.RemoveAll(emp =>
                        {
                            var prop = emp.GetType().GetProperty(propName,
                            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                            if (prop == null) return false;

                            var propValue = prop.GetValue(emp);

                            return propValue != null &&
                                   propValue.ToString().Equals(value, StringComparison.OrdinalIgnoreCase);
                        });

                        break;

                        
                    default:
                        listEmployee.Clear();
                        break;

                }



            }
            return listEmployee;
        }
        //Read
        static void PrintEmployee(List<Employee> listEmployee)
        {
            Console.WriteLine("\n***********Print Employee***********");
            foreach (var emp in listEmployee)
            {
                var properties = emp.GetType().GetProperties(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (var prop in properties)
                {
                    var value = prop.GetValue(emp);

                    if (value is Address addr) // لو الخاصية من نوع Address
                    {
                        Console.WriteLine($"Address: {addr.Street}, {addr.City}-{addr.State}- {addr.Country}");
                        //Console.WriteLine($"Street: {addr.Street}");
                        //Console.WriteLine($"City: {addr.City}");
                        //Console.WriteLine($"State: {addr.State}");
                        //Console.WriteLine($"Country: {addr.Country}");

                    }
                    else
                    {
                        Console.WriteLine($"{prop.Name}: {value}");
                    }
                }
                Console.WriteLine("\n*******************");
            }
            Console.WriteLine("\n*******************");
        }
    }


    class Address
    {
        //fields
        private string _street;
        private string _city;
        private string _state;
        private string _country;
       //properties
        public string Street { get => _street;set=> _street = value;  } 
        public string City { get => _city;set => _city = value; }
        public string State { get => _state; set => _state = value; }
        public string Country { get => _country;set => _country = value; }
       
    }
    class Employee:IJob
    {
        //fields
        private string _firstName;
        private string _lastName;
        private Address _address=new Address();
        private string _job;
        private double _salary;
        //properties
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public Address Address { get => _address; set => _address = value; }
        //Implment Interface Member
        public string Job { get => _job; set => _job = value; }
        public double Salary { get => _salary;set => _salary = value;  }

    }
    //Interface IJob
    interface IJob
    {//properties
        string Job {  get; set; }
        double Salary {  get; set; }

	}
}
