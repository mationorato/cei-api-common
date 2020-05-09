using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cei.Api.Common.Models
{
    public class Estudiante : IMongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [Required]
        [BsonElement("apellido")]
        public string Apellido { get; set; }

        [BsonElement("padron")]
        public int Padron { get; set; }

        [BsonElement("documento")]
        public string Documento { get; set; }

        [BsonElement("cursadas_vigentes")]
        [JsonPropertyName("cursadas_vigentes")]
        public HashSet<CursadaField> CursadasVigentes { get; set; }

        public class CursadaField
        {
            [BsonElement("curso_id")]
            [JsonPropertyName("curso_id")]
            [BsonRepresentation(BsonType.ObjectId)]
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
                [JsonPropertyName("materia_id")]
                [BsonRepresentation(BsonType.ObjectId)]
                public string MateriaId { get; set; }

                [BsonElement("codigo")]
                public string Codigo { get; set; }

                [BsonElement("nombre")]
                public string Nombre { get; set; }
            }
        }
    }
}