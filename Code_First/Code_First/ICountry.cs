using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
    internal interface ICountry
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }
    }
}
