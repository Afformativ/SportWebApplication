using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace SportWebApplication
{
    public partial class Sport
    {
        public Sport()
        {
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Вид спорту")]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
