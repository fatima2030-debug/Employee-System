using System;
using System.Linq;
using System.Text;

public abstract class Employee
{
    public int Id { get; }

    private string _name;
    public string Name
    {
        get => _name;
        set => _name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Name cannot be null or empty.");
    }

    public string Department { get; set; }

    private decimal _baseSalary;
    public decimal BaseSalary
    {
        get => _baseSalary;
        set => _baseSalary = value >= 0 ? value : throw new ArgumentException("Base Salary must be 0 or greater.");
    }

    protected Employee(int id, string name, string department, decimal baseSalary)
    {
        Id = id;
        Name = name;
        Department = department;
        BaseSalary = baseSalary;
    }

    public abstract decimal CalculateMonthlyPay();

    public virtual string GetEmployeeInfo() => $"ID: {Id} | Name: {Name} | Dept: {Department}";
}