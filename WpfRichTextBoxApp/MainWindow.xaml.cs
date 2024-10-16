using Microsoft.Win32;
using System.IO;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfRichTextBoxApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Save
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files|*.txt|Rich files|*.rtf|Xaml files|*.xaml";
            if(saveFileDialog.ShowDialog() == true )
            {
                TextRange range = new TextRange(richEditor.Document.ContentStart, richEditor.Document.ContentEnd);
                using(FileStream writer = File.Create(saveFileDialog.FileName))
                {
                    string extens = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();
                    if (extens == ".rtf")
                        range.Save(writer, DataFormats.Rtf);
                    else if (extens == "txt")
                        range.Save(writer, DataFormats.Text);
                    else
                        range.Save(writer, DataFormats.Xaml);

                }
            }
        }


        // Load
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files|*.txt|Rich files|*.rtf|Xaml files|*.xaml";

            if(openFileDialog.ShowDialog() == true )
            {
                TextRange range = new TextRange(richEditor.Document.ContentStart, richEditor.Document.ContentEnd);
                using(FileStream reader = File.OpenRead(openFileDialog.FileName))
                {
                    string extens = System.IO.Path.GetExtension(openFileDialog.FileName).ToLower();
                    if (extens == ".rtf")
                        range.Load(reader, DataFormats.Rtf);
                    else if(extens == ".xaml")
                        range.Load(reader, DataFormats.Xaml);
                    else
                        range.Load(reader, DataFormats.Text);
                }
            }
        }

        private void btnBold_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(richEditor.Selection.Start, richEditor.Selection.End);
            range.ApplyPropertyValue(RichTextBox.FontWeightProperty, FontWeights.Bold);
        }

        private void btnItalic_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(richEditor.Selection.Start, richEditor.Selection.End);
            range.ApplyPropertyValue(RichTextBox.FontStyleProperty, FontStyles.Italic);
        }

        private void btnSize_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(richEditor.Selection.Start, richEditor.Selection.End);
            range.ApplyPropertyValue(RichTextBox.FontSizeProperty, 30.0);
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(richEditor.Selection.Start, richEditor.Selection.End);
            range.ApplyPropertyValue(RichTextBox.ForegroundProperty, new SolidColorBrush(Colors.Red));
        }
    }
}