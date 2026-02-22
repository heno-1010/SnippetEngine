using System;
using System.Collections.Generic;
using System.Text;

namespace SnippetEngine.Core.Models
{
    public class Snippet
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }

        private void SetValues(string title, string description, string code)
        {
            if (string.IsNullOrWhiteSpace(title)) // titleがnull、空白の時にエラーを返す
                throw new ArgumentException("Title is required.");
            Title = title;
            Description = description ?? "";
            Code = code ?? "";
        }

        public Snippet(string title,string description,string code)
        {
            SetValues(title,description,code);
        }

        public void Update(string title,string description,string code)
        {
            SetValues(title, description, code);
        }

        public bool Matches(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return true;

            return
                Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                Code.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
