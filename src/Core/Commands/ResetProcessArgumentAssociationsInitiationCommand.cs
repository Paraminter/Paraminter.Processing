namespace Paraminter.Processors.Commands;

internal sealed class ResetProcessArgumentAssociationsInitiationCommand
    : IResetProcessArgumentAssociationsInitiationCommand
{
    public static IResetProcessArgumentAssociationsInitiationCommand Instance { get; } = new ResetProcessArgumentAssociationsInitiationCommand();

    private ResetProcessArgumentAssociationsInitiationCommand() { }
}
