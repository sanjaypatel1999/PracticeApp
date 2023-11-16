using System.ComponentModel.DataAnnotations;

namespace ApplicationName.Models.ViewModel
{
    public class ImageCreateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please choose imagefile")]
        [Display(Name ="choose image")]
        public IFormFile ImagePath { get; set; }
    }
}
