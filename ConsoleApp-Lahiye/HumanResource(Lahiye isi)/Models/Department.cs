using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource_Lahiye_isi_.Models
{
     class Department
    {
        

        public string  Name { get; set; }
        public int  WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public List<Employee> Employees { get; set; }
        public Department(string name ,int workerlimit,double salarylimit)
        {
            Employees = new List<Employee>(); 
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }

       

        public double CalcSalaryAvarege()
        {
            double avarage=0;
            double sum=0;
            //Bura geri don Pervin Muellim problem boslug
            foreach (Employee item in Employees)
            {
                sum += item.Salary;               
            }
            if (Employees.Count != 0)
            {
                avarage = sum / Employees.Count;
                return avarage;
            }
            else
            {
                return 0;
            }
            //Departmentdeki Iscilerin maas ortalamasinin hesablanmasi

        }

        internal int CalcSalaryAvarege(string name)
        {
            throw new NotImplementedException();
        }
    }
}
