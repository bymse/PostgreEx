namespace PostgreEx.Core.Statistics;

public record RelPages(int Count)
{
    public static implicit operator int(RelPages pages) => pages.Count;
}
