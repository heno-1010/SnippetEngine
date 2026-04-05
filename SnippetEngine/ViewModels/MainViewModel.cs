using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SnippetEngine.Core.Models;
using System.Text;
using SnippetEngine.Core.Services;

namespace SnippetEngine.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<Snippet> Snippets { get; set; }
        private SnippetManager _manager;

        public MainViewModel()
        {
            _manager = new SnippetManager();
            Snippets = new ObservableCollection<Snippet>(_manager.GetAll());
        }
    }
}
