namespace ChatApp.WebApi
{
    public class constants
    {
        string dbname = Environment.GetEnvironmentVariable("DATABASE_NAME");
        string dbPassword = Environment.GetEnvironmentVariable("PASSWORD");
        string dbHost = Environment.GetEnvironmentVariable("HOST");
        string dbUser = Environment.GetEnvironmentVariable("USER");
    }
}
