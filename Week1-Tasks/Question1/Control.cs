using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Control
    {
        public void CreateBands()
        {
            Band[] bandArray = new Band[6];
            bandArray[0] = new Band { BandName = "RHCP", YearFormed = 1990, Members = { "name1", "name2" } };
            bandArray[1] = new Band { BandName = "Rainbow", YearFormed = 1965, Members = { "name1", "name2","name3" } };
            bandArray[2] = new Band { BandName = "King Crimson", YearFormed = 1960, Members = { "name1" } };
            bandArray[3] = new Band { BandName = "Yes", YearFormed = 1985, Members = { "name1", "name2" ,"name3","name4"} };
            bandArray[4] = new Band { BandName = "Pink Floyd", YearFormed = 1980, Members = { "name1", "name2" } };
            bandArray[5] = new Band { BandName = "KISS", YearFormed = 1975, Members = { "name1", "name2" ,"name3","name4","name5"} };
        }
    }
}
