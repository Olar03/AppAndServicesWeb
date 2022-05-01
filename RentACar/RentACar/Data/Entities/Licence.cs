using System.ComponentModel.DataAnnotations;

namespace RentACar.Data.Entities
{
    public class Licence
    {

        public int  Id { get; set; }


        [Display(Name = "Licencia")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio. ")]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
