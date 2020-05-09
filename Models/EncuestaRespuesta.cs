using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using Newtonsoft.Json;

namespace Cei.Api.Common.Models
{
    public class EncuestaRespuesta : IMongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("encuesta_id")]
        [JsonPropertyName("encuesta_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EncuestaId { get; set; }

        [JsonPropertyName("estudiante_id")]
        [BsonElement("estudiante_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EstudianteId { get; set; }

        [Required]
        [BsonElement("fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [BsonElement("respuestas")]
        public HashSet<RespuestaStruct> Respuestas { get; set; }

        [BsonElement("detalles")]
        [BsonDictionaryOptions(DictionaryRepresentation.Document)]
        public Dictionary<string, string> Detalles { get; set; }

        public class RespuestaStruct
        {
            [Required]
            [JsonPropertyName("pregunta_numero")]
            [BsonElement("pregunta_numero")]
            public int PreguntaNumero { get; set; }

            [Required]
            [BsonElement("respuesta")]
            public string Respuesta { get; set; }
        }
    }
}