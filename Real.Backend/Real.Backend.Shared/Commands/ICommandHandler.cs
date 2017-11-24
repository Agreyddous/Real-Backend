namespace Real.Backend.Shared.Commands
{
	public interface ICommandHandler<T> where T : ICommand
	{
		ICommandResult Handle(T Command);
	}
}