using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapayZekaTemelleir
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string MomName { get; set; }
        public string FatherName { get; set; }
        public int Brother { get; set; }
    }
}
