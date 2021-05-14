using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        public StatusWindow()
        {
            InitializeComponent();

            //Set the maximum on the Csharp side
            uxProgressBar.Maximum = 100;
            
            //Starting the progress bar at 0
            uxProgressBar.Value = 0;
        }

        private void uxTextEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = uxTextEditor.GetLineIndexFromCharacterIndex(uxTextEditor.CaretIndex);
            int col = uxTextEditor.CaretIndex - uxTextEditor.GetCharacterIndexFromLineIndex(row);
            
            uxStatus.Text = "Line " + (row + 1) + ", Char " + (col + 1);

            //Set the progress bar to be the current "length" of the box aka "count" of characters
            uxProgressBar.Value = uxTextEditor.Text.Length;

            //Set the percentage text block to be the current length divided by the maximum length
            if (uxTextEditor.Text.Length > 0)
            {
                int percentInt = (uxTextEditor.Text.Length * 100) / uxTextEditor.MaxLength;
                uxPercentageText.Text = string.Format($"{percentInt}%");
            }

            
        }
    }
}
