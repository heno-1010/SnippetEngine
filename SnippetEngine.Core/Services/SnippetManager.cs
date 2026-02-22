using SnippetEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static System.Net.WebRequestMethods;

namespace SnippetEngine.Core.Services
{
    public class SnippetManager
    {
        private List<Snippet> _snippets = new();
        private SnippetRepository _repository;

        public SnippetManager()
        {
            _repository = new SnippetRepository();
            _snippets = _repository.Load();
        }

        public void AddSnippet(Snippet snippet)
        {
            ArgumentNullException.ThrowIfNull(snippet); //snippetがnullだったときはエラーを返す
            _snippets.Add(snippet);

            _repository.Save(_snippets);
        }

        public void RemoveSnippet(Snippet snippet)
        {
            _snippets.Remove(snippet);
        }

        public IReadOnlyList<Snippet> GetAll()
        {
            return _snippets.AsReadOnly();
        }

        public IEnumerable<Snippet> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) // keywordがnull、空白の時
                return GetAll();

            return _snippets.Where(s => s.Matches(keyword));
        }

    }
}
