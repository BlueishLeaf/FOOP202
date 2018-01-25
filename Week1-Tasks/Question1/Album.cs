using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Album
    {
        public string AlbumName { get; set; }
        public DateTime ReleaseYear { get; set; }
        public decimal Sales { get; set; }
        public int YearsSinceRelease { get; set; }
        public Album(DateTime releaseYear)
        {
            ReleaseYear = releaseYear;
            YearsSinceRelease = DateTime.Now.Year - releaseYear.Year;
        }
        public override string ToString()
        {
            return $"{AlbumName},{ReleaseYear.Year},{Sales},{YearsSinceRelease}";
        }
    }
}
