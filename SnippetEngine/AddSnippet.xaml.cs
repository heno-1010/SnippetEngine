using SnippetEngine.Core.Models;
using SnippetEngine.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SnippetEngine
{
    /// <summary>
    /// AddSnippet.xaml の相互作用ロジック
    /// </summary>
    public partial class AddSnippet : Window
    {
        private SnippetManager _manager;

        public AddSnippet()
        {
            InitializeComponent();
            _manager = new SnippetManager();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var snippet = new Snippet(
                    TitleTextBox.Text,
                    DescriptionTextBox.Text,
                    CodeTextBox.Text
                );

                _manager.AddSnippet(snippet);
                MessageBox.Show("保存しました");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
