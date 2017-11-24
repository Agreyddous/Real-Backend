using Real.Backend.Shared.Commands;
using System;

namespace Real.Backend.Domain.Commands.Results
{
	public class GenericCommandResult : ICommandResult
	{
		public GenericCommandResult() { }

		public GenericCommandResult(Guid id, string message)
		{
			Id = id;
			Message = message;
		}

		public Guid Id { get; set; }
		public string Message { get; set; }
	}
}