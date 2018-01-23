using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    abstract class Band : IComparable
    {
        public string BandName { get; set; }
        public string YearFormed { get; set; }
        public List<string> Members { get; set; }
        public List<Album> Albums { get; set; }

        public override string ToString()
        {
            return $"{BandName}";
        }

        public int CompareTo(object obj)
        {
            Band tempAuthor = (Band)obj;
            int returnVal = BandName.CompareTo(tempAuthor.BandName);
            return returnVal;
        }
    }

    class RockBand : Band
    {
        public override string ToString()
        {
            return $"{BandName}, Rock";
        }
    }

    class PopBand : Band
    {
        public override string ToString()
        {
            return $"{BandName}, Pop";
        }
    }

    class IndieBand : Band
    {
        public override string ToString()
        {
            return $"{BandName}, Indie";
        }
    }
}

