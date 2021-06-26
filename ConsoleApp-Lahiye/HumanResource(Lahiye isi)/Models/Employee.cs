using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource_Lahiye_isi_.Models
{
    class Employee
    {
        public string No;
        public static int Count { get; set; } = 1000;

        public string Fullname;
        
        public string  Name { get; set; }
        public string  Surname { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string DepartmentName { get; set; }
        
        public Employee(string name,string surname,string position,double salary,string departmentname )        
        {
            Name = name;
            Surname = surname;           
            Position=position;
            Salary=salary;
            Count++;
            No = departmentname.ToString().Trim().ToUpper().Substring(0, 2) + Count.ToString();
            //ilk 2 herfin gostersin deye
            DepartmentName=departmentname;
            Fullname = Name +" "+Surname;
            //FullName-i Name+Surname assign etdim ki , Name Surname teleb olunsun.
        }

        

        public override string ToString()
        {
            return $"{No} {Fullname} {Position} {Salary} {DepartmentName}";
        }
    }
}

