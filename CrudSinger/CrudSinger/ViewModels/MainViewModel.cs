using CrudSinger.BL;
using CrudSinger.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudSinger.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        Singers singers = new Singers();

        private ObservableCollection<SingerModel> listSingers;
        public ObservableCollection<SingerModel> ListSingers
        {
            get { return listSingers; }
            set { listSingers = value; RaisePropertyChanged(); }
        }
        //Variable id
        private int idSingerP;
        public int IdSingerP
        {
            get { return idSingerP; }
            set { idSingerP = value; RaisePropertyChanged(); }
        }
        //Variable nombre
        private string nameSingerP;
        public string NameSingerP
        {
            get { return nameSingerP; }
            set { nameSingerP = value; RaisePropertyChanged();}
        }
        //Variable nacimiento
        private DateTime birthSingerP;
        public DateTime BirthSingerP
        {
            get { return birthSingerP; }
            set { birthSingerP = value; RaisePropertyChanged();}
        }
        //Variable activo
        private bool activeP;
        public bool ActiveP
        {
            get { return activeP; }
            set { activeP = value; RaisePropertyChanged(); }
        }

        public ICommand InsertRowCommand { get; set; }
        public ICommand UpdateRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        public ICommand DeleteAllRowCommand { get; set; }

        public MainViewModel()
        {
            //Eliminar una fila
            DeleteRowCommand = new Command<SingerModel>(execute: async (singerModel) =>
            {
                await singers.Delete(singerModel);
                LoadListSingers();
            });

            //Eliminar todo
            DeleteAllRowCommand = new Command(execute: async () =>
            {
                await singers.DeleteAllSingers();
                LoadListSingers();
            });

            //actulaizar una fila
            UpdateRowCommand = new Command<SingerModel>(execute: async (singerModel) =>
            {
                await singers.Update(singerModel);
                LoadListSingers();
            });

            //Insertar una fila
            InsertRowCommand = new Command(execute: async () =>
            {
                await singers.Insert(new SingerModel() { IdSingerModel = IdSingerP, NameSingerModel = NameSingerP, BirthSingerModel = BirthSingerP, ActiveModel = ActiveP });
                IdSingerP = 0;
                NameSingerP = "";
                BirthSingerP = DateTime.Today;
                ActiveP = false;
                LoadListSingers();
            });

            LoadListSingers();
        }

        async void LoadListSingers()
        {
            ListSingers = new ObservableCollection<SingerModel>(await singers.GetListSingers());
        }
    }
}
