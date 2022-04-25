using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }
        public override bool IsValid(object value)
        {
            var splittedDomainParts = value.ToString().Split('@');
            return allowedDomain.ToUpper().Equals(splittedDomainParts[1].ToUpper());
        }
    }
}
