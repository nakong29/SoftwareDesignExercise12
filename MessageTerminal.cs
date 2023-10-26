using System;
using System.Timers;

namespace EventDispatcher
{
	// NOTE: This delegate is already defined in System, so technically we wouldn't need to put it here.
	/// <summary>
	/// The delegate ("function pointer") type that subscribers' callback functions must match.
	/// </summary>
	public delegate void Eventhandler(object? sender, EventArgs? arguments);

	/// <summary>
	/// This is our event control (sender/generator) class.
	/// </summary>
	class MessageTerminal
	{
		/// <summary>
		/// The event handler that the subscribers' callback methods subscribes to.
		/// </summary>
		public event EventHandler? MessageReceivedHandler;

        // "Normal" class variables.
		private int _numberOfUnreadMessages;
		private readonly Timer _messageSendTimer;
		private readonly Random _randomGenerator;

		// Constructor.
		public MessageTerminal() {
			_numberOfUnreadMessages = 0;
			_randomGenerator = new Random();
			_messageSendTimer = new Timer();

			// What to do every time the timer is done counting. (Invoke SendMessage - through an event.)
			_messageSendTimer.Elapsed += SendMessageByEvent;

			// Starting the first countdown (countup) to sending a message.
			SetupNextMessage();
		}

		public override string ToString() {
			return "Number of unread messages: " + _numberOfUnreadMessages;
		}

		/// <summary>
		/// The sender-method that invokes the callback methods.
		/// </summary>
		protected virtual void InvokeSubscribersCallbackMethods() {
			// If anyone is subscribing.
			// Invoke every subscribing callback method. 
			// (Params: reference to ourselves, no other arguments.)
			MessageReceivedHandler?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// The main method that gets invoked regularly - our "loop" if you like. 
		/// </summary>
		/// <param name="sender">not used</param>
		/// <param name="arguments">not used</param>
		private void SendMessageByEvent(object? sender, ElapsedEventArgs? arguments) {
			_numberOfUnreadMessages++;
			InvokeSubscribersCallbackMethods();
			SetupNextMessage();
		}

		// Setting time until next message is generated.
		private void SetupNextMessage() {
			_messageSendTimer.Interval = _randomGenerator.Next(1000, 5000);
			_messageSendTimer.Start();
		}
	}
}