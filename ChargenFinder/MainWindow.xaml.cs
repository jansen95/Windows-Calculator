using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ChargenFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AttachToParentConsole();
            Console.WriteLine("init");
        }


        private void ButtonHandler(object sender, RoutedEventArgs e)
        {
            
            var input = (sender as Button)?.Content.ToString();
            var contentTextbox = TextBox.Text;
            Console.WriteLine("Number in Textbox is " + contentTextbox);
            string newText = contentTextbox + input;
            
            if (TextBox.Text.Length < 23)
            {
                Console.WriteLine("New Number is: "  + newText);
                TextBox.Text = newText;
            }
            else
            {
                Console.WriteLine("More than 23 integers in TextBox!");
            }
            
        }
        
        
        private void DeleteButtonHandler(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text.Length > 0)
            {
                string numbers = TextBox.Text;
                string newNumbers = numbers.Remove(numbers.Length - 1);
                TextBox.Text = newNumbers;
            }
            else
            {
                Console.WriteLine("No numbers to delete!");
            }
        }
        
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        
        
        
        
        
        
        
        
        /// <summary>
        /// Console.Writeline fix
        /// </summary>
        
        private const int AttachParentProcess = -1;

        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        /// <summary>
        ///     Redirects the console output of the current process to the parent process.
        /// </summary>
        /// <remarks>
        ///     Must be called before calls to <see cref="Console.WriteLine()" />.
        /// </remarks>
        private static void AttachToParentConsole()
        {
            AttachConsole(AttachParentProcess);
        }



    }
}