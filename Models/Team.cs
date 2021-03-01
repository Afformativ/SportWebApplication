using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace SportWebApplication
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="Поле не повинно бути порожнім")]
        [Display(Name="Назва")]
        public string Name { get; set; }
        [Display(Name = "Дата створення")]
        public DateTime DateOfCreation { get; set; }

        public int SportId { get; set; }

        public int CityId { get; set; }

        public int CoachId { get; set; }


        [Display(Name = "Місто")]
        public virtual City City { get; set; }

        [Display(Name = "Головний тренер")]
        public virtual Coach Coach { get; set; }

        [Display(Name = "Вид спорту")]
        public virtual Sport Sport { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
