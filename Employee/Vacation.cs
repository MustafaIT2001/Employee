using System;
using System.Threading;

namespace Employee
{
    public class Vacation
    {
        private DateTime _startDate { get; set; }
        private DateTime _endDate;
        private int _countOfDay;
        private EmployeeHardware _employeeHardware;
        private Employee _employee;
        private int year, month, day;

        public Vacation(Employee employee, EmployeeHardware employeeHardware)
        {
            _employee = employee;
            _employeeHardware = employeeHardware;
        }

        public void UserPrompt(string message, out DateTime date)
        {

            Console.WriteLine($"******************** {_employee.EmployeeName} Profile *********************");

            _employeeHardware.MessageField($"{message} year:");
            year = Convert.ToInt32(Console.ReadLine());

            _employeeHardware.MessageField($"{message} month:");
            month = Convert.ToInt32(Console.ReadLine());

            _employeeHardware.MessageField($"{message} day:");
            day = Convert.ToInt32(Console.ReadLine());

            date = new DateTime(year, month, day);
        }

        public void UserVacation()
        {
            UserPrompt("Please enter the ", out var travelDate);
            _startDate = travelDate;
            
            _employeeHardware.MessageField("Now I'll ask you to enter the day of coming back from the trip...");
            
            UserPrompt("Please enter the ", out var comingDate);
            _endDate = comingDate;

            _employeeHardware.MessageField("Added successfully");
            VacationInfo();
        }
        

        public void VacationInfo()
        {
            _countOfDay = (_endDate - _startDate).Days;

            _employeeHardware.MessageField($"""
                                            Start date of trip is: {_startDate}
                                            Coming back date is: {_endDate}
                                            Your vacation total time is {_countOfDay} days. Have a nice trip!
                                            """);

            _employeeHardware.MessageField("Starting counting days... ");

            for (int i = _countOfDay; i > 0; i--)
            {
                _employeeHardware.MessageField(i + " days left to return back.");
                Thread.Sleep(2000);
            }

            _employeeHardware.MessageField("Your time has ended, come back to work!");
        }

        public void SelectEmployee()
        {
            int employeeChoice = 0;
            int i = 0;

            _employeeHardware.MessageField("Please select the employee");

            for (i = 0; i < _employeeHardware.myEmployeesList.Count; i++)
            {
                var employee = _employeeHardware.myEmployeesList[i];
                Console.WriteLine($"{i + 1}: {employee.EmployeeName}");
            }

            if (int.TryParse(Console.ReadLine(), out employeeChoice) && employeeChoice > 0 && employeeChoice <= _employeeHardware.myEmployeesList.Count)
            {
                _employee = _employeeHardware.myEmployeesList[employeeChoice - 1];
                UserVacation();
            }
            else
            {
                _employeeHardware.MessageField("Invalid selection. Please try again.");
                SelectEmployee(); // Recursive call to retry selection
            }
        }
    }
}
