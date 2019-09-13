using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Models
{
    [Table("Employees")]
    public class UserModel
    {
        [Key] [Column(Order = 0)] [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [MaxLength(32)] [Column(Order = 1)] [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [MaxLength(32)] [Column(Order = 2)] [DefaultValue("")]
        public string LastName { get; set; }

        [Key] [MaxLength(320)] [Column(Order = 3)]
        public string Email { get; set; }

        [Column(Order = 4)] [Required(AllowEmptyStrings = false)]
        public bool IsStudent { get; set; }

        [MinLength(64)] [MaxLength(64)] [Column(Order = 5)]
        public string Password { get; set; }
    }
}
