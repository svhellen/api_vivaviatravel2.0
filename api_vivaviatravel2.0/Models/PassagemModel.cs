using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_vivaviatravel2.Models
{
    [Table("Passagem")]
    public class PassagemModel
    {

        [Key]
        [Required]
        public int PassagemId { get; set; }

        [Required]
        public string? Origem { get; set; }

        [Required]
        public string? Destino { get; set; }

        [Required]
        public string? Classe { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

       // [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        public DateTime DataVoo { get; set; }

        [JsonIgnore]
        public ICollection<ReservaModel> Reservas { get; set; }
    public PassagemModel()
    {
        ImagemUrl = "https://picsum.photos/500/300/?blur=10";
    }
    }




}
