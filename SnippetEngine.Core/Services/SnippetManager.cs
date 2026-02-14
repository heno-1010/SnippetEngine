using SnippetEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnippetEngine.Core.Services
{
    public class SnippetManager
    {
        private List<Snippet> _snippets = new();

        public void AddSnippet(Snippet snippet)
        {
            ArgumentNullException.ThrowIfNull(snippet); //snippetがnullだったときはエラーを返す
            _snippets.Add(snippet);
        }
    }
}
