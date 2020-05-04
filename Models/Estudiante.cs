using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cei.Api.Common.Models
{
    public class Estudiante : IMongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("apellido")]
        public string Apellido { get; set; }
        [BsonElement("padron")]
        public int Padron { get; set; }
        [BsonElement("documento")]
        public string Documento { get; set; }
        [BsonElement("cursadas_vigentes")]
        public HashSet<CursadaField> CursadasVigentes { get; set; }

        public class CursadaField
        {
            [BsonElement("curso_id")]
            public string CursoId { get; set; }
            [BsonElement("numero")]
            public string Numero { get; set; }
            [BsonElement("materias")]
            public MateriaField Materia { get; set; }
            [BsonElement("docentes")]
            public string[] Docentes { get; set; }

            public class MateriaField
            {
                [BsonElement("materia_id")]
                public string MateriaId { get; set; }
                [BsonElement("codigo")]
                public string Codigo { get; set; }
                [BsonElement("nombre")]
                public string Nombre { get; set; }
            }
        }
    }
}