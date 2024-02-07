namespace BackUserAdmin.Helpers
{
    public class ServiceException : Exception
    {
        public ServiceException(string error) : base(error)
        {
        }
    }
}
