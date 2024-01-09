using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace api_vivaviatravel2.Models
{
    [Table("Hospedagem")]
    public class HospedagemModel
    {

        [Key]
        [Required]
        public int HospedagemId { get; set; }

        [Required]
        public string? NomeHotel { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required]
        public string? Localizacao { get; set; }

        //[Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Avaliacao { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoDiaria { get; set; }

       // [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        [JsonIgnore]
        public ICollection<ReservaModel> Reservas { get; set; }

        public HospedagemModel()
        {
            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Morbi rutrum purus at ligula fermentum, eget faucibus arcu egestas. " +
                "Donec et dictum diam. Vestibulum non rhoncus nisl. Fusce nec diam at.";
            ImagemUrl = "https://picsum.photos/500/300/?blur=10";
        }

    }


}
