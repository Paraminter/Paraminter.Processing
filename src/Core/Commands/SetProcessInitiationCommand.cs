namespace Paraminter.Processors.Commands;

internal sealed class SetProcessInitiationCommand
    : ISetProcessInitiationCommand
{
    public static ISetProcessInitiationCommand Instance { get; } = new SetProcessInitiationCommand();

    private SetProcessInitiationCommand() { }
}
