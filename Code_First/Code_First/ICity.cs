using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
    internal interface ICity
    {
        public int CityID { get; set; }

        public string CityName { get; set; }

        public int PostalCode { get; set; }
    }
}
