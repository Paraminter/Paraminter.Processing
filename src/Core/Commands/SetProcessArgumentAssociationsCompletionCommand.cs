namespace Paraminter.Processors.Commands;

internal sealed class SetProcessArgumentAssociationsCompletionCommand
    : ISetProcessArgumentAssociationsCompletionCommand
{
    public static ISetProcessArgumentAssociationsCompletionCommand Instance { get; } = new SetProcessArgumentAssociationsCompletionCommand();

    private SetProcessArgumentAssociationsCompletionCommand() { }
}
