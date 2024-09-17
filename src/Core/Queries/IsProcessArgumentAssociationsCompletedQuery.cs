namespace Paraminter.Processors.Queries;

internal sealed class IsProcessArgumentAssociationsCompletedQuery
    : IIsProcessArgumentAssociationsCompletedQuery
{
    public static IIsProcessArgumentAssociationsCompletedQuery Instance { get; } = new IsProcessArgumentAssociationsCompletedQuery();

    private IsProcessArgumentAssociationsCompletedQuery() { }
}
