using GeekLifeAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace GeekLifeAPI.Validations.Attributes
{
    public class BrazilianUFAttribute:ValidationAttribute 
    {
        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            if  (value == null || !(value is string  inpuValue))
            {
                return new ValidationResult("UF null");
            }
            string[] validUFs = new string[] { "AC", "AL", "AP", "AM","BA","CE", "DF", "ES","GO","MA","MT", "MS","MG", "PA","PB", "PR", "PE", "PI", "RJ", "RN","RS", "RN", "RS", "RO", "RR", "SC","SP", "SE","TO"};
            string inputValue = value as string;

            if(!validUFs.Contains(inputValue))
            {
                return new ValidationResult("A UF informada não pertence a lista de UF's brasileiras");
            }
            return ValidationResult.Success;
        }       
    }
}
