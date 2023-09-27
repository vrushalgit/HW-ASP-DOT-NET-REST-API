using System.ComponentModel.DataAnnotations;

namespace HWRESTAPIS.Models {
    public class CustomValidatioForCustomer : ValidationAttribute {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {

            var customer = (CustomerModel)validationContext.ObjectInstance;

            if( customer.CustFullName != null && customer.CustFullName.Any() )
                return ValidationResult.Success;

            return new ValidationResult("Please Enter Your Full Name (Lastname Firstname Middlename)");

        }
    }
}
