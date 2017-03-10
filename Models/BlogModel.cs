using Contentful.Core.Models;
using System.Collections.Generic;
public class BlogModel
{
  public List<Entry<dynamic>> Entries { get; set; }
}