using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource_Lahiye_isi_.Interface;
using HumanResource_Lahiye_isi_.Models;

namespace HumanResource_Lahiye_isi_.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> departments { get; set; }
        public HumanResourceManager()
        {
            departments = new List<Department>();
        }

        public void AddDepartment()
        {
            throw new NotImplementedException();
        }

        public void AddEmployee()
        {
            throw new NotImplementedException();
        }

        public void EditDepartment()
        {
            throw new NotImplementedException();
        }

        public void EditEmployee()
        {
            throw new NotImplementedException();
        }

        public void GetDepartment()
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee()
        {
            throw new NotImplementedException();
        }

       
    }
}
