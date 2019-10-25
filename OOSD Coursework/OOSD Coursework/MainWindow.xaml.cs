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

		}

		private void InterYes_Checked(object sender, RoutedEventArgs e)
		{
			// Sets visibility of country of origin elements to visible when the international student option is selected
			lblOrigin.Visibility = Visibility.Visible;
			listOrigin.Visibility = Visibility.Visible;
		}

		private bool validate()
		{
			bool validName;
			bool validAge;
			bool validCourse;
			bool validAddress;
			bool validCity;
			bool validPostcode;
			bool validEmail;
			bool validInter;

			// NAME VALIDATION
			if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
			{
				Console.WriteLine("wtf man");
				validName = false;
			}

			// AGE VALIDATION
			// ensure that txtAge field is not empty
			if (string.IsNullOrWhiteSpace(txtAge.Text))
			{
				Console.WriteLine("Age field is empty");
			}
			else
			{
				// converts age text input to integer to be able zto validate the range
				int age = Convert.ToInt32(txtAge.Text);

				// determine if age is within specified range
				if (age < 16 || age > 101)
				{
					Console.WriteLine("wtf come on bro");
					validAge = false;
				}
			}

			// COURSE VALIDATION
			if (listCourse.SelectedIndex < 0)
			{
				Console.WriteLine("you need to pick a course you clown");
				validCourse = false;
			}

			// ADDRESS VALIDATION
			if (string.IsNullOrWhiteSpace(txtAddress1.Text))
			{
				Console.WriteLine("Address Line 1 is empty");
				validAddress = false;
			}

			// CITY VALIDATION
			if (string.IsNullOrWhiteSpace(txtCity.Text))
			{
				Console.WriteLine("City is empty");
				validCity = false; 
			}

			// POSTCODE VALIDATION
			if (string.IsNullOrWhiteSpace(txtPostcode.Text))
			{
				Console.WriteLine("Postcode is empty");
				validPostcode = false;
			}

			// EMAIL VALIDATION
			if (string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				Console.WriteLine("Email field is empty");
				validEmail = false;
			}


			return false;

		}

		private void BtnValidate_Click(object sender, RoutedEventArgs e)
		{
			validate();
		}
	}
}
