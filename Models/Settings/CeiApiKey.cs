namespace Cei.Api.Common.Models
{
    public class CeiApiKey : ICeiApiKey
    {
        public string Current { get; set; }
        public string Academica { get; set; }
        public string Encuestas { get; set; }
    }

    public interface ICeiApiKey
    {
        string Current { get; set; }
        string Academica { get; set; }
        string Encuestas { get; set; }
    }
}