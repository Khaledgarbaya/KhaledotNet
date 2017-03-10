using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core.Search;

namespace KhaledDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentfulClient _client;

        public HomeController(IContentfulClient _client)
        {
          this._client = _client;
        }

        public async Task<IActionResult> Index() 
        {
            var builder = new QueryBuilder<Entry<dynamic>>().ContentTypeIs("blog");

            var entries = await _client.GetEntriesAsync<Entry<dynamic>>(builder);
            var blogModel = new BlogModel() 
            {
              Entries = entries.ToList()
            };

            return View(blogModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
