using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace SportWebApplication
{
    public partial class Nationality
    {
        public Nationality()
        {
            Coaches = new HashSet<Coach>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Національність")]
        public string Name { get; set; }

        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
