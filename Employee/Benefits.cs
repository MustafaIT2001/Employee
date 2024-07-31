// Define the namespace for the Benefits class
namespace Employee
{
    // Define the Benefits class within the Employee namespace
    public class Benefits
    {
        // Public properties for benefits and reward
        public string benefits { get; set; }
        public string reward { get; set; }

        // Private field for the default health care value
        private double healthCare = 90.00;

        // Read-only property to get the health care plan
        private double healthCarePlan
        {
            get { return healthCare; }
        }

        // Private field for the Employee instance
        private Employee _employee;

        // Private property for the employee reward
        private int employeeReward { get; set; }

        // Method to print the benefits information and prompt the user for changes
        public void Print()
        {
            char myChar = ' ';
            benefits = "Open Buffet"; // Default benefit

            // Prompt the user to change the default benefit
            Console.WriteLine(
                $"We have a {benefits} as a default option. Would you like to change it? (y - YES n - NO)");

            myChar = Convert.ToChar(Console.ReadLine());

            if (myChar == 'y')
            {
                // Allow the user to input a new benefit
                Console.WriteLine("Please choose the benefits you like");
                benefits = Console.ReadLine();
                Console.WriteLine(benefits + " Added successfully.");
            }

            // Loop to prompt the user about their job performance
            while (true)
            {
                Console.WriteLine("Have you been doing your job seriously? press either (y or n)");

                myChar = Convert.ToChar(Console.ReadLine());

                if (myChar == 'y')
                {
                    // Assign reward based on job performance
                    reward = "Rewarded to Technical Consultant field";
                    break;
                }

                if (myChar == 'n')
                {
                    // Assign reward based on lack of job performance
                    reward = "Still basic developer";
                    break;
                }

                // Handle invalid input
                Console.WriteLine("Invalid input. Please try again");
            }

            // Display the benefits, health care plan, and reward information
            Console.WriteLine($"""
                               Benefit is {benefits}
                               Health care is {healthCarePlan}
                               Reward is {reward}
                               """);
        }
    }
}
