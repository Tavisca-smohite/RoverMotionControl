namespace RoverMotionControl.Models
{
    public  interface ICommandReader
    {
         void ValidateCommand(string command);
         State ApplyCommandOnstate(string command, State currentState);
    }
}