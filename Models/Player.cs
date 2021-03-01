using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace SportWebApplication
{
    public partial class Player
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Прізвище")]
        public string Surname { get; set; }
        [Display(Name = "Дата народження")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Зріст")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Вага")]
        public int Weight { get; set; }
        public int NationalityId { get; set; }
        public int TeamId { get; set; }
        public int PositionId { get; set; }


        [Display(Name = "Національність")]
        public virtual Nationality Nationality { get; set; }

        [Display(Name = "Номінальна позиція")]
        public virtual Position Position { get; set; }

        [Display(Name = "Команда")]
        public virtual Team Team { get; set; }
    }
}
