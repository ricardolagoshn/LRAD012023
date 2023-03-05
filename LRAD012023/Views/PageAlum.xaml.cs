using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LRAD012023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAlum : ContentPage
    {
        // Variable global de la foto
        Plugin.Media.Abstractions.MediaFile filefoto = null;

        //Function que convierta imagen to base64
        private String ImagetoBase64()
        {
            if (filefoto != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = filefoto.GetStream();
                    stream.CopyTo(memory);
                    byte[] bytefoto = memory.ToArray();
                    string fotoBase64 = Convert.ToBase64String(bytefoto);
                    return fotoBase64;
                }
            }
            return null;
        }
            
        public PageAlum()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    txtlatitud.Text = Convert.ToString(location.Latitude);
                    txtlongitud.Text = Convert.ToString(location.Longitude);

                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch(Exception ex) 
            {
            }

        }

        private async void btnmostrar_Clicked(object sender, EventArgs e)
        {
            var alum = new Models.Alumno
            {
                nombres = txtnombre.Text,
                apellidos = txtapellidos.Text,
                direccion = txtdireccion.Text,
                sexo = cbsexo.SelectedItem.ToString(),
                foto = ImagetoBase64()
            };


            if (await App.DBAlum.SaveAlum(alum) > 0)
                await DisplayAlert("Aviso", "Alumno Ingresado", "OK");
            else
                await DisplayAlert("Aviso", "Error", "OK");

            var page = new Views.PageResultado();
            page.BindingContext= alum;
            await Navigation.PushAsync(page);

        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            filefoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
               SaveToAlbum = true,
               Directory = "MiApp",
               Name = "foto.jpg"
            }); 

            if (filefoto != null)
            {
                foto.Source = ImageSource.FromStream(() => { return filefoto.GetStream(); });
            }
        }
    }
}