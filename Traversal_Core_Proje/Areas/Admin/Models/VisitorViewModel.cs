using System.ComponentModel.DataAnnotations;

namespace Traversal_Core_Proje.Areas.Admin.Models
{
    public class VisitorViewModel
    {
        [Key]
        public int VisitorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mail { get; set; }
    }
}
