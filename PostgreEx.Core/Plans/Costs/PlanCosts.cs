namespace PostgreEx.Core.Costs;

public class PlanCosts
{
    public Cost StartupCost { get; }
    public Cost TotalCost { get; }

    public PlanCosts(Cost startupCost, Cost totalCost)
    {
        if (startupCost > totalCost)
        {
            throw new ArgumentException("Startup cost must be less than or equal to total cost.");
        }

        StartupCost = startupCost;
        TotalCost = totalCost;
    }
}