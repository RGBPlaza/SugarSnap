using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SugarSnap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductUnsafePage : ContentPage
    {
        public ProductUnsafePage(string allergen)
        {
            InitializeComponent();
            if (allergen != string.Empty)
            {
                ReasonLabel.Text = string.Format("This product contains {0}", allergen);
                ContinueButton.Text = "See Details Anyway";
                ContinueButton.Clicked += SeeDetails;
            }
            else
            {
                ReasonLabel.Text = "This product is not suitable for consumption";
                ContinueButton.Text = "Go Back";
                ContinueButton.Clicked += GoBack;
            }

        }

        private async void SeeDetails(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void GoBack(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

    }
}
