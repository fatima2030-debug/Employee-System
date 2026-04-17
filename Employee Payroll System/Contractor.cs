using PayrollSystem;

internal class Contractor : Employee
{
    private int v1;
    private string v2;
    private object finance;
    private int v3;

    public Contractor(int v1, string v2, object finance, int v3)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.finance = finance;
        this.v3 = v3;
    }
}