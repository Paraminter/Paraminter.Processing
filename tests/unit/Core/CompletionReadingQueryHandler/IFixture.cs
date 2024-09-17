namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Queries;

internal interface IFixture<in TQuery>
    where TQuery : IQuery
{
    public abstract IQueryHandler<TQuery, bool> Sut { get; }

    public abstract Mock<IQueryHandler<IIsProcessArgumentAssociationsCompletedQuery, bool>> CompletionReaderMock { get; }
}
