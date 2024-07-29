// See https://aka.ms/new-console-template for more information
namespace Employee;
class Employee
{
    private int employeeSalary;

    public int EmployeeSalary
    {
        get
        {
            return employeeSalary;
        }

        set
        {
            if (value > 0)
            {
                employeeSalary = value;
            }
        }
    }
    
    public String employeeName { get; }
    
    public byte EmployeeAge { get; }
    
    private String employeeAdress { get; }
    
    public int dateOfBirth { get; set; }

    public List<Vacation> VacationsList { get; set;}
    public List<Deduction> DeductionsList { get; set;}
    public List<Benefits> BenefitsList { get; set; }
    
    // starting with default constructor
    public Employee()
    {
        employeeName = "";
        EmployeeAge = 0;
        employeeSalary = 0;
        employeeAdress = "";
        dateOfBirth = 0;

        VacationsList = new List<Vacation>();
        DeductionsList = new List<Deduction>();
        BenefitsList = new List<Benefits>();

    }
    
    // parameterized Constructor.
    public Employee(String employeeName, byte employeeAge, int employeeSalary)
    {
        this.employeeName = employeeName;
        EmployeeAge = employeeAge;
        EmployeeSalary = employeeSalary;
    }
    
    // copy constructor
    public Employee(Employee myEmployees)
    {
        employeeName = myEmployees.employeeName;
        EmployeeAge = myEmployees.EmployeeAge;
        EmployeeSalary = myEmployees.employeeSalary;
    }

}