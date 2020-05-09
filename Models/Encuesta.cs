using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cei.Api.Common.Models
{
    public class Encuesta : IMongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [Required]
        [BsonElement("fecha_apertura")]
        [JsonPropertyName("fecha_apertura")]
        public DateTime FechaApertura { get; set; }

        [Required]
        [BsonElement("fecha_cierre")]
        [JsonPropertyName("fecha_cierre")]
        public DateTime FechaCierre { get; set; }

        [Required]
        [BsonElement("preguntas")]
        public HashSet<PreguntaStruct> Preguntas { get; set; }

        public class PreguntaStruct
        {
            [Required]
            [BsonElement("numero")]
            public int Numero { get; set; }

            [Required]
            [BsonElement("pregunta")]
            public string Pregunta { get; set; }
        }
    }
}