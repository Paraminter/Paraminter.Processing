namespace Paraminter.Processing.Commands;

internal sealed class ResetProcessInitiationCommand
    : IResetProcessInitiationCommand
{
    public static IResetProcessInitiationCommand Instance { get; } = new ResetProcessInitiationCommand();

    private ResetProcessInitiationCommand() { }
}
