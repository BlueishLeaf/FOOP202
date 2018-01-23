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
        public int ReleaseYear { get; set; }
        public decimal Sales { get; set; }

        public override string ToString()
        {
            return $"{AlbumName},{ReleaseYear},{Sales}";
        }
    }
}
