namespace Paraminter.Processing;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Queries;

internal static class FixtureFactory
{
    public static IFixture<TQuery, TResponse> Create<TQuery, TResponse>()
        where TQuery : IQuery
    {
        Mock<IQueryHandler<IIsProcessCompletedQuery, TResponse>> completionReaderMock = new();

        var sut = new ProcessCompletionReadingQueryHandler<TQuery, TResponse>(completionReaderMock.Object);

        return new Fixture<TQuery, TResponse>(sut, completionReaderMock);
    }

    private sealed class Fixture<TQuery, TResponse>
        : IFixture<TQuery, TResponse>
        where TQuery : IQuery
    {
        private readonly IQueryHandler<TQuery, TResponse> Sut;

        private readonly Mock<IQueryHandler<IIsProcessCompletedQuery, TResponse>> CompletionReaderMock;

        public Fixture(
            IQueryHandler<TQuery, TResponse> sut,
            Mock<IQueryHandler<IIsProcessCompletedQuery, TResponse>> completionReaderMock)
        {
            Sut = sut;

            CompletionReaderMock = completionReaderMock;
        }

        IQueryHandler<TQuery, TResponse> IFixture<TQuery, TResponse>.Sut => Sut;

        Mock<IQueryHandler<IIsProcessCompletedQuery, TResponse>> IFixture<TQuery, TResponse>.CompletionReaderMock => CompletionReaderMock;
    }
}
