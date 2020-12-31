using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WebAPI_MongoDB_Test
{
    //Mongo Driver has some problem to deserialize the Struct & field. some bug issued officialy
    //every thing must be class to deserialize
    //and must set Elemnt name or not cast automatic

    //this tag will ignore extra elements if exist cause no exception
    [BsonIgnoreExtraElements]
    public class WeatherData
    {
        [BsonId]
        public ObjectId ID { get; set; }

        //i dont know the meaning of this field but there is a field in data so implimented
        [BsonElement("st")]
        public string st { get; set; }

        [BsonElement("ts")]
        public DateTime SampleTime { get; set; }

        [BsonElement("position")]
        public Position SamplePosition { get; set; }

        [BsonElement("elevation")]
        public int elevation { get; set; }

        [BsonElement("callLetters")]
        public string callLetters { get; set; }

        [BsonElement("qualityControlProcess")]
        public string qualityControlProcess { get; set; }

        [BsonElement("dataSource")]
        public string dataSource { get; set; }

        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("airTemperature")]
        public AirTemperature airTemperature { get; set; }

        [BsonElement("dewPoint")]
        public DewPoint dewPoint { get; set; }

        [BsonElement("pressure")]
        public Pressure pressure { get; set; }

        [BsonElement("wind")]
        public Wind wind { get; set; }

        [BsonElement("visibility")]
        public Visibility visibility { get; set; }

        [BsonElement("skyCondition")]
        public SkyCondition skyCondition { get; set; }

        [BsonElement("sections")]
        public string[] sections { get; set; }

        [BsonElement("precipitationEstimatedObservation")]
        public PrecipitationEstimatedObservation precipitationEstimatedObservation { get; set; }

    }

    public class Position
    {
        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("coordinates")]
        public double[] coordinates { get; set; }
    }

    public class AirTemperature
    {
        [BsonElement("value")]
        public double value { get; set; }

        [BsonElement("quality")]
        public string quality { get; set; }
    }

    public class DewPoint
    {
        [BsonElement("value")]
        public double value { get; set; }

        [BsonElement("quality")]
        public string quality { get; set; }
    }

    public class Pressure
    {
        [BsonElement("value")]
        public double value { get; set; }

        [BsonElement("quality")]
        public string quality { get; set; }
    }

    public class Wind
    {
        [BsonElement("direction")]
        public Direction direction { get; set; }

        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("speed")]
        public Speed speed { get; set; }

        public class Direction
        {
            [BsonElement("angle")]
            public int angle { get; set; }

            [BsonElement("quality")]
            public string quality { get; set; }
        }
        public class Speed
        {
            [BsonElement("rate")]
            public double rate { get; set; }

            [BsonElement("quality")]
            public string quality { get; set; }
        }
    }

    public class Visibility
    {
        [BsonElement("distance")]
        public Distance distance { get; set; }

        [BsonElement("variability")]
        public Variability variability { get; set; }

        public class Distance
        {
            [BsonElement("value")]
            public long value { get; set; }

            [BsonElement("quality")]
            public string quality { get; set; }
        }

        public class Variability
        {
            [BsonElement("value")]
            public string value { get; set; }

            [BsonElement("quality")]
            public string quality { get; set; }
        }
    }

    public class SkyCondition
    {
        [BsonElement("ceilingHeight")]
        public CeilingHeight ceilingHeight { get; set; }

        [BsonElement("cavok")]
        public string cavok { get; set; }

        public class CeilingHeight
        {
            [BsonElement("value")]
            public long value { get; set; }

            [BsonElement("quality")]
            public string quality { get; set; }

            [BsonElement("determination")]
            public string determination { get; set; }
        }
    }

    public class PrecipitationEstimatedObservation
    {
        [BsonElement("discrepancy")]
        public string discrepancy { get; set; }

        [BsonElement("estimatedWaterDepth")]
        public int estimatedWaterDepth { get; set; }
    }
}
