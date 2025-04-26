using System.ComponentModel.DataAnnotations;

namespace CustomerDetailsApp.ViewModels
{
    public class FieldsModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 110)]
        public int Age { get; set; }

        [Required]
        [RegularExpression("([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\\s?[0-9][A-Za-z]{2})",
         ErrorMessage = "Please enter a valid postcode.")]
        public string Postcode { get; set; }

        [Required]
        [Range(0, 2.5)]
        [Display(Name = "Height (metres)")]
        public double Height { get; set; }
    }
}