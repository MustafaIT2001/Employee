namespace Employee;

public class Benefits
{
    // skill development
    // health care plants.
    // reward

    public String benefits { get; set;}
    
    public String reward { get; set;}

    private double healthCare = 90.00;
    private double healthCarePlan
    {

        get
        {
            return healthCare;
        }
        
    }



    private Employee _employee;
    
    /*
     * Make it as if that person did great in his work than double his income...
     */
    
    private int employeeReward { get; set;}


    public void Print()
    {
        char myChar = ' ';
        benefits = "Open Buffet";
        
        Console.WriteLine($"We have a {benefits} as a default option. Would you like to change it?");

        myChar = Convert.ToChar(Console.ReadLine());

        if (myChar == 'y')
        {
            Console.WriteLine("Please choose the benefits you like");
            benefits = Console.ReadLine();
            Console.WriteLine(benefits + " Added successfully.");
            
        }

        while (true)
        {
            
            Console.WriteLine("Have you been doing your job seriously? press either (y or n)");

        myChar = Convert.ToChar(Console.ReadLine());

        if (myChar == 'y')
        {
            reward = "Rewarded to Technical Consultant field";
            break;
        }

        if (myChar == 'n')
        {
            reward = "Still basic developer";
            break;
        }

        Console.WriteLine("Invalid input. Please try again");

        }


        Console.WriteLine($"""
                               Benefit is {benefits}
                               Health care is {healthCarePlan}
                               Reward is {reward}
                               """);
    }
    
}