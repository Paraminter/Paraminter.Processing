namespace Paraminter.Processing.Queries;

internal sealed class IsProcessCompletedQuery
    : IIsProcessCompletedQuery
{
    public static IIsProcessCompletedQuery Instance { get; } = new IsProcessCompletedQuery();

    private IsProcessCompletedQuery() { }
}
