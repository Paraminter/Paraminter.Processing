namespace Paraminter.Processors.Queries;

internal sealed class IsProcessArgumentAssociationsInitiatedQuery
    : IIsProcessArgumentAssociationsInitiatedQuery
{
    public static IIsProcessArgumentAssociationsInitiatedQuery Instance { get; } = new IsProcessArgumentAssociationsInitiatedQuery();

    private IsProcessArgumentAssociationsInitiatedQuery() { }
}
