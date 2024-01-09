using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_vivaviatravel2.Models
{
    [Table("Pacote")]
    public class PacoteModel
    {

        [Key]
        [Required]
        public int PacoteId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PercentDesconto { get; set; }

       // [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        [ForeignKey("PassagemId")]
        public int PassagemId { get; set; }

        [ForeignKey("HospedagemId")]
        public int HospedagemId { get; set; }

        public PassagemModel Passagem { get; set; }

        public HospedagemModel Hospedagem { get; set; }

        [JsonIgnore]
        public ICollection<ReservaModel> Reservas { get; set; }

    }


}
