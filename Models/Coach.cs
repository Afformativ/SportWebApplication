using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace SportWebApplication
{
    public partial class Coach
    {
        public Coach()
        {
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Прізвище")]
        public string Surname { get; set; }
        [Display(Name = "Дата народження")]
        public DateTime DateOfBirth { get; set; }
        public int NationalityId { get; set; }

        
        [Display(Name = "Національність")]
        public virtual Nationality Nationality { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
