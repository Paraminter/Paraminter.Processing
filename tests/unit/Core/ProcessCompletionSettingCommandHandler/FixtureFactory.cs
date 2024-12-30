namespace Paraminter.Processing;

using Moq;

using Paraminter.Processing.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<ISetProcessCompletionCommand>> completionSetterMock = new();

        var sut = new ProcessCompletionSettingCommandHandler<TCommand>(completionSetterMock.Object);

        return new Fixture<TCommand>(sut, completionSetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<ISetProcessCompletionCommand>> CompletionSetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<ISetProcessCompletionCommand>> completionSetterMock)
        {
            Sut = sut;

            CompletionSetterMock = completionSetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<ISetProcessCompletionCommand>> IFixture<TCommand>.CompletionSetterMock => CompletionSetterMock;
    }
}
