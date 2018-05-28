using System;
using System.Text.RegularExpressions;

namespace RoverMotionControl.Models
{
    internal class CommandReader : ICommandReader
    {
        public void ValidateCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new InvalidOperationException("command can not be null or empty");

            command = command.Trim().ToUpper();
            var regex = new Regex(@"^[MLR]+$");

            var result= regex.IsMatch(command);
            if(result == false)
                throw new InvalidOperationException("invalid command.. it should only contain letters M , L and/OR R");
        }

        public State ApplyCommandOnstate(string command, State currentState)
        {
            Movement movement = null;
            var commands = command.ToCharArray();

            var updatedState = currentState;
            foreach (var c in commands)
            {
                switch (c)
                {
                    //TODO : resolve using strategy
                    case 'M':
                        movement = updatedState.Movement;
                        var coOrdinates = movement.UpdateBy(updatedState.Points, 1);
                        updatedState= new State(coOrdinates, movement);
                        break;

                    case 'L':
                        var correspondingLeftDirection = updatedState.Movement.CorrespondingLeft;
                        movement = GetCorrespondingMovement(correspondingLeftDirection);
                        updatedState= new State(updatedState.Points, movement);
                        break;
                    case 'R':
                        var correspondingRightDirection = updatedState.Movement.CorrespondingRight;
                        movement = GetCorrespondingMovement(correspondingRightDirection);
                        updatedState= new State(updatedState.Points, movement);
                        break;
                }
            }
            return updatedState;
        }
        

     
        private Movement GetCorrespondingMovement(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new NorthMovement();

                case Direction.East:
                    return new EastMovement();

                case Direction.West:
                    return new WestMovement();
                case Direction.South:
                    return new SouthMovement();

            }
            throw new NotSupportedException();
        }
    }
}