using System.ComponentModel.DataAnnotations;

namespace WearOutTCC_API.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(12)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        [Range(11, 11)]
        public long Cpf { get; set; }
        [StringLength(50)]
        public string Endereco { get; set; }
        [StringLength(30)]
        public string Cidade { get; set; }
        [StringLength(2)]
        public string Estado { get; set; }
        [Range(8, 8)]
        public long Cep { get; set; }
        public char tipo { get; set; }
    }
}
