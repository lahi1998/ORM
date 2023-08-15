using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
    internal interface IClass
    {
        public int ClassID { get; set; }

        public string ClassName { get; set; }

    }
}
