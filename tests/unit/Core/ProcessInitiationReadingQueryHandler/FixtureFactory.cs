namespace Paraminter.Processing;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Queries;

internal static class FixtureFactory
{
    public static IFixture<TQuery, TResponse> Create<TQuery, TResponse>()
        where TQuery : IQuery
    {
        Mock<IQueryHandler<IIsProcessInitiatedQuery, TResponse>> initiationReaderMock = new();

        var sut = new ProcessInitiationReadingQueryHandler<TQuery, TResponse>(initiationReaderMock.Object);

        return new Fixture<TQuery, TResponse>(sut, initiationReaderMock);
    }

    private sealed class Fixture<TQuery, TResponse>
        : IFixture<TQuery, TResponse>
        where TQuery : IQuery
    {
        private readonly IQueryHandler<TQuery, TResponse> Sut;

        private readonly Mock<IQueryHandler<IIsProcessInitiatedQuery, TResponse>> InitiationReaderMock;

        public Fixture(
            IQueryHandler<TQuery, TResponse> sut,
            Mock<IQueryHandler<IIsProcessInitiatedQuery, TResponse>> initiationReaderMock)
        {
            Sut = sut;

            InitiationReaderMock = initiationReaderMock;
        }

        IQueryHandler<TQuery, TResponse> IFixture<TQuery, TResponse>.Sut => Sut;

        Mock<IQueryHandler<IIsProcessInitiatedQuery, TResponse>> IFixture<TQuery, TResponse>.InitiationReaderMock => InitiationReaderMock;
    }
}
