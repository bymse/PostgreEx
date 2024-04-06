using System.Linq.Expressions;
using PostgreEx.Core.Costs;

namespace PostgreEx.Core.Explanation.Costs;

public abstract class CostExplanation
{
    public abstract Expression<Func<Cost>> NodeCost { get; }
    public abstract Expression<Func<Cost>> StartupCost { get; }
}