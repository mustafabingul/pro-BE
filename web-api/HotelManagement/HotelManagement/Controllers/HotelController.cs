using HotelManagement.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HotelManagement.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        [HttpGet(Name = "GetHotels")]
        public IEnumerable<HotelInfo> Get()
        {
            //List<HotelInfo> list = new List<HotelInfo>();
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, "Data", "hotels.json");
            string hotels = System.IO.File.ReadAllText(filePath);
            //JArray jArray = JArray.Parse(hotels);
            IEnumerable<HotelInfo> list = JsonConvert.DeserializeObject<IEnumerable<HotelInfo>>(hotels);
            Console.WriteLine(list.ToString());
            return list;
        }
    }
}
