using MediatR;

namespace ScrutorDecorator
{
	public class Ping : IRequest<Pong>
	{
		public string Message { get; set; }
	}
}