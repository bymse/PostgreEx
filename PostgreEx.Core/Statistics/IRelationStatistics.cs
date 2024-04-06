namespace PostgreEx.Core.Statistics;

public interface IRelationStatistics
{
    Task<RelPages> GetRelPages(string relationName);
    Task<RelTuples> GetRelTuples(string relationName);
}