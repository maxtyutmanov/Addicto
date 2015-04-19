using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Addicto.DAL
{
    public class AddictoWord
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
