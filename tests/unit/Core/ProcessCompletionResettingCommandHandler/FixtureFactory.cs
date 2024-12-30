namespace Paraminter.Processing;

using Moq;

using Paraminter.Processing.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<IResetProcessCompletionCommand>> completionResetterMock = new();

        var sut = new ProcessCompletionResettingCommandHandler<TCommand>(completionResetterMock.Object);

        return new Fixture<TCommand>(sut, completionResetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<IResetProcessCompletionCommand>> CompletionResetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<IResetProcessCompletionCommand>> completionResetterMock)
        {
            Sut = sut;

            CompletionResetterMock = completionResetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<IResetProcessCompletionCommand>> IFixture<TCommand>.CompletionResetterMock => CompletionResetterMock;
    }
}
