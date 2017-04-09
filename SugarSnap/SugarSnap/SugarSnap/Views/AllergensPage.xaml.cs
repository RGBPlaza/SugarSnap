using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SugarSnap.Models;

namespace SugarSnap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllergensPage : ContentPage
    {
        public AllergensPage()
        {
            InitializeComponent();
            foreach(string s in Settings.UserAllergens.Split(','))
            {
                if (s != "")
                {
                    userAllergens.Add(new Allergen { Name = s });
                }
            }
            AllergenListview.ItemsSource = userAllergens;
        }

        List<Allergen> userAllergens = new List<Allergen>();

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            if (AllergenEntry.Text != null)
            {
                if (userAllergens.IndexOf(new Allergen() { Name = AllergenEntry.Text }) == -1)
                {
                    userAllergens.Add(new Allergen() { Name = AllergenEntry.Text });
                    Settings.UserAllergens = "";
                    foreach (Allergen a in userAllergens)
                    {
                        if (a != userAllergens.Last())
                            Settings.UserAllergens += (a.Name + ",");
                        else
                            Settings.UserAllergens += a.Name;
                    };
                    AllergenEntry.Text = null;
                    AllergenListview.ItemsSource = null;
                    AllergenListview.ItemsSource = userAllergens;
                }
                else
                {
                    DisplayAlert("Invalid Addition", "You cannot add this allergen as it already exists", "Ok");
                }
            }
            else
            {
                DisplayAlert("Invalid Addition", "You cannot add an empty allergen", "Just testing you!");
            }
        }

        private async void AllergenListview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (AllergenListview.SelectedItem != null)
            {
                if (await DisplayAlert("Delete Allergen", "Are you sure you want to remove this allergen?", "You bet!", "Course Not!"))
                {
                    userAllergens.Remove(e.SelectedItem as Allergen);
                    Settings.UserAllergens = string.Join(",", userAllergens);
                    AllergenListview.ItemsSource = null;
                    AllergenListview.ItemsSource = userAllergens;
                }
                AllergenListview.SelectedItem = null;
            }
        }
    }

}
