namespace Paraminter.Processing;

using Paraminter.Processing.Queries;

using System.Threading;
using System.Threading.Tasks;

/// <summary>Handles queries by reading the completion status.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public sealed class ProcessCompletionReadingQueryHandler<TQuery, TResponse>
    : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery
{
    private readonly IQueryHandler<IIsProcessCompletedQuery, TResponse> CompletionReader;

    /// <summary>Instantiates a query-handler which reads the completion status.</summary>
    /// <param name="completionReader">Reads the completion status.</param>
    public ProcessCompletionReadingQueryHandler(
        IQueryHandler<IIsProcessCompletedQuery, TResponse> completionReader)
    {
        CompletionReader = completionReader ?? throw new System.ArgumentNullException(nameof(completionReader));
    }

    async Task<TResponse> IQueryHandler<TQuery, TResponse>.Handle(
        TQuery query,
        CancellationToken cancellationToken)
    {
        if (query is null)
        {
            throw new System.ArgumentNullException(nameof(query));
        }

        return await CompletionReader.Handle(IsProcessCompletedQuery.Instance, cancellationToken).ConfigureAwait(false);
    }
}
