using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_vivaviatravel2.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {

        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(150)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(150)]
        public string? Email { get; set;}

        [Required]
        [StringLength(20)]
        public string? Senha { get; set; }

        [StringLength(20)]
        public string? Telefone { get; set;}

        [JsonIgnore]
        public ICollection<ReservaModel> Reservas { get; set; }

    }
}
