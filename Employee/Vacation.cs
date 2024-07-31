// Import necessary namespaces
using System;
using System.Threading;

namespace Employee
{
    // Define the Vacation class within the Employee namespace
    public class Vacation
    {
        // Private properties for start and end dates of the vacation, count of days, employee hardware, and employee
        private DateTime _startDate { get; set; }
        private DateTime _endDate;
        private int _countOfDay;
        private EmployeeHardware _employeeHardware;
        private Employee _employee;
        private int year, month, day;

        // Constructor to initialize the Vacation object with an employee and employee hardware
        public Vacation(Employee employee, EmployeeHardware employeeHardware)
        {
            _employee = employee;
            _employeeHardware = employeeHardware;
        }

        // Method to prompt the user for a date input
        public void UserPrompt(string message, out DateTime date)
        {
            // Display the employee's profile header
            Console.WriteLine($"******************** {_employee.EmployeeName} Profile *********************");

            // Prompt for the year
            _employeeHardware.MessageField($"{message} year:");
            year = Convert.ToInt32(Console.ReadLine());

            // Prompt for the month
            _employeeHardware.MessageField($"{message} month:");
            month = Convert.ToInt32(Console.ReadLine());

            // Prompt for the day
            _employeeHardware.MessageField($"{message} day:");
            day = Convert.ToInt32(Console.ReadLine());

            // Create a DateTime object with the entered year, month, and day
            date = new DateTime(year, month, day);
        }

        // Method to handle the vacation process
        public void UserVacation()
        {
            // Prompt the user for the start date of the vacation
            UserPrompt("Please enter the ", out var travelDate);
            _startDate = travelDate;

            // Inform the user to enter the return date
            _employeeHardware.MessageField("Now I'll ask you to enter the day of coming back from the trip...");

            // Prompt the user for the end date of the vacation
            UserPrompt("Please enter the ", out var comingDate);
            _endDate = comingDate;

            // Confirm the vacation addition
            _employeeHardware.MessageField("Added successfully");
            VacationInfo();
        }

        // Method to display vacation information and countdown
        public void VacationInfo()
        {
            // Calculate the total days of the vacation
            _countOfDay = (_endDate - _startDate).Days;

            // Display the vacation details
            _employeeHardware.MessageField($"""
                                            Start date of trip is: {_startDate}
                                            Coming back date is: {_endDate}
                                            Your vacation total time is {_countOfDay} days. Have a nice trip!
                                            """);

            // Start countdown to return to work
            _employeeHardware.MessageField("Starting counting days... ");

            for (int i = _countOfDay; i > 0; i--)
            {
                // Display the remaining days
                _employeeHardware.MessageField(i + " days left to return back.");
                Thread.Sleep(2000); // Wait for 2 seconds before the next iteration
            }

            // Inform the user that the vacation is over
            _employeeHardware.MessageField("Your time has ended, come back to work!");
        }

        // Method to select an employee for the vacation
        public void SelectEmployee()
        {
            int employeeChoice = 0;
            int i = 0;

            // Prompt the user to select an employee
            _employeeHardware.MessageField("Please select the employee");

            // List all employees
            for (i = 0; i < _employeeHardware.myEmployeesList.Count; i++)
            {
                var employee = _employeeHardware.myEmployeesList[i];
                Console.WriteLine($"{i + 1}: {employee.EmployeeName}");
            }

            // Get user input for employee selection and validate it
            if (int.TryParse(Console.ReadLine(), out employeeChoice) && employeeChoice > 0 && employeeChoice <= _employeeHardware.myEmployeesList.Count)
            {
                // Set the selected employee
                _employee = _employeeHardware.myEmployeesList[employeeChoice - 1];
                UserVacation();
            }
            else
            {
                // Handle invalid selection and retry
                _employeeHardware.MessageField("Invalid selection. Please try again.");
                SelectEmployee(); // Recursive call to retry selection
            }
        }
    }
}
