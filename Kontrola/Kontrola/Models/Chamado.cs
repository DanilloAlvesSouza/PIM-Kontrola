using Kontrola.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Kontrola.Models
{
    [Table("Chamados")]
    public class Chamado
    {
        private readonly AppDbContext _context;

        public Chamado(AppDbContext context)
        {
            _context = context;
        }
        public Chamado()
        {
        }

        [Key]
        public int ChamadoId { get; set; }

        [Required(ErrorMessage = "Obrigatorio Escolher a data de inicio do chamado")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Obrigatorio Escolher a data de fechamento do chamado")]
        public DateTime DataFechamento { get; set; }

        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }

        public string Diagnostico { get; set; }

        public string Pendencia { get; set; }

        public string Conclusao { get; set; }

        public List<ItemChamado> ItemChamados { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int ModalidadeId { get; set; }
        public virtual Modalidade Modalidade { get; set; }

        public int GravidadeId { get; set; }
        public virtual Gravidade Gravidade { get; set; }

        public int UrgenciaId { get; set; }
        public virtual Urgencia Urgencia { get; set; }

        public int TendenciaId { get; set; }
        public virtual Tendencia Tendencia { get; set; }


        public void AdicionaAoChamado(Equipamento equipamento)
        {
            var chamadoItem = _context.ItemChamados.SingleOrDefault(
                s => s.EquipamentoId == equipamento.EquipamentoId &&
                s.ChamadoId == ChamadoId);
            if (chamadoItem == null)
            {
                chamadoItem = new ItemChamado
                {
                    Equipamento = equipamento,
                    Quantidade = 1
                };
                _context.ItemChamados.Add(chamadoItem);
            }
            else
            {
                chamadoItem.Quantidade++;
            }

            _context.SaveChanges();
        }

        public void RemoverDoChamado(Equipamento equipamento)
        {
            var chamadoItem = _context.ItemChamados.SingleOrDefault(
                s => s.EquipamentoId == equipamento.EquipamentoId &&
                s.ChamadoId == ChamadoId);

            if (chamadoItem != null)
            {
                if (chamadoItem.Quantidade > 1)
                {
                    chamadoItem.Quantidade--;
                }
                else
                {
                    _context.ItemChamados.Remove(chamadoItem);
                }
            }
            _context.SaveChanges();
        }

        public List<ItemChamado> GetItemChamados()
        {
            return ItemChamados ?? 
                    (ItemChamados =
                    _context.ItemChamados.
                    Where(c => c.ItemChamadoId == ChamadoId).Include(s => s.Equipamento).ToList());
        }
        
        public void LimparChamados()
        {
            var chamadosItens = _context.ItemChamados.Where(chamado => chamado.ChamadoId == ChamadoId);

            _context.ItemChamados.RemoveRange(chamadosItens);
        }


    }
}
