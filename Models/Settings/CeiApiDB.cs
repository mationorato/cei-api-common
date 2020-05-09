namespace Cei.Api.Common.Models
{
    public class CeiApiDB : ICeiApiDB
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public CeiApiDbCollection Collections { get; set; }
    }

    public class CeiApiDbCollection
    {
        public string Curso { get; set; }
        public string Estudiante { get; set; }
        public string Materia { get; set; }
        public string Encuesta { get; set; }
        public string EncuestaRespuesta { get; set; }
    }

    public interface ICeiApiDB
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        CeiApiDbCollection Collections { get; set; }
    }
}