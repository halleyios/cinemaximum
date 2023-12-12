using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_n96
{
    internal class Film
    {
        public int Id { get; set; } 
        public string FilmAd { get; set; }
        public string Sure { get; set; }
        public string FilmTur { get; set; }
        public bool Begendim { get; set; }
        public DateTime Tarih { get; set; }

        public Film(int id, string filmad, string sure, string tur, bool like, DateTime tarih)
        {
            Id = id;
            FilmAd = filmad;
            Sure = sure;
            FilmTur = tur;
            Begendim = like;
            Tarih = tarih;
        }
    }
}
