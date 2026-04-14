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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string text = "Nichego";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_HelloWorld_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World!");
            text = "Hello World?";
            
        }

        private void rbtn_FirstOption_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is first option.");
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.TextBox1.Text = text;
        }
    }
}