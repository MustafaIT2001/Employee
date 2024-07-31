namespace Employee
{
    public class EmployeeHardware
    {
        private int day, month, year;
        private Vacation _vacation;
        private Employee _employee;

        private string employeeAddress, employeeDateOfBirth;
        public List<Employee> myEmployeesList;
        public String employeeName;

        private byte employeeAge;
        private int employeeSalary;

        public EmployeeHardware()
        {
            myEmployeesList = new List<Employee>();
        }

        static void Main()
        {
            EmployeeHardware employeeHardware = new EmployeeHardware();
            employeeHardware.MessageField("Hello and welcome to my employee application!!");
            employeeHardware.MessageField("Please sign up to get started...");
            employeeHardware.UserInfo();
        }

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
            employeeDateOfBirth = Console.ReadLine();

            while (true)
            {
                
                if (!DateTime.TryParseExact(employeeDateOfBirth, "MM-dd-yyyy", null,
                    System.Globalization.DateTimeStyles.None, out _))
                    break;
            {
                MessageField("Invalid input. Please enter the date in the correct format (mm-dd-yyyy).");
            }
            }

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

        void EmployeeOptions()
        {
            byte userChoice = 0;
            bool isConverted = true;

            while (true)
            {
                MessageField("""
                             Please choose one of the following...
                             1: Your profile
                             2: Go for vacation
                             3: Add Another Employee
                             4: Access my benefits
                             5: Exit
                             """);

                isConverted = byte.TryParse(Console.ReadLine(), out userChoice);

                if (isConverted)
                {
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
                            MessageField("Thankyou for trying my program. Have a wonderful day!");
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

        void AccessBenefits()
        {
            _employee.Benefits = new Benefits();
            
            _employee.Benefits.Print();

        }

        void EmployeeInfo()
        {
            if (myEmployeesList.Count == 0)
            {
                MessageField("No Profile to show.");
                return;
            }

            _employee.PrintEmployeeDetails();
        }

        void AddVacation()
        {
            _vacation = new Vacation(_employee, this);
            _vacation.SelectEmployee();
            
        }

        public void MessageField(string message)
        {
            Console.WriteLine("*******************************");
            Console.WriteLine(message);
            Console.WriteLine("*******************************");
        }
    }
}
