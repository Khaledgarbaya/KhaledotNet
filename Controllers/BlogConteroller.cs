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

public class Blog : Controller
{
        private readonly IContentfulClient _client;
        public Blog(IContentfulClient _client)
        {
          this._client = _client;
        }
        public async Task<IActionResult> Index(string slug) 
        {
            var builder = new QueryBuilder<Entry<dynamic>>().ContentTypeIs("blog").FieldEquals("fields.slug",slug);

            var entries = await _client.GetEntriesAsync<Entry<dynamic>>(builder);
            var blogModel = new BlogModel() 
            {
              Entries = entries.ToList()
            };

            return View(blogModel);
        }

}