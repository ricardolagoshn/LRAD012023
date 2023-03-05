using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LRAD012023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInitial : ContentPage
    {
        public PageInitial()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var pagealum = new Views.PageAlum();
            Navigation.PushAsync(pagealum);
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            var pagemapa = new Views.PageMaps();
            Navigation.PushAsync(pagemapa);
        }

        private void listaalums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listaalums.ItemsSource = await App.DBAlum.GetListAlumn();

        }
    }
}