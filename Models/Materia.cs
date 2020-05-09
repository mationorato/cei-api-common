using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cei.Api.Common.Models
{
    public class Materia : IMongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("codigo")]
        public string Codigo { get; set; }

        [Required]
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("cursos_vigentes")]
        [JsonPropertyName("cursos_vigentes")]
        public HashSet<Curso> CursosVigentes { get; set; }

        public class Curso
        {
            [BsonElement("curso_id")]
            [JsonPropertyName("curso_id")]
            [BsonRepresentation(BsonType.ObjectId)]
            public string CursoId { get; set; }

            [BsonElement("numero")]
            public string Numero { get; set; }

            [BsonElement("docentes")]
            public string[] Docentes { get; set; }

            [BsonElement("horarios")]
            public HashSet<Horario> Horarios { get; set; }

            public class Horario
            {
                [BsonElement("dia")]
                public string Dia { get; set; }

                [BsonElement("hora_inicio")]
                [JsonPropertyName("hora_inicio")]
                public string HoraInicio { get; set; }

                [BsonElement("hora_fin")]
                [JsonPropertyName("hora_fin")]
                public string HoraFin { get; set; }

                [BsonElement("aula")]
                public string Aula { get; set; }

                [BsonElement("sede")]
                public string Sede { get; set; }
            }
        }
    }
}