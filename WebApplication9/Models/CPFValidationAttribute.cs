
using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class CPFValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var cpf = value as string;
            return cpf != null && IsValidCPF(cpf);
        }

        public bool IsValidCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", ""); // Remove caracteres de formatação

            if (cpf.Length != 11 || !int.TryParse(cpf, out _)) // Verifique o comprimento e o formato numérico
                return false;

            var sum = 0;
            var weight = 10;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * weight;
                weight--;
            }

            var remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            if (remainder != int.Parse(cpf[9].ToString()))
                return false;

            sum = 0;
            weight = 11;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * weight;
                weight--;
            }

            remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            return remainder == int.Parse(cpf[10].ToString());
        }
    }
}