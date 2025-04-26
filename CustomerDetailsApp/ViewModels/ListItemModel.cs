using System.ComponentModel.DataAnnotations;

namespace CustomerDetailsApp.ViewModels
{
    public class ListItemModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Postcode { get; set; }

        [Display(Name = "Date Registered")]
        public string DateRegistered { get; set; }
    }
}