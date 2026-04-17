using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
    
namespace PayrollSystem;
    public  class InvalidPerformanceScoreExecption : Exception
    {
       public InvalidPerformanceScoreExecption() : base("Performance score must be between 0 and 10.") { }
       public InvalidPerformanceScoreExecption(string message) : base(message) { }
    }
    public enum Department {
    Operations,
    Finance,
    IT,
    HR
}
    public interface IBonusable
    {
    decimal CalculateBonus(int performanceScore);
    }

public abstract class Employee
{
    public int Id { get; }
    public string Name { get; set; }
    public Department Dept { get; set; }
    public decimal BaseSalary { get; set; }

    protected Employee(int id, string name, Department dept, decimal baseSalary)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
        if (baseSalary < 0) throw new ArgumentException("Base salary cannot be negative.");

        Id = id;
        Name = name;
        Dept = dept;
        BaseSalary = baseSalary;
    }

    public abstract decimal CalculateMonthlyPay();

    public virtual string GetEmployeeInfo() =>
        $"ID: {Id} | Name: {Name} | Dept: {Dept} | Type: {this.GetType().Name}";

    public override string ToString() => GetEmployeeInfo();
}

public class FullTimeEmployee : Employee, IBonusable
{
    public FullTimeEmployee(int id, string name, Department dept, decimal baseSalary)
        : base(id, name, dept, baseSalary) { }

    public override decimal CalculateMonthlyPay() => BaseSalary;

    public decimal CalculateBonus(double score)
    {
        if (score < 0 || score > 10) throw new InvalidPerformanceScoreException();
        return BaseSalary * (decimal)(score / 10);
    }

    public decimal CalculateBonus(int performanceScore)
    {
        throw new NotImplementedException();
    }
}
public class PartTimeEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public PartTimeEmployee(int id, string name, Department dept, decimal hourlyRate, int hours)
        : base(id, name, dept, 0)
    {
        if (hours < 0 || hours > 300) throw new ArgumentException("Hours must be between 0 and 300.");
        HourlyRate = hourlyRate;
        HoursWorked = hours;
    }
    public override decimal CalculateMonthlyPay() => HourlyRate * HoursWorked;
}
public class Contractors : Employee
{
    public decimal ContractAmount { get; set; }

    public Contractors(int id, string name, Department dept, decimal contractAmount)
        : base(id, name, dept, 0)
    {
        ContractAmount = contractAmount;
    }

    public override decimal CalculateMonthlyPay() => ContractAmount;
}

public enum Departments { IT, HR, Finance, Operations }

public interface IBounces
{
    decimal CalculateBonus(double performanceScore);
}

public class InvalidPerformanceScoreException : Exception
{
    public InvalidPerformanceScoreException() : base("Score must be between 0 and 10.") { }
    public InvalidPerformanceScoreException(string message) : base(message) { }
}
public struct PaySlip
{
    public Employee Employee;
    public decimal GrossPay;
    public DateTime PayDate;
    public string PayPeriod;

    public void PrintPaySlip()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"PAY SLIP - {PayPeriod}");
        Console.WriteLine($"Date: {PayDate.ToShortDateString()}");
        Console.WriteLine(Employee.GetEmployeeInfo());
        Console.WriteLine($"Total Gross Pay: {GrossPay:C}");
        Console.WriteLine("------------------------------------\n");
    }

}