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

        public bool RemoveSnippet(Guid id)
        {
            var snippet = _snippets.FirstOrDefault(s => s.Id == id);
            if(snippet != null)
            {
                _snippets.Remove(snippet);
                _repository.Save(_snippets);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateSnippet(Guid id, string title, string description, string code)
        {
            var snippet = _snippets.FirstOrDefault(s => s.Id == id);
            if(snippet != null)
            {
                snippet.Update(title, description, code);
                _repository.Save(_snippets);
                return true;
            }
            else
            {
                return false;
            }
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
