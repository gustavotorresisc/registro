using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imagenes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPage : ContentPage
    {
        SQLiteConnection database;
        public InsertPage()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<isqlite>().GetLocalFilePath("TESHDB0.db");
            database = new SQLiteConnection(db);
            database.CreateTable<TESHDatos>();
        }

        private void Insertar_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {
                Nombre = Convert.ToInt32(Entry_Nom.Text),
                Apellidos = Entry_Ape.Text,
                Direccion = Entry_Dir.Text,
                Telefono = Entry_Tel.Text,
                Carrera = Entry_carr.Text,
                Semestre = Entry_Sem.Text,
                Matricula = Entry_Matric.Text,
                Correo = Entry_Cor.Text,
                Github = Entry_Git.Text
            };
            database.Insert(datos);
            Navigation.PushModalAsync(new DetailPageBD());

           /* var datos = new TESHDatos
            {
                Matricula = Convert.ToInt32(Entry_ID.Text),
                Nombre = Entry_Name.Text,
                Apellidos = Entry_Ap.Text,
                Direccion = Entry_Dir.Text,
                Telefono = Entry_Tel.Text,
                Carrera = Entry_Car.Text,
                Semestre = Entry_Sem.Text,
                Correo = Entry_Cor.Text,
                Github = Entry_Git.Text
            };
            database.Insert(datos);
            Navigation.PushAsync(new BasedeDatos());*/
        }
    }
}