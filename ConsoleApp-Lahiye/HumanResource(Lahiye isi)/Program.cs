using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource_Lahiye_isi_.Models;
using HumanResource_Lahiye_isi_.Services;

namespace HumanResource_Lahiye_isi_
{
    class Program
    {
        

        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {
                Console.WriteLine("Etmek Isdediyniz Emelliyyati Secin");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1.1 Departamentlerin siyahisini gostermek");
                Console.WriteLine("1.2 Depart`amenet yaratmaq");
                Console.WriteLine("1.3 Departamentde deyisiklik etmek");
                Console.WriteLine("2.1 Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 Departamentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("2.3 Isci elave etmek");
                Console.WriteLine("2.4 Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 Departamentden isci silinmesi ");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1.1":
                        GetDepartment(humanResourceManager);
                        break;
                    case "1.2":
                        AddDepartment(humanResourceManager);
                        break;
                    case "1.3":
                        EditDepartment(humanResourceManager);
                        break;
                    case "2.1":
                        ShowEmployees(humanResourceManager);
                        break;
                    case "2.2":
                        ShowDepartmentEmployees(humanResourceManager);
                        break;
                    case "2.3":
                        AddEmployee(humanResourceManager);
                        break;
                    case "2.4":
                        EditEmployeea(humanResourceManager);
                        break;
                    case "2.5":
                        RemoveEmployee(humanResourceManager);
                        break;
                    default:
                        break;
                }

            } while (true);


        }
        public static void GetDepartment(HumanResourceManager humanResourceManager)
        {

            foreach (Department item in humanResourceManager.departments)
            {
                Console.WriteLine($"Department name: {item.Name}, salary limit:{item.SalaryLimit}, Worker limit:{item.WorkerLimit},Avarage Salary:{item.CalcSalaryAvarege()}, Employees Count: {item.Employees.Count}"); 

                }

           
        }
        public static void AddDepartment(HumanResourceManager humanResourceManager)
        {            
            bool nameloop = true;
            bool workerlimitloop = true;
            bool salarylimitloop = true;
            string departmentname = "";
            int departmentworkerlimit = 0;
            double departmentsalarylimit = 0;
            Console.WriteLine("Departmentin adin daxil edin");
            while (nameloop)
            {              
                try
                {
                    departmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(departmentname) ==false && departmentname.Length>=2)
                    {
                        nameloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun ad daxil et");
                }
            }
            Console.WriteLine("Departmentin Workerlimitin daxil edin");
            while (workerlimitloop)
            {
                try
                {
                    departmentworkerlimit = int.Parse(Console.ReadLine());
                    if (departmentworkerlimit >= 1)
                    {
                        workerlimitloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun WorkerLimit daxil edin");
                }
            }
            Console.WriteLine("Departmentin Salarylimitin daxil edin");
            while (salarylimitloop)
            {
                try
                {
                     departmentsalarylimit = double.Parse(Console.ReadLine());
                    if (departmentsalarylimit>=250)
                    {
                        salarylimitloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun SalaryLimit daxil edin");
                }
            }
            Department department = new Department(departmentname,departmentworkerlimit,departmentsalarylimit);
            humanResourceManager.departments.Add(department);

        }
        public static void EditDepartment(HumanResourceManager humanResourceManager)
        {
            
            string olddepartmentname = "";
            string newdepartmentname = "";
            int newworkerlimit = 0;
            double newsalarylimit = 0;
            bool oldloop = true;
            bool departmentnameloop = true;
            bool workerlimitloop = true;
            bool salarylimitloop = true;
            Console.WriteLine("Deyisdirmek istediyiniz Departmentin adin daxil edin.");
            while (oldloop)
            {
                try
                {
                    olddepartmentname = Console.ReadLine();
                    Department department123 = humanResourceManager.departments.Find(x => x.Name == olddepartmentname);
                    if (department123 != null)
                    {
                        Console.WriteLine($"{department123.Name} {department123.WorkerLimit} {department123.SalaryLimit}");
                        Console.WriteLine("Departmentin yeni adin daxil edin.");
                        while (departmentnameloop)
                        {
                            try
                            {
                                newdepartmentname = Console.ReadLine();
                                if (string.IsNullOrEmpty(newdepartmentname) == false && newdepartmentname.Length >= 2)
                                {
                                    department123.Name = newdepartmentname;
                                    departmentnameloop = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Duzgun yeni ad daxil edin.");
                            }

                        }
                        Console.WriteLine("Departmentin yeni workerlimitin daxil edin.");
                        while (workerlimitloop)
                        {
                            try
                            {
                                newworkerlimit = int.Parse(Console.ReadLine());
                                if (newworkerlimit >= 2)
                                {
                                    department123.WorkerLimit = newworkerlimit;
                                    workerlimitloop = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Duzgun yeni workerlimit daxil edin.");
                            }
                        }
                        Console.WriteLine("Yeni SalaryLimit daxil edin.");
                        while (salarylimitloop)
                        {
                            try
                            {
                                newsalarylimit = double.Parse(Console.ReadLine());
                                if (newsalarylimit >= 250)
                                {
                                    department123.SalaryLimit = newsalarylimit;
                                    salarylimitloop = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Duzgun Yeni salarylimit daxil edin.");
                            }
                        }                       
                        oldloop = false;

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun Departmentin adin daxil edin.");
                }

            }
            
           
        }
        public static void ShowEmployees(HumanResourceManager humanResourceManager)
        {
            foreach (Department item in humanResourceManager.departments)
            {
                foreach (Employee employee in item.Employees)
                {
                    Console.WriteLine($"{employee.No},{employee.Fullname},{employee.DepartmentName},{employee.Salary}");
                }
            }
        }
        public static void ShowDepartmentEmployees(HumanResourceManager humanResourceManager)
        {
            
            Console.WriteLine("Iscilerin siyahsini gostermek istediyiniz departmentin adin yazin!!!");
            string departmentname = Console.ReadLine();
            Department department = humanResourceManager.departments.Find(x => x.Name == departmentname);
            try
            {
                foreach (Employee item in department.Employees)
                {
                    Console.WriteLine($"{item.No},{item.Name},{item.Surname},{item.Position},{item.Salary}");
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Department adini duz yazin");
            }
        }
        public static void AddEmployee(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Yeni iscinin adin daxil edin.");
            string newemployeename = Console.ReadLine();
            Console.WriteLine("Yeni iscinin soyadin daxil edin. ");
            string newemployeesurname = Console.ReadLine();
         
            string newemployeeposition = "";
            double newemployeesalary = 0;
            string newemployeedepartmentname = "";
            bool positionloop = true;
            bool salaryloop = true;
            bool departmentnameloop = true;
            Console.WriteLine("Yeni iscinin vezifesini daxil edin.");
            while (positionloop)
            {
                try
                {
                    newemployeeposition = Console.ReadLine();
                    if (string.IsNullOrEmpty(newemployeeposition)==false && newemployeeposition.Length>=2)
                    {
                        positionloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun Yeni iscinin vezifesini daxil edin.");
                }
            }
            Console.WriteLine("Yeni iscinin maasini daxil edin.");
            while (salaryloop)
            {
                try
                {
                    newemployeesalary = double.Parse(Console.ReadLine());
                    if (newemployeesalary>=250)
                    {
                        salaryloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun yeni iscinin maasini daxil edin.");
                }
            }
            Console.WriteLine("Yeni iscinin department adini daxil edin.");
            while (departmentnameloop)
            {
                try
                {
                    newemployeedepartmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(newemployeedepartmentname)==false && newemployeedepartmentname.Length>=2)
                    {
                        Department department = humanResourceManager.departments.Find(x => x.Name == newemployeedepartmentname);
                        if (department!=null)
                        {
                            Employee newemployee = new Employee(newemployeename, newemployeesurname, newemployeeposition, newemployeesalary, department.Name);
                            department.Employees.Add(newemployee);
                            //humanResourceManager.departments.Add(department);
                        }                      
                    }
                    else
                    {
                        throw new Exception();
                    }
                    departmentnameloop = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun yeni iscinin department adini daxil edin.");
                }
            }
            
        }
        public static void EditEmployeea(HumanResourceManager humanResourceManager)
        {
            bool noloop = true;
            bool newsalaryloop = true;
            bool newpositionloop = true;
            string editno = "";
            double newsalary = 0;
            string newposition = "";
            Console.WriteLine("Deyismek istediyiniz iscinin Nomresin yazin");
            while (noloop)
            {
                try
                {
                    editno = Console.ReadLine();
                    foreach (Department item in humanResourceManager.departments)
                    {
                        Employee currentemployee = item.Employees.Find(x => x.No == editno);
                        if (currentemployee!=null)
                        {
                            Console.WriteLine($"{currentemployee.Fullname},{currentemployee.Salary},{currentemployee.Position}");
                            Console.WriteLine("Iscinin yeni maasini daxil edin.");
                            while (newsalaryloop)
                            {
                                try
                                {
                                    newsalary = double.Parse(Console.ReadLine());
                                    if (newsalary>=250)
                                    {
                                        currentemployee.Salary = newsalary;
                                        newsalaryloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine(" iscinin yeni maasini Duzgun daxil edin.");
                                }
                            }
                            Console.WriteLine("Iscinin yeni vezifesini daxil edin.");
                            while (newpositionloop)
                            {
                                try
                                {
                                    newposition = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newposition)==false && newposition.Length>=2)
                                    {
                                        currentemployee.Position = newposition;
                                        newpositionloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Iscinin yeni vezifesini Duzgun wdaxil edin.");
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun Nomre daxil edin.");
                }
                noloop = false;
            }

        }
        public static void RemoveEmployee(HumanResourceManager humanResourceManager)
        {
            string departmentname = "";
            string employeeno = "";
            bool nameloop = true;
            bool noloop = true;
            Console.WriteLine("departmentin adin daxil edin");
            while (nameloop)
            {
                try
                {
                    departmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(departmentname)==false && departmentname.Length>=2)
                    {
                      Department removedepartment = humanResourceManager.departments.Find(x => x.Name == departmentname);
                        Console.WriteLine("Ishcinin nomresini yazin");
                        while (noloop)
                        {
                            try
                            {
                                employeeno = Console.ReadLine();
                                foreach (Department item in humanResourceManager.departments)
                                {
                                    Employee removeemploye = item.Employees.Find(x => x.No == employeeno);
                                    if (removeemploye != null)
                                    {
                                        removedepartment.Employees.Remove(removeemploye);
                                        noloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Duzgun nomre daxil edin.");
                            }
                        }
                        nameloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Department adin duzgun daxil edin.");
                }
            }          

        }

    }
}
