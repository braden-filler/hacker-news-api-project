using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackerNews.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using HackerNews.Services;
using HackerNews.Models;
using System.Threading.Tasks;

namespace HackerNews.Controllers.Tests
{
    [TestClass()]
    public class ValuesControllerTests
    {
        [TestMethod()]
        public async Task GetStoryIdsTest()
        {
            ValueService service = new ValueService();

            var result = await service.GetStories(100, 1, null);
            Assert.IsNotNull(result);
        }
    }
}