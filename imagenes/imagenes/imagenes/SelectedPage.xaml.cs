using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imagenes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedPage : ContentPage
    {
        SQLiteConnection database;
        public SelectedPage(object selectedItem)
        {
            InitializeComponent();
            var datos = selectedItem as TESHDatos;
            BindingContext = datos;
            InitializeComponent();
            string db;
            db = DependencyService.Get<isqlite>().GetLocalFilePath("TESHDB0.db");
            database = new SQLiteConnection(db);



        }

        private void ButtonActualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {
                Nombre = Convert.ToInt32(Entry_Nom.Text),

            };
            database.Update(datos);

        }

        private void ButtonEliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}