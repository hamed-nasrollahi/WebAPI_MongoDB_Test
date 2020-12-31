using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WebAPI_MongoDB_Test.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("[controller]")]
    public class WeatherDataController : ControllerBase
    {
        private readonly ILogger<WeatherDataController> _logger;
        private MongoCRUD _mongo;

        //the old way by passing throw AddSingleton
        //private IMongoCollection<WeatherData> _weatherCollection;
        //public WeatherDataController(ILogger<WeatherDataController> logger, IMongoClient mongoClient)
        //{
        //    var mongo_db = mongoClient.GetDatabase("sample_weatherdata");
        //    _weatherCollection = mongo_db.GetCollection<WeatherData>("data");
        //    _logger = logger;
        //}

        public WeatherDataController(ILogger<WeatherDataController> logger, MongoCRUD mongoCRUD)
        {
            _mongo = mongoCRUD;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherData> Get()
        {
            //find data with lambda to get specified data
            //return _weatherCollection.Find(s => s.ID == Guid.Parse("")).ToList();

            //get all the table data
            //return _weatherCollection.Find<WeatherData>(new BsonDocument()).ToList();

            return _mongo.LoadAllRecords<WeatherData>("data");
        }
    }
}
