using FluentAssertions;
using RoverMotionControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace RoverMotionControlTests
{
    public class RoverFixture
    {
        [Fact]
        public void Newly_created_rover_will_have_default_state()
        {
            var rover = Rover.Instance;

            rover.CurrentState.Should().NotBeNull();
            var co_ordinates = rover.CurrentState.Points;
            var direction = rover.CurrentState.Movement;
            co_ordinates.Should().NotBeNull();
            co_ordinates.X.Should().Be(0);
            co_ordinates.Y.Should().Be(0);
            direction.Should().NotBeNull();
            direction.Should().BeEquivalentTo(new NorthMovement());
        }

        [Fact]
        public void TransposeFrom_Rover_will_Respond_With_new_State()
        {
            var rover = Rover.Instance;
            CoOrdinates coOrdinates = new CoOrdinates(0,0);
            string command = "MMR";
            rover.TransposeFrom(new State(coOrdinates,new NorthMovement()), command);
            rover.CurrentState.Should().NotBeNull();
        }

        [Theory, MemberData(nameof(Data))]
        public void TransposeFrom_Rover_will_Respond_With_expected_State(State input,string command, State expected)
        {
            var rover = Rover.Instance;
        
           
            rover.TransposeFrom(input, command);
            rover.CurrentState.Should().NotBeNull();
            rover.CurrentState.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> Data
        {
            get
            {
                return new[]
                {
                new object[] {new State(new CoOrdinates(0,0), new NorthMovement()) , "MMM", new State(new CoOrdinates(0, 3), new NorthMovement())},
                 new object[] {new State(new CoOrdinates(10,5), new NorthMovement()) , "MMLMRMML", new State(new CoOrdinates(9, 9), new WestMovement())},

            };
            }
        }


        [Fact]
        public void TransposeFrom_Rover_with_null_command_will_throw_Exception()
        {
            var rover = Rover.Instance;
            CoOrdinates coOrdinates = new CoOrdinates(0, 0);
            string command = null;
            Action act= ()=> rover.TransposeFrom(new State(coOrdinates, new NorthMovement()), command);
            act.Should().Throw<ArgumentNullException>();
        }


        [Fact]
        public void TransposeFrom_Rover_with_null_co_ordinates_will_throw_Exception()
        {
            var rover = Rover.Instance;
            CoOrdinates coOrdinates =null;
            string command = "M";
            Action act = () => rover.TransposeFrom(new State(coOrdinates, new NorthMovement()), command);
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
