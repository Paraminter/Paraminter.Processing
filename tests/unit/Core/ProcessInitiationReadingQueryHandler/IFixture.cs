namespace Paraminter.Processing;

using Moq;

using Paraminter.Processing.Queries;

internal interface IFixture<in TQuery, TResponse>
    where TQuery : IQuery
{
    public abstract IQueryHandler<TQuery, TResponse> Sut { get; }

    public abstract Mock<IQueryHandler<IIsProcessInitiatedQuery, TResponse>> InitiationReaderMock { get; }
}
