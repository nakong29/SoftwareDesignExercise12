using System;

namespace EventDispatcher
{
	class Program
	{
		static void Main() {
			// The "server" object, sending out messages/events regularly.
			MessageTerminal terminal = new();

            // The "client" object, which will be subscribing to the server's event.
			new MessageListener(terminal);

			// Any key to quit.
			QuitOnKeypress();
		}

		private static void QuitOnKeypress() {
			Console.WriteLine("When done viewing message counts: Press any key to quit.");
			Console.ReadKey(true);
		}
	}
}