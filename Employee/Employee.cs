// Define the namespace for the Employee class
namespace Employee
{
    // Define the Employee class within the Employee namespace
    public class Employee
    {
        // Private field to store employee's salary
        private double _employeeSalary;

        // Public property to get and set employee's salary
        public double EmployeeSalary
        {
            get { return _employeeSalary; }
            set
            {
                // Check if the salary is greater than 2000
                if (value > 2000.00)
                {
                    // Set the employee's salary
                    _employeeSalary = value;

                    // Divide the salary by 20 (possibly a 20% reduction)
                    _employeeSalary /= 20.00;
                }
                else
                {
                    // Handle the case where the salary is not set due to being <= 2000
                    Console.WriteLine("Salary must be greater than 2000.");
                }
            }
        }

        // Private field to store employee's name
        private string employeeName;

        // Public property to get and set employee's name
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        // Public property to get and set employee's age
        public byte EmployeeAge { get; set; }

        // Private field to store employee's address
        private string employeeAddress;

        // Public property to get and set employee's address
        public string EmployeeAddress
        {
            get { return employeeAddress; }
            set { employeeAddress = value; }
        }

        // Private field to store employee's date of birth
        private string employeeDateOfBirth;

        // Public property to get and set employee's date of birth
        public string EmployeeDateOfBirth
        {
            get { return employeeDateOfBirth; }
            set { employeeDateOfBirth = value; }
        }

        // Public property to get and set the list of vacations for the employee
        public List<Vacation> VacationsList { get; set; }

        // Public property to get and set the list of benefits for the employee
        public List<Benefits> BenefitsList { get; set; }

        // Public property to get and set the hardware assigned to the employee
        public EmployeeHardware EmployeeHardware { get; set; }

        // Public field for benefits (not used in the code, might be for future use)
        public Benefits Benefits;

        // Default constructor initializes the employee with default values
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

        // Parameterized constructor to initialize the employee with specific values
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

        // Copy constructor to initialize the employee based on another employee object
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

        // Method to print the details of the employee
        public void PrintEmployeeDetails()
        {
            // Loop through each employee profile in the EmployeeHardware list
            foreach (var employeeProf in EmployeeHardware.myEmployeesList)
            {
                // Print the employee profile details
                Console.WriteLine($"******************** {employeeProf.employeeName} Profile *********************");
                Console.WriteLine($"""
                                    Name: {employeeProf.employeeName}
                                    Age: {employeeProf.EmployeeAge}
                                    Date of birth: {employeeProf.employeeDateOfBirth}
                                    Address: {employeeProf.EmployeeAddress}
                                    Salary: Gross Pay after 20% Deduction {employeeProf.EmployeeSalary}
                                  """);
                Console.WriteLine("--------------------------------------------------------------");

                // Print a separator line for readability
                Console.WriteLine($"******************** {employeeProf.employeeName} Profile *********************\n");
            }
        }
    }
}
