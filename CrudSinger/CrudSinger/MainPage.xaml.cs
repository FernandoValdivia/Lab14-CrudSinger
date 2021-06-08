using CrudSinger.Models;
using CrudSinger.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrudSinger
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        MainViewModel Vm { get { return BindingContext as MainViewModel; } }
        public async void UpdateRow_Tapped(object sender, EventArgs e)
        {
            var contenedor = ((Frame)sender).GestureRecognizers[0];

            SingerModel singerModel = ((TapGestureRecognizer)contenedor).CommandParameter as SingerModel;

            string NameUpt = await DisplayPromptAsync("Name", singerModel.NameSingerModel);

            DateTime BirthFmt = singerModel.BirthSingerModel;
            string BirthSrt = BirthFmt.ToString("dd/MM/yyyy");
            string BirthUpt = await DisplayPromptAsync("Birth", BirthSrt);

            bool ActiveFmt = singerModel.ActiveModel;
            string ActiveSrt = ActiveFmt.ToString();
            string ActiveUpt = await DisplayPromptAsync("Active (True/False)", ActiveSrt);

            //no funca uu
            singerModel.NameSingerModel = NameUpt;

            string format = "dd/MM/yyyy";
            DateTime BirthFmtDt = DateTime.ParseExact(BirthUpt, format, CultureInfo.InvariantCulture);
            singerModel.BirthSingerModel = BirthFmtDt;
            bool ActiveFmtBl = System.Convert.ToBoolean(ActiveSrt);
            Console.WriteLine(ActiveFmtBl);
            singerModel.ActiveModel = ActiveFmtBl;

            Vm.UpdateRowCommand.Execute(singerModel);

        }

        private async void DeleteRow_Swiped(object sender, SwipedEventArgs e)
        {
            bool result = await DisplayAlert("Delete Row", "Are you sure?", "Yes", "No");
            if (result)
            {
                var container = ((Frame)sender).GestureRecognizers[0];
                SingerModel singerModel = ((TapGestureRecognizer)container).CommandParameter as SingerModel;
                Vm.DeleteRowCommand.Execute(singerModel);
            }
        }
    }
}
