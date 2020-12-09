using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedHookCraftWebsite.Models
{
    public class Product
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Creator name is required"), BsonElement("creator")]
        public string Creator { get; set; }

        [BsonElement("image")]
        public string Image { get; set; }

        [BsonElement("url")]
        public string URL { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        //public int[] ratings { get; set; }
    }
}
