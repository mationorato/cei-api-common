using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cei.Api.Common.Models
{
    public class Curso : IMongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Numero { get; set; }
        public MateriaField Materia { get; set; }
        public HashSet<string> Docentes { get; set; }
        public PeriodoField Periodo { get; set; }


        public class MateriaField
        {
            public string MateriaId { get; set; }
            public int MateriaCodigo { get; set; }
            public string Nombre { get; set; }
        }

        public class PeriodoField
        {
            public int año { get; set; }
            public int cuatrimestre { get; set; }
        }
    }
}