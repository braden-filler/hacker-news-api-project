using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackerNews.Services;
using System;
using System.Collections.Generic;
using System.Text;
using HackerNews.Models;
using System.Threading.Tasks;

namespace HackerNews.Services.Tests
{
    [TestClass]
    public class ValueServiceTests
    {
        [TestMethod]
        public async Task GetStoriesTest()
        {
            ValueService service = new ValueService();
            List<Story> stories = await service.GetStories(100, 1, null);
            Assert.AreEqual(100, stories.Count);
        }

        [TestMethod]
        public async Task GetStoryFromIdTest()
        {
            //24643830
            var id = 24643830;
            ValueService service = new ValueService();
            Story story = await service.GetStoryFromId(id);
            Assert.IsNotNull(story);
        }
    }
}