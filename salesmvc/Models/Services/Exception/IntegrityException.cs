namespace salesmvc.Models.Services.Exception
{
    public class IntegrityException: ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {

        }
    }
}
