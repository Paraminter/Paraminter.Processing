namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>> completionResetterMock = new();

        var sut = new CompletionResettingCommandHandler<TCommand>(completionResetterMock.Object);

        return new Fixture<TCommand>(sut, completionResetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>> CompletionResetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>> completionResetterMock)
        {
            Sut = sut;

            CompletionResetterMock = completionResetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>> IFixture<TCommand>.CompletionResetterMock => CompletionResetterMock;
    }
}
