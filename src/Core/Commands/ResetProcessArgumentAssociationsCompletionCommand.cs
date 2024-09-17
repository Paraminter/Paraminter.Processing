namespace Paraminter.Processors.Commands;

internal sealed class ResetProcessArgumentAssociationsCompletionCommand
    : IResetProcessArgumentAssociationsCompletionCommand
{
    public static IResetProcessArgumentAssociationsCompletionCommand Instance { get; } = new ResetProcessArgumentAssociationsCompletionCommand();

    private ResetProcessArgumentAssociationsCompletionCommand() { }
}
