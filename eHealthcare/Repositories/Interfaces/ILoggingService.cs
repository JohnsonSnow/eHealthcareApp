namespace eHealthcare.Repositories.Interfaces
{
    public interface ILoggingService
    {
        void LogInformation(string message, params object[] parameters);
    }
}
