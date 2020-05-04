namespace Cei.Api.Common.Models
{
    public class CeiApiDbConnection : ICeiApiDbConnection
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICeiApiDbConnection
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}