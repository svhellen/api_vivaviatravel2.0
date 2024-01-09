using api_vivaviatravel2.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_vivaviatravel2.Models
{
    [Table("Reserva")]
    public class ReservaModel
    {
        [Key]
        public int ReservaId { get; set; }

        [Required]
        public string? TipoServico => CalcularTipoServico();

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        [ForeignKey("PassagemId")]
        public int? PassagemId { get; set; }

        [ForeignKey("HospedagemId")]
        public int? HospedagemId { get; set; }

        [ForeignKey("PacoteId")]
        public int? PacoteId { get; set; }

        public ClienteModel Cliente { get; set; }
        public PassagemModel Passagem { get; set; }
        public HospedagemModel Hospedagem { get; set; }
        public PacoteModel Pacote { get; set; }

        private string? CalcularTipoServico()
        {
            return PassagemId.HasValue ? "Passagem" :
                   HospedagemId.HasValue ? "Hospedagem" :
                   PacoteId.HasValue ? "Pacote" :
                   "null error";
        }

    }
}
