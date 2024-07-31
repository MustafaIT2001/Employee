// Define the namespace for the EmployeeHardware class
namespace Employee
{
    // Define the EmployeeHardware class within the Employee namespace
    public class EmployeeHardware
    {
        // Private fields to store day, month, year, vacation, and employee instances
        private int day, month, year;
        private Vacation _vacation;
        private Employee _employee;

        // Private fields to store employee address and date of birth
        private string employeeAddress, employeeDateOfBirth;

        // Public list to store the list of employees
        public List<Employee> myEmployeesList;

        // Public field for employee name
        public string employeeName;

        // Private fields to store employee age and salary
        private byte employeeAge;
        private int employeeSalary;

        // Constructor to initialize the EmployeeHardware object
        public EmployeeHardware()
        {
            myEmployeesList = new List<Employee>();
        }

        // Main method to start the application
        static void Main()
        {
            EmployeeHardware employeeHardware = new EmployeeHardware();
            employeeHardware.MessageField("Hello and welcome to my employee application!!");
            employeeHardware.MessageField("Please sign up to get started...");
            employeeHardware.UserInfo();
        }

        // Method to gather user information and create an employee profile
        void UserInfo()
        {
            _employee = new Employee();

            MessageField("Please enter your name");
            employeeName = Console.ReadLine();

            MessageField("Please enter your age");
            if (!byte.TryParse(Console.ReadLine(), out employeeAge))
            {
                MessageField("Invalid age. Please enter a valid number.");
                return;
            }

            MessageField("Please enter your salary");
            if (!int.TryParse(Console.ReadLine(), out employeeSalary) || employeeSalary <= 2000)
            {
                MessageField("Invalid salary. Salary must be a number greater than 2000.");
                return;
            }

            MessageField("Please enter your address");
            employeeAddress = Console.ReadLine();

            MessageField("Now please enter your date of birth in this format (mm-dd-yyyy)");

            // Loop to validate the date of birth input
            while (true)
            {
                employeeDateOfBirth = Console.ReadLine();

                if (DateTime.TryParseExact(employeeDateOfBirth, "MM-dd-yyyy", null,
                    System.Globalization.DateTimeStyles.None, out _))
                    break;
                else
                {
                    MessageField("Invalid input. Please enter the date in the correct format (mm-dd-yyyy).");
                }
            }

            // Create a new Employee object with the gathered information
            _employee = new Employee(employeeName, employeeAge, employeeSalary, employeeDateOfBirth)
            {
                EmployeeAddress = employeeAddress,
                EmployeeName = employeeName,
                EmployeeHardware = this // Set the EmployeeHardware instance
            };
            myEmployeesList.Add(_employee);

            MessageField("You signed up successfully.");
            MessageField("Please choose the first option if you would like to see your profile.");

            EmployeeOptions();
        }

        // Method to display and handle employee options
        void EmployeeOptions()
        {
            byte userChoice = 0;
            bool isConverted = true;

            // Loop to continually prompt the user for options
            while (true)
            {
                MessageField("""
                             Please choose one of the following...
                             1: Employee's profile
                             2: Go for a vacation
                             3: Add Another Employee
                             4: Access my benefits
                             5: Exit
                             """);

                isConverted = byte.TryParse(Console.ReadLine(), out userChoice);

                if (isConverted)
                {
                    // Handle user choice using a switch statement
                    switch (userChoice)
                    {
                        case 1:
                            EmployeeInfo();
                            break;
                        case 2:
                            AddVacation();
                            break;
                        case 3:
                            UserInfo();
                            break;
                        case 4:
                            AccessBenefits();
                            break;
                        case 5:
                            MessageField("Thank you for trying my program. Have a wonderful day!");
                            Environment.Exit(0);
                            break;
                        default:
                            MessageField("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    MessageField("Invalid input. Please enter a number.");
                }
            }
        }

        // Method to access and display employee benefits
        void AccessBenefits()
        {
            _employee.Benefits = new Benefits();

            _employee.Benefits.Print();
        }

        // Method to display employee information
        void EmployeeInfo()
        {
            if (myEmployeesList.Count == 0)
            {
                MessageField("No Profile to show.");
                return;
            }

            _employee.PrintEmployeeDetails();
        }

        // Method to add a vacation for an employee
        void AddVacation()
        {
            _vacation = new Vacation(_employee, this);
            _vacation.SelectEmployee();
        }

        // Method to display a message field with a border
        public void MessageField(string message)
        {
            Console.WriteLine("*******************************");
            Console.WriteLine(message);
            Console.WriteLine("*******************************");
        }
    }
}
