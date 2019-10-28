using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace OOSD_Coursework
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
            GetTxtData();

        }



		private void BtnClear_Click(object sender, RoutedEventArgs e)
		{
			// Clears all text input and selections on the form
			txtFirstName.Text = String.Empty;
			txtSurname.Text = String.Empty;
			txtEmail.Text = String.Empty;
			txtAge.Text = String.Empty;
			txtAddress1.Text = String.Empty;
			txtAddress2.Text = String.Empty;
			txtCity.Text = String.Empty;
			txtPostcode.Text = String.Empty;
		    interNo.IsChecked=true;
			lblOrigin.Visibility = Visibility.Collapsed;
			listOrigin.Visibility = Visibility.Collapsed;
            lblAge.Foreground = new SolidColorBrush(Colors.Black);
            lblFirstName.Foreground = new SolidColorBrush(Colors.Black);
            lblSurname.Foreground = new SolidColorBrush(Colors.Black);
            lblCourse.Foreground = new SolidColorBrush(Colors.Black);
            lblAddress.Foreground = new SolidColorBrush(Colors.Black);
            lblCity.Foreground = new SolidColorBrush(Colors.Black);
            lblPostcode.Foreground = new SolidColorBrush(Colors.Black);
            lblOrigin.Foreground = new SolidColorBrush(Colors.Black);
            lblEmail.Foreground = new SolidColorBrush(Colors.Black);



            

		}

		private void InterYes_Checked(object sender, RoutedEventArgs e)
		{
			// Sets visibility of country of origin elements to visible when the international student option is selected
			lblOrigin.Visibility = Visibility.Visible;
			listOrigin.Visibility = Visibility.Visible;
		}

		private bool validate()
		{
			

            int invalidationCount = 0;

			// NAME VALIDATION
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    Console.WriteLine("The name field is empty");
                    // Sets field label to red if input is invalid
                    lblFirstName.Foreground = new SolidColorBrush(Colors.Red);
                    lblSurname.Foreground = new SolidColorBrush(Colors.Red);


                    invalidationCount++;
                } else {
                    lblFirstName.Foreground = new SolidColorBrush(Colors.Black);
                    lblSurname.Foreground = new SolidColorBrush(Colors.Black);
                }
            } catch (Exception e){
                Console.WriteLine("{0} Exception caught.", e);
                invalidationCount++;
            }
          

			// AGE VALIDATION
			// ensure that txtAge field is not empty
            try
            {
                if (string.IsNullOrWhiteSpace(txtAge.Text))
                {
                    Console.WriteLine("Age field is empty");
                    // Sets field label to red if input is invalid
                    lblAge.Foreground = new SolidColorBrush(Colors.Red);
                    invalidationCount++;
                }
                else
                {
                    // converts age text input to integer to be able zto validate the range
                    int age = Convert.ToInt32(txtAge.Text);

                    // determine if age is within specified range
                    if (age < 16 || age > 101)
                    {
                        Console.WriteLine("Age invalid");
                        // Sets field label to red if input is invalid
                        lblAge.Foreground = new SolidColorBrush(Colors.Red);
                        invalidationCount++;
                    }
                } 

                 
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                invalidationCount++;
            }
       

            // COURSE VALIDATION
            try
            {
                if (listCourse.SelectedIndex < 0)
                {
                    Console.WriteLine("you need to pick a course you clown");
                    // Sets field label to red if input is invalid
                    lblCourse.Foreground = new SolidColorBrush(Colors.Red);
                    invalidationCount++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                invalidationCount++;
            }
            

            // ADDRESS VALIDATION
            try
            {
                if (string.IsNullOrWhiteSpace(txtAddress1.Text))
                {
                    Console.WriteLine("Address Line 1 is empty");
                    // Sets field label to red if input is invalid
                    lblAddress.Foreground = new SolidColorBrush(Colors.Red);
                    invalidationCount++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                invalidationCount++;
            }
            

            // CITY VALIDATION
            try
            {
                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    Console.WriteLine("City is empty");
                    // Sets field label to red if input is invalid
                    lblCity.Foreground = new SolidColorBrush(Colors.Red);
                    invalidationCount++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                invalidationCount++;
            }
            

            // POSTCODE VALIDATION
            try
            {
                if (string.IsNullOrWhiteSpace(txtPostcode.Text))
                {
                    Console.WriteLine("Postcode is empty");

                    // Sets field label to red if input is invalid
                    lblPostcode.Foreground = new SolidColorBrush(Colors.Red);
                    invalidationCount++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                invalidationCount++;
            }
            

            // EMAIL VALIDATION
            try
            {
                // ensure email field is not empty
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    Console.WriteLine("Email field is empty");
                    // Sets field label to red if input is invalid
                    lblEmail.Foreground = new SolidColorBrush(Colors.Red);
                    invalidationCount++;
                }

                // check if email meets the required format, contains @ & begins and ends with 0-9/A-Z/a-z
                // regex declaration to test email format
                Regex rg = new Regex(@"^([A-Z0-9].*)@(.*)$", RegexOptions.IgnoreCase);

                // test if email meets regex 
                if (rg.IsMatch(txtEmail.Text) == false)
                {
                    Console.WriteLine("Email format is not correct");
                    invalidationCount++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                invalidationCount++;
            }

            // INTERNATIONAL STUDENT VALIDATION
            try
            {
                if (interYes.IsChecked == true && listOrigin.SelectedIndex < 0)
                {
                    Console.WriteLine("You need to select a country of origin as an international student");
                    // Sets field label to red if input is invalid
                    lblOrigin.Foreground = new SolidColorBrush(Colors.Red);
                    invalidationCount++;
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                invalidationCount++;
            }



            // check if validation has passed
            if (invalidationCount == 0)
            {
                Console.WriteLine("Passed Validation");
                MessageBox.Show("Information Validated Successfully :)", "Success");
            } else
            {
                Console.WriteLine("Did not pass validation");
                MessageBox.Show("Information was invalid Please correct highlighted fields", "Invalid Input");
            }

            


			return false;

		}

		private void BtnValidate_Click(object sender, RoutedEventArgs e)
		{
			validate();
		}

        public string GetTxtData()
        {
            // loads each line of the countries file and adds them to combobox
            listOrigin.ItemsSource = File.ReadAllLines(@"C:\Users\40430241\source\repos\csharp-coursework-2019\OOSD Coursework\OOSD Coursework\countries.txt");
            return "zzz";
        }

		
	}
}
