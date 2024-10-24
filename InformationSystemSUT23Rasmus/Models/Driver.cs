using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InformationSystemSUT23Rasmus.Models
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        [Column(TypeName = "nvarChar(50)")]
        [Required(ErrorMessage = "Driver name is required")]
        public string DriverName { get; set; }
        [Column(TypeName = "nvarChar(7)")]
        [Required(ErrorMessage = "Registration nummer is required")]
        public string CarReg { get; set; }
        public DateTime NoteDate { get; set; } = DateTime.Now;
        [Column(TypeName = "nvarChar(150)")]
        public string? NoteDescription { get; set; }
        [Column(TypeName = "nvarChar(50)")]
        [Required(ErrorMessage = "Responsible employee is required")]
        public string ResponsibleEmployee { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Beloppet Behöver vara ett positivt tal")]
        public decimal BeloppUt { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Beloppet Behöver vara ett positivt tal")]
        public decimal BeloppIn { get; set; }
        public decimal TotalBeloppUt { get; set; }
        public decimal TotalBeloppIn { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}
