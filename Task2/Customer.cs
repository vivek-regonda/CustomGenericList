using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Task2
{
    class Customer

    {
        private int id;
        private string name;
        private string gender;
        private string DateOfBirth;

        public Customer(int id, string name,string gender,string dob)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.DateOfBirth = dob;
        }
        public override string ToString()
        {

            return id + " " + name;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Customer p = obj as Customer;
            if ((Object)p == null)
                return false;

            return (id == p.id) && (name == p.name);
        }



       

        public string Name { 
            get{return name;}
        }

        public int Id
        {
            get { return id; }
        }


        static void Main(string[] args)
        {
            Set<Customer> a = new Set<Customer>();
            a.Add(new Customer(56, "john","male","01/01/1991"));
            a.Add(new Customer(28, "rick","male","03/10/1992"));
            a.Add(new Customer(31, "jonas", "male", "12/03/1997"));
            a.Add(new Customer(45, "sana", "female", "25/04/1995"));
            a.Add(new Customer(52, "deepika", "female", "26/05/1981"));

            a.PrintList();

            a.Remove(new Customer(56, "john", "male", "01/1/1991"));
            a.PrintList();
            a.Find("rick");
            a.Sort();
            a.PrintList();




           
        }
    }





   




}
