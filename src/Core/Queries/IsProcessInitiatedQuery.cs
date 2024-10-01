namespace Paraminter.Processing.Queries;

internal sealed class IsProcessInitiatedQuery
    : IIsProcessInitiatedQuery
{
    public static IIsProcessInitiatedQuery Instance { get; } = new IsProcessInitiatedQuery();

    private IsProcessInitiatedQuery() { }
}
