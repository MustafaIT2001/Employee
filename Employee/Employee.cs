namespace Employee
{
    public class Employee
    {
        private double _employeeSalary;

        public double EmployeeSalary
        {
            get { return _employeeSalary; }
            set
            {
                if (value > 2000.00)
                {
                    
                    _employeeSalary = value;

                    _employeeSalary /= 20.00;
                    
                }
                else
                {
                    // Handle the case where the salary is not set due to being <= 2000
                    Console.WriteLine("Salary must be greater than 2000.");
                }
            }
        }

        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        public byte EmployeeAge { get; set; }
        private string employeeAddress;

        public string EmployeeAddress
        {
            get { return employeeAddress; }
            set { employeeAddress = value; }
        }

        private string employeeDateOfBirth;

        public string EmployeeDateOfBirth
        {
            get { return employeeDateOfBirth; }
            set { employeeDateOfBirth = value; }
        }

        public List<Vacation> VacationsList { get; set; }
        public List<Benefits> BenefitsList { get; set; }
        public EmployeeHardware EmployeeHardware { get; set; }

        public Benefits Benefits;
        // Default constructor
        public Employee()
        {
            EmployeeName = "";
            EmployeeAge = 0;
            EmployeeSalary = 1000;
            EmployeeAddress = "";
            VacationsList = new List<Vacation>();
            BenefitsList = new List<Benefits>();
            EmployeeHardware = new EmployeeHardware();
            }

        // Parameterized Constructor
        public Employee(string employeeName, byte employeeAge, int employeeSalary, string employeeDateOfBirth)
        {
            EmployeeName = employeeName;
            EmployeeAge = employeeAge;
            EmployeeSalary = employeeSalary;
            EmployeeDateOfBirth = employeeDateOfBirth;
            EmployeeAddress = ""; // Assuming it's not passed in constructor
            VacationsList = new List<Vacation>();
            BenefitsList = new List<Benefits>();
            EmployeeHardware = new EmployeeHardware();
        }

        // Copy constructor
        public Employee(Employee myEmployee)
        {
            EmployeeName = myEmployee.EmployeeName;
            EmployeeAge = myEmployee.EmployeeAge;
            EmployeeSalary = myEmployee.EmployeeSalary;
            EmployeeAddress = myEmployee.EmployeeAddress;
            EmployeeDateOfBirth = myEmployee.EmployeeDateOfBirth;
            VacationsList = new List<Vacation>(myEmployee.VacationsList);
            BenefitsList = new List<Benefits>(myEmployee.BenefitsList);
            EmployeeHardware = myEmployee.EmployeeHardware;
        }

        public void PrintEmployeeDetails()
        {
            foreach (var employeeProf in EmployeeHardware.myEmployeesList)
            {
                Console.WriteLine($"******************** {employeeProf.employeeName} Profile *********************");
                Console.WriteLine($"""
                                    Name: {employeeProf.employeeName}
                                    Age: {employeeProf.EmployeeAge}
                                    Date of birth: {employeeProf.employeeDateOfBirth}
                                    Address: {employeeProf.EmployeeAddress}
                                    Salary: Gross Pay after 20% Deduction {EmployeeSalary}
                                  """);
                Console.WriteLine("--------------------------------------------------------------");
                
                Console.WriteLine($"******************** {employeeProf.employeeName} Profile *********************");
            }
        }
    }
}