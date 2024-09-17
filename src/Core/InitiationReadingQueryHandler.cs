namespace Paraminter.Processors;

using Paraminter.Cqs;
using Paraminter.Processors.Queries;

/// <summary>Handles queries by reading the initiation status of the process of associating arguments with parameters.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
public sealed class InitiationReadingQueryHandler<TQuery>
    : IQueryHandler<TQuery, bool>
    where TQuery : IQuery
{
    private readonly IQueryHandler<IIsProcessArgumentAssociationsInitiatedQuery, bool> InitiationReader;

    /// <summary>Instantiates a query-handler which reads the initiation status of the process of associating arguments with parameters.</summary>
    /// <param name="initiationReader">Reads the initiation status of the process of associating arguments with parameters.</param>
    public InitiationReadingQueryHandler(
        IQueryHandler<IIsProcessArgumentAssociationsInitiatedQuery, bool> initiationReader)
    {
        InitiationReader = initiationReader ?? throw new System.ArgumentNullException(nameof(initiationReader));
    }

    bool IQueryHandler<TQuery, bool>.Handle(
        TQuery query)
    {
        if (query is null)
        {
            throw new System.ArgumentNullException(nameof(query));
        }

        return InitiationReader.Handle(IsProcessArgumentAssociationsInitiatedQuery.Instance);
    }
}
