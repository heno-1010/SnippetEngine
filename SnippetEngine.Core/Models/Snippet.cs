using System;
using System.Collections.Generic;
using System.Text;

namespace SnippetEngine.Core.Models
{
    public class Snippet
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
