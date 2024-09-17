namespace Paraminter.Processors;

using Paraminter.Cqs;
using Paraminter.Processors.Queries;

/// <summary>Handles queries by reading the completion status of the process of associating arguments with parameters.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
public sealed class CompletionReadingQueryHandler<TQuery>
    : IQueryHandler<TQuery, bool>
    where TQuery : IQuery
{
    private readonly IQueryHandler<IIsProcessArgumentAssociationsCompletedQuery, bool> CompletionReader;

    /// <summary>Instantiates a query-handler which reads the completion status of the process of associating arguments with parameters.</summary>
    /// <param name="completionReader">Reads the completion status of the process of associating arguments with parameters.</param>
    public CompletionReadingQueryHandler(
        IQueryHandler<IIsProcessArgumentAssociationsCompletedQuery, bool> completionReader)
    {
        CompletionReader = completionReader ?? throw new System.ArgumentNullException(nameof(completionReader));
    }

    bool IQueryHandler<TQuery, bool>.Handle(
        TQuery query)
    {
        if (query is null)
        {
            throw new System.ArgumentNullException(nameof(query));
        }

        return CompletionReader.Handle(IsProcessArgumentAssociationsCompletedQuery.Instance);
    }
}
