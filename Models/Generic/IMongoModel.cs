using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cei.Api.Common.Models
{
    public interface IMongoModel
    {
        string Id { get; set; }
    }
}