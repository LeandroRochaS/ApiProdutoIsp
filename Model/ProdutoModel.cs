using System.ComponentModel.DataAnnotations;

namespace ProdutoExempoApiSolid.Model
{
    public class ProdutoModel
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }


        public decimal Preco { get; set; }
    }
}
