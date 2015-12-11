using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest2.CityRequest
{
    public class PlaceTypeName
    {
        public string code { get; set; }
        public string content { get; set; }
    }

    public class Country
    {
        public string code { get; set; }
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Admin1
    {
        public string code { get; set; }
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Admin2
    {
        public string code { get; set; }
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Locality1
    {
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Postal
    {
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Centroid
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class SouthWest
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class NorthEast
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class BoundingBox
    {
        public SouthWest southWest { get; set; }
        public NorthEast northEast { get; set; }
    }

    public class Timezone
    {
        public string type { get; set; }
        public string woeid { get; set; }
        public string content { get; set; }
    }

    public class Place
    {
        public string lang { get; set; }
        public string xmlns { get; set; }
        public string yahoo { get; set; }
        public string uri { get; set; }
        public string woeid { get; set; }
        public PlaceTypeName placeTypeName { get; set; }
        public string name { get; set; }
        public Country country { get; set; }
        public Admin1 admin1 { get; set; }
        public Admin2 admin2 { get; set; }
        public object admin3 { get; set; }
        public Locality1 locality1 { get; set; }
        public object locality2 { get; set; }
        public Postal postal { get; set; }
        public Centroid centroid { get; set; }
        public BoundingBox boundingBox { get; set; }
        public string areaRank { get; set; }
        public string popRank { get; set; }
        public Timezone timezone { get; set; }
    }

    public class Results
    {
        public List<Place> place { get; set; }
    }

    public class Query
    {
        public int count { get; set; }
        public string created { get; set; }
        public string lang { get; set; }
        public Results results { get; set; }
    }

    public class CityRequest
    {
        public Query query { get; set; }
    }

}
