using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_vivaviatravel2.Models
{
    [Table("Destino")]
    public class DestinoModel
    {
        [Key]
        public int DestinoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(100)]
        public string Estado { get; set; }

        public string Descricao { get; set; }

        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        public DestinoModel()
        {
            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Morbi rutrum purus at ligula fermentum, eget faucibus arcu egestas. " +
                "Donec et dictum diam. Vestibulum non rhoncus nisl. Fusce nec diam at.";
            ImagemUrl = "https://picsum.photos/500/300/?blur=10";
        }

    }
}
