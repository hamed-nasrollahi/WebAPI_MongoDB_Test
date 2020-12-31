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

        // GET api/WeatherData/5553a998e4b02cf7151190b8
        [HttpGet("{id}")]
        public WeatherData Get(string id)
        {
            //get the record by objectID
            return _mongo.LoadRecordByID<WeatherData>("data",ObjectId.Parse(id));
        }

        // POST api/WeatherData
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/WeatherData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/WeatherData/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
