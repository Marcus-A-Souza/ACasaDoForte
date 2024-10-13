using WebApplication9.Models;

namespace WebApplication9.Models
{
    public class Cpf
    {
        [CPFValidation]
        public string CPF { get; set; }
    }
}
