using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Entities.DTO.InputDTO
{
    public class StudentForUpdationDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string ContactNo { get; set; }


        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
