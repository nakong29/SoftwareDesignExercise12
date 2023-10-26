using System;

namespace EventDispatcher
{
	/// <summary>
	/// This is our event consumer/listener (receiver) class.
	/// </summary>
	class MessageListener
	{
		// The object that want to collect/display messages. (In another type of program, with a 
		// different setting, messages could for example be displayed by a GUI system instead.)

		// Constructor.
		public MessageListener(MessageTerminal terminal)
		{
			// Telling which callback method to invoke when an event is generated.
			terminal.MessageReceivedHandler += OnMessageReceived;
		}

		// Our callback method, that the MessageTerminal instance invokes regularly.
		void OnMessageReceived(object? sender, EventArgs? arguments) {
			Console.Clear();
			Console.WriteLine("You have a new message at your private terminal.");
			Console.WriteLine(sender?.ToString());
		}
	}
}