using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancesWPF.Validators
{
    public class CustomValidator: ICustomValidator
    {
        public void Validate<T>(T entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity);
            var errors = "";
            if (!Validator.TryValidateObject(entity, context, results, true))
                foreach (var result in results)
                    errors += result.ErrorMessage+"\n";
            if(errors != "")
                throw new ValidationException(errors);
            
        }
    }
}
