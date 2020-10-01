using HackerNews.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HackerNews.Services
{
    public class ValueService : IValueService
    {
        private HttpClient client = new HttpClient();
        private string url = "https://hacker-news.firebaseio.com/v0/";

        public async Task<List<Story>> GetStories(int pageSize, int pageNum, string search)
        {
            var response = await client.GetAsync(url + "topstories.json?print=pretty");
            var json = response.Content.ReadAsStringAsync().Result;
            var ids = JsonSerializer.Deserialize<long[]>(json);

            var size = pageSize;
            var skip = pageSize * (pageNum - 1);
            var stories = ids.Select(GetStoryFromId);
            var completeStories = (await Task.WhenAll(stories)).ToList();
            if (search != null)
            {
                completeStories = completeStories.Select(index => index).Where(x => x.title.Contains(search)).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                completeStories = completeStories.Select(index => index).Skip(skip).Take(pageSize).ToList();
            }
            return completeStories;
        }

        public async Task<Story> GetStoryFromId(long id)
        {
            var response = await client.GetAsync(string.Format(url + "item/{0}.json?print=pretty", id));
            var json = response.Content.ReadAsStringAsync().Result;
            var story = JsonSerializer.Deserialize<Story>(json);
            return story;
        }
    }
}
