using System;
namespace BardsTale.Model.Exceptions
{
    public class DictionaryNotFoundException: Exception
    {
        private const string ERROR_MESSAGE = "Could not load dictionary from path ";

        public DictionaryNotFoundException(String dictionary): 
            base(ERROR_MESSAGE + dictionary)
        {
        }
    }
}
