using System;

namespace Events
{
    internal class InvalidCastEvent : InvalidCastException
    {
        public event InvalidCastEventHandler activate;

        public InvalidCastEvent(string message = null) : base(message)
        {
            activate = Program.Handler;
        }

        public void Activate()
        {
            activate?.Invoke();
        }
    }
}