using System.ComponentModel.DataAnnotations;


namespace BlazorShop.Models.DTOs;

public class CarrinhoItemAtualizaQuantidadeDTO
{
    [Required]
    public int CarrinhoItemId { get; set; }

    [Required]
    public int Quantidade { get; set; }

}
