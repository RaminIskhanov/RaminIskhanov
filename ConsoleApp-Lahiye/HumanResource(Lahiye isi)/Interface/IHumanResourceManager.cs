using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource_Lahiye_isi_.Models;


namespace HumanResource_Lahiye_isi_.Interface
{
    interface IHumanResourceManager
    {
        List<Department> departments { get; set; }
        void AddDepartment();     
        void GetDepartment();
        void EditDepartment();
        void AddEmployee();
        void RemoveEmployee();
        void EditEmployee();
        

    }
}
