using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW3_WPF_Vasilchenko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int pwdChangedCounter = 0;
        string copyStr = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            pwdBox.Clear();
            
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            if(tbScratchTextBox.Text == "")
            {
                MessageBox.Show("Scratch TextBox is Empty!");
            }
            else
            {
                copyStr = tbScratchTextBox.Text;
            }
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            if (tbMaxLength.Text == "Unlimited")
                tbMaxLength.Text = "0"; 

            int maxLength = Convert.ToInt32(tbMaxLength.Text);
          
            if(maxLength==0)
            {
                pwdBox.MaxLength = 0;
                tbLength.Text = "Unlimited";
                pwdBox.PasswordChar = ((ComboBoxItem)cbMaskChar.SelectedItem).Content.ToString().ToCharArray()[0];
                pwdBox.Password = copyStr;
            }
            else if (maxLength < 6 || maxLength > 255)
            {
                MessageBox.Show("Maximum Input Length should match following requirements: \n-Minimum length: 6\n-Maximum length: 255\n\nNOTE:\nFor unlimited length 'Maximum Input Length' should be blank, or write number 0.");
            }
            else if(maxLength== copyStr.Length)
            {
                pwdBox.MaxLength = maxLength;
                tbLength.Text = maxLength.ToString();
                pwdBox.PasswordChar = ((ComboBoxItem)cbMaskChar.SelectedItem).Content.ToString().ToCharArray()[0];
                pwdBox.Password = copyStr;
            }
            else if (maxLength!=copyStr.Length)
            {
                MessageBox.Show("Scratch TextBox length is different from Maximum Input Length");
            }
        }

        private void pwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pwdChangedCounter++;
            tbCounter.Text = pwdChangedCounter.ToString();
        }
    }
}
