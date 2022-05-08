namespace WebApiEf.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] - {0}",message);
        }
    }
}