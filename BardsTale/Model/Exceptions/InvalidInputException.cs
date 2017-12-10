using System;
namespace BardsTale.Model.Exceptions
{
    public class InvalidInputException: Exception
    {
        private const string ERROR_MESSAGE = "Please give me something to go by! I like telling stories about animals if it helps :)";

        public InvalidInputException(): 
            base(ERROR_MESSAGE)
        {
        }
    }
}
