using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using HackerNews.Models;
using HackerNews.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackerNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private IValueService _valueService;

        public ValuesController(IValueService valueService)
        {
            _valueService = valueService;
        }

        [HttpGet("{pageSize}/{pageNum}/{search?}", Name = "GetStoryIds")]
        public async Task<IActionResult> GetStoryIds(int pageSize, int pageNum, string search = null)
        {
            List<Story> stories = await _valueService.GetStories(pageSize, pageNum, search);
            return Ok(stories);
        }

        [HttpGet("{id}", Name = "GetStoryObjects")]
        public Story GetStoryObjects(long id)
        {
            string url = "https://hacker-news.firebaseio.com/v0/item/" + id + ".json";
            Story story;
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(json);
                story = JsonSerializer.Deserialize<Story>(json);
            }
           Console.WriteLine("story", id, story);
            return story;
        }
    }
}
