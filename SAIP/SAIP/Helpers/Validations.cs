using System;
using System.Globalization;
using System.Windows.Controls;

namespace SAIP.Helpers
{
    public class ValidationStringEmpty : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value.ToString();

            if (input.Equals(""))
            {
                return new ValidationResult(false, string.Format("Este campo es Obligatorio"));
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }

    public class ValidarCampoFecha : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value.ToString();
            DateTime fecha;

            if (DateTime.TryParse(input,out fecha))
            {
                return new ValidationResult(false, string.Format("La fecha ingresada no es válida"));
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
