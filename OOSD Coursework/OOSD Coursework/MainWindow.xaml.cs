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

		
	}
}
