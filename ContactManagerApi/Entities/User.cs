using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManagerApi.Entities
{
    public class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
            Contacts = new HashSet<Contact>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required, MaxLength(1000)]
        public string PasswordSalt { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(10)]
        public string Gender { get; set; }

        [Required, MaxLength(100)]
        public bool Active { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}