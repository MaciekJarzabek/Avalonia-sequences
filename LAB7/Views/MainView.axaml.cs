using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace LAB7.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Click!");
            AnalyzeSequence();
        }

        public void AnalyzeSequence()
        {
            var inputBox = this.FindControl<TextBox>("inputBox");
            var outputBlock = this.FindControl<TextBlock>("outputBlock");

            string sequence = inputBox.Text.ToUpper();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            for (int i = 0; i <= sequence.Length - 4; i++)
            {
                string subsequence = sequence.Substring(i, 4);
                if (subsequence.All(c => "ACGT".Contains(c)))
                {
                    if (counts.ContainsKey(subsequence))
                        counts[subsequence]++;
                    else
                        counts[subsequence] = 1;
                }
            }

            outputBlock.Text = string.Join("\n", counts.Select(kv => $"{kv.Key}: {kv.Value}"));
        }
    }
}
