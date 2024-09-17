namespace Paraminter.Processors.Commands;

internal sealed class SetProcessArgumentAssociationsInitiationCommand
    : ISetProcessArgumentAssociationsInitiationCommand
{
    public static ISetProcessArgumentAssociationsInitiationCommand Instance { get; } = new SetProcessArgumentAssociationsInitiationCommand();

    private SetProcessArgumentAssociationsInitiationCommand() { }
}
