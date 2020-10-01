using HackerNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Services
{
    public interface IValueService
    {
        Task<List<Story>> GetStories(int pageSize, int pageNum, string search);
    }
}
