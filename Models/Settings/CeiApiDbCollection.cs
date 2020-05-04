namespace Cei.Api.Common.Models
{
    public class CeiApiDbCollection : ICeiApiDbCollection
    {
        public string CursoCollectionName { get; set; }
        public string EstudianteCollectionName { get; set; }
        public string MateriaCollectionName { get; set; }
    }

    public interface ICeiApiDbCollection
    {
        string CursoCollectionName { get; set; }
        string EstudianteCollectionName { get; set; }
        string MateriaCollectionName { get; set; }
    }
}