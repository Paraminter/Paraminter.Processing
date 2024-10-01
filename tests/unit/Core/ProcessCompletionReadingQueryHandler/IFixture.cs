namespace Paraminter.Processing;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Queries;

internal interface IFixture<in TQuery, TResponse>
    where TQuery : IQuery
{
    public abstract IQueryHandler<TQuery, TResponse> Sut { get; }

    public abstract Mock<IQueryHandler<IIsProcessCompletedQuery, TResponse>> CompletionReaderMock { get; }
}
