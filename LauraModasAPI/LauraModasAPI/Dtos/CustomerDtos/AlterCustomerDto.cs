using System.ComponentModel.DataAnnotations;

namespace LauraModasAPI.Dtos.CustomerDtos
{
    public class AlterCustomerDto
    {
        public string Name { get; set; }

        [MaxLength(10, ErrorMessage = "Telefone Inválido")]
        public string Phone { get; set; }
    }
}
