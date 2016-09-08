using System;

namespace ScrutorDecorator
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var mediator = MediatorBuilder.BuildMediator();

			Console.WriteLine("Sending Ping...");
			var pong = mediator.Send(new Ping { Message = "Ping" });
			Console.WriteLine("Received: " + pong.Message);
		}
	}
}

