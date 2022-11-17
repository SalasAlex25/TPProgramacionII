using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public GeneroPelicula Genero { get; set; }
        public int IdPaisOrigen { get; set; }
        public CalificacionEtaria CalificacionEtaria { get; set; }
        public Idioma Idioma { get; set; }
        public int Duracion { get; set; }
        public bool Subtitulada { get; set; }
        //public Image Imagen { get; set; }

        public Pelicula()
        {
            IdPelicula = 0;
            Nombre = String.Empty;
            Genero = null;
            IdPaisOrigen = 0;
            CalificacionEtaria = null;
            Idioma = null;
            Duracion = 0;
            Subtitulada = false;
            //Imagen = null;
        }

        public Pelicula(int idPelicula, string nombre, GeneroPelicula genero, int idPaisOrigen, CalificacionEtaria calificacionEtaria, 
                         Idioma idioma, int duracion, bool subtitulada/*, Image image*/)
        {
            this.IdPelicula = idPelicula;
            this.Nombre = nombre;
            this.Genero = genero;
            this.IdPaisOrigen = idPaisOrigen;
            this.CalificacionEtaria = calificacionEtaria;
            this.Idioma = idioma;
            this.Duracion = duracion;
            this.Subtitulada = subtitulada;
            //this.Imagen = Imagen;
        }
    }
}
