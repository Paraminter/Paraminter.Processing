namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Queries;

internal static class FixtureFactory
{
    public static IFixture<TQuery> Create<TQuery>()
        where TQuery : IQuery
    {
        Mock<IQueryHandler<IIsProcessArgumentAssociationsCompletedQuery, bool>> completionReaderMock = new();

        var sut = new CompletionReadingQueryHandler<TQuery>(completionReaderMock.Object);

        return new Fixture<TQuery>(sut, completionReaderMock);
    }

    private sealed class Fixture<TQuery>
        : IFixture<TQuery>
        where TQuery : IQuery
    {
        private readonly IQueryHandler<TQuery, bool> Sut;

        private readonly Mock<IQueryHandler<IIsProcessArgumentAssociationsCompletedQuery, bool>> CompletionReaderMock;

        public Fixture(
            IQueryHandler<TQuery, bool> sut,
            Mock<IQueryHandler<IIsProcessArgumentAssociationsCompletedQuery, bool>> completionReaderMock)
        {
            Sut = sut;

            CompletionReaderMock = completionReaderMock;
        }

        IQueryHandler<TQuery, bool> IFixture<TQuery>.Sut => Sut;

        Mock<IQueryHandler<IIsProcessArgumentAssociationsCompletedQuery, bool>> IFixture<TQuery>.CompletionReaderMock => CompletionReaderMock;
    }
}
