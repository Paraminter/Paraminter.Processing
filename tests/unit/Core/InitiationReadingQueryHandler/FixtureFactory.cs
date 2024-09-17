namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Queries;

internal static class FixtureFactory
{
    public static IFixture<TQuery> Create<TQuery>()
        where TQuery : IQuery
    {
        Mock<IQueryHandler<IIsProcessArgumentAssociationsInitiatedQuery, bool>> initiationReaderMock = new();

        var sut = new InitiationReadingQueryHandler<TQuery>(initiationReaderMock.Object);

        return new Fixture<TQuery>(sut, initiationReaderMock);
    }

    private sealed class Fixture<TQuery>
        : IFixture<TQuery>
        where TQuery : IQuery
    {
        private readonly IQueryHandler<TQuery, bool> Sut;

        private readonly Mock<IQueryHandler<IIsProcessArgumentAssociationsInitiatedQuery, bool>> InitiationReaderMock;

        public Fixture(
            IQueryHandler<TQuery, bool> sut,
            Mock<IQueryHandler<IIsProcessArgumentAssociationsInitiatedQuery, bool>> initiationReaderMock)
        {
            Sut = sut;

            InitiationReaderMock = initiationReaderMock;
        }

        IQueryHandler<TQuery, bool> IFixture<TQuery>.Sut => Sut;

        Mock<IQueryHandler<IIsProcessArgumentAssociationsInitiatedQuery, bool>> IFixture<TQuery>.InitiationReaderMock => InitiationReaderMock;
    }
}
