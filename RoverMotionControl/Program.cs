using RoverMotionControl.Models;
using System;
using System.Text.RegularExpressions;

namespace RoverMotionControl
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to rover motion control program.");
            while (true)
            {
                Console.WriteLine("Please enter valid command to rover movement or press 1 for exit");
                var command = Console.ReadLine();
                if (ShouldExit(command))
                    break;

                Console.WriteLine("Please enter initial co-ordinates of rover : ");
                Console.WriteLine("enter X co-ordinate:");
                int x = ReadCoOrdianate("X");

                Console.WriteLine("enter Y co-ordinate:");
                int y = ReadCoOrdianate("Y");

                var points = new CoOrdinates(x, y);

                Console.WriteLine("enter initial direction of rover:");
                Movement movement = ReadDirection();

                var state = new State(points, movement);



                try
                {
                    var newState = GetUpdatedState(state, command);
                    Console.WriteLine($"new state of rover : {newState.ToString()}");
                }
                catch (InvalidOperationException ex)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please retry");
                }
            }



            Console.WriteLine("thank you!!");
            Console.ReadKey();
        }

        private static State GetUpdatedState(State initialState, string command)
        {
            var rover = Rover.Instance;
            rover.TransposeFrom(initialState, command);
            return rover.CurrentState;
        }

        private static Movement ReadDirection()
        {
            while (true)
            {
                string direction = Console.ReadLine().Trim().ToUpper();
                switch (direction)
                {
                    case "N":
                        return new NorthMovement();
                    case "S":
                        return new SouthMovement();
                    case "E":
                        return new EastMovement();
                    case "W":
                        return new WestMovement();
                }
                Console.WriteLine("direction must be in the form of N, S,E or W ");
            }
        }

        private static int ReadCoOrdianate(string value)
        {
            int x = 0;
            while (true)
            {

                if (Int32.TryParse(Console.ReadLine().Trim(), out x) == false)
                {
                    Console.WriteLine($"pelase enter valid value for {value} co-ordinate");
                }
                return x;
            }

        }

        private static bool ShouldExit(string command)
        {
            if (command.Equals("1"))
                return true;

            return false;
        }

    }
}
