namespace Paraminter.Processing;

using Paraminter.Processing.Queries;

using System.Threading;
using System.Threading.Tasks;

/// <summary>Handles queries by reading the initiation status.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public sealed class ProcessInitiationReadingQueryHandler<TQuery, TResponse>
    : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery
{
    private readonly IQueryHandler<IIsProcessInitiatedQuery, TResponse> InitiationReader;

    /// <summary>Instantiates a query-handler which reads the initiation status.</summary>
    /// <param name="initiationReader">Reads the initiation status.</param>
    public ProcessInitiationReadingQueryHandler(
        IQueryHandler<IIsProcessInitiatedQuery, TResponse> initiationReader)
    {
        InitiationReader = initiationReader ?? throw new System.ArgumentNullException(nameof(initiationReader));
    }

    async Task<TResponse> IQueryHandler<TQuery, TResponse>.Handle(
        TQuery query,
        CancellationToken cancellationToken)
    {
        if (query is null)
        {
            throw new System.ArgumentNullException(nameof(query));
        }

        return await InitiationReader.Handle(IsProcessInitiatedQuery.Instance, cancellationToken).ConfigureAwait(false);
    }
}
