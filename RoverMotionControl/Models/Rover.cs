using System;
using System.Collections.Generic;
using System.Text;

namespace RoverMotionControl.Models
{
    public class Rover
    {
        private Rover()
        {
            CurrentState = new State(new CoOrdinates(0, 0), new NorthMovement()); ;
        }

        private static readonly object padlock = new object();


        private ICommandReader _commandReaderField { get ; set; }

        private ICommandReader _commandReader
        {
            get {
                if (_commandReaderField == null)
                    _commandReaderField = new CommandReader();
                return _commandReaderField;
            }
        }
        private static Rover instance = null;

        public static Rover Instance

        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Rover();
                        }
                    }

                }
                return instance;
            }
        }
        public State CurrentState { get; private set; }

        public void  SetCommandReader(ICommandReader commandReader)
        {
            if (commandReader == null)
                _commandReaderField = new CommandReader();

            _commandReaderField = commandReader;
        }
        public void TransposeFrom(State initialState, string command)
        {
            command.EnsureNotNullOrWhiteSpace(nameof(command));
            initialState.Points.EnsureNotNull("co-ordinates");
            initialState.Movement.EnsureNotNull("direction");
            command= command.ToUpper();
            _commandReader.ValidateCommand(command);
            
              var  updatedState = _commandReader.ApplyCommandOnstate(command, initialState);
            
            this.CurrentState = updatedState;
        }
    }
}
