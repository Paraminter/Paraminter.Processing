namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> completionSetterMock = new();

        var sut = new CompletionSettingCommandHandler<TCommand>(completionSetterMock.Object);

        return new Fixture<TCommand>(sut, completionSetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> CompletionSetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> completionSetterMock)
        {
            Sut = sut;

            CompletionSetterMock = completionSetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> IFixture<TCommand>.CompletionSetterMock => CompletionSetterMock;
    }
}
