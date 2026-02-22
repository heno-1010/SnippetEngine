using SnippetEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace SnippetEngine.Core.Services
{
    internal class SnippetRepository
    {
        public void Save(IEnumerable<Snippet> snippets)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(snippets,options);
            File.WriteAllText("snippets.json", json);
        }
        public List<Snippet> Load()
        {
            if(!File.Exists("snippets.json"))
            {
                return new List<Snippet>();
            }
            string json = File.ReadAllText("snippets.json");
            return JsonSerializer.Deserialize<List<Snippet>>(json) ?? new List<Snippet>();
        }
    }
}
