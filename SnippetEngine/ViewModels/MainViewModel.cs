using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SnippetEngine.Core.Models;
using System.Text;

namespace SnippetEngine.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<Snippet> Snippets { get; set; }

        public MainViewModel()
        {
            Snippets = new ObservableCollection<Snippet>()
            {
                new Snippet("Title","Description","Code"),
                new Snippet("Title2","Description2","Code2")
            };
        }
    }
}
