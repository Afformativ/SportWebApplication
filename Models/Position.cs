using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace SportWebApplication
{
    public partial class Position
    {
        public Position()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Позиція")]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
