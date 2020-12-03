using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudClientProd.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome!")]
        public string Name { get; set; }
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O preço é obrigatório!", AllowEmptyStrings = false)]
        public decimal Price { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
    }
}
