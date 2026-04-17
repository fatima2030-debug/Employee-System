using PayrollSystem;

List<Employee> employees = new List<Employee>
        {
            new FullTimeEmployee(1, "James Adeola", Department.IT, 5000),
            new FullTimeEmployee(2, "Bolakale Ojo", Department.HR, 4500),
            new PartTimeEmployee(3, "Fatia Nuru", Department.Operations, 25, 120),
            new PartTimeEmployee(4, "Yemi Adeoti", Department.IT, 30, 80),
            new Contractor(5, "Lola Tobi", Department.Finance, 6000),
            new Contractor(6, "Fiona Binpe", Department.Operations, 5500)
        };

decimal totalPayroll = 0;

foreach (var emp in employees)
{
    decimal monthlyPay = emp.CalculateMonthlyPay();

    if (emp is IBonusable bonusableEmp)
    {
        monthlyPay += GetValidBonus(bonusableEmp, emp.Name);
    }

    totalPayroll += monthlyPay;

    PaySlip slip = new PaySlip
    {
        Employee = emp,
        GrossPay = monthlyPay,
        PayDate = DateTime.Now,
        PayPeriod = "March 2025"
    };

    slip.PrintPaySlip();
}

Console.WriteLine($"Total Monthly Payroll Expenditure: {totalPayroll:C}");
    static decimal GetValidBonus(IBonusable emp, string name)
{
    while (true)
    {
        try
        {
            Console.Write($"Enter performance score (0-10) for {name}: ");
            if (!double.TryParse(Console.ReadLine(), out double score))
                throw new FormatException("Input must be a number.");

            return emp.CalculateBonus((int)score);
        }
        catch (Exception ex) when (ex is InvalidPerformanceScoreException || ex is FormatException)
        {
            Console.WriteLine($"Error: {ex.Message} Please try again.");
        }
    }
}

