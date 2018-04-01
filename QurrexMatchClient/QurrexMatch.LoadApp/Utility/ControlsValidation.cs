using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QurrexMatch.LoadApp.Utility
{
    public class ControlsValidation
    {
        public static void SetupErrorProvider(out ErrorProvider errorProvider, Control control)
        {
            errorProvider = new ErrorProvider();
            errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(control, 2);
            errorProvider.BlinkRate = 1000;
            errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
        }

        public static bool TextBoxRangeValidation(TextBox control, string controlLable, ErrorProvider errorProvider, int minValue, int maxValue, Type NumberType)
        {
            if (errorProvider == null)
                return true;
            if (NumberType == typeof(int))
            {
                int result;
                var isInt = int.TryParse(control.Text, out result);
                if (isInt && result >= minValue && result <= maxValue)
                {
                    errorProvider.SetError(control, String.Empty);
                    return true;
                }
            }
            else if (NumberType == typeof(double))
            {
                double result;
                var value = control.Text.Replace(',', '.');
                var isDouble = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
                if (isDouble && result >= minValue && result <= maxValue)
                    return true;
            }

            errorProvider.SetError(control, $"Wrong {controlLable} value. Can be from {minValue} to {maxValue}");
            return false;
        }

        public static bool TexBoxTypeValidation(TextBox control, string controlLable, ErrorProvider errorProvider, Type NumberType)
        {
            if (NumberType == typeof(int))
            {
                int result;
                if (int.TryParse(control.Text, out result) && result > 0)
                    return true;
            }
            else if (NumberType == typeof(double))
            {
                double result;
                var value = control.Text.Replace(',', '.');
                if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result) && result > 0)
                    return true;
            }

            errorProvider.SetError(control, $"Wrong {controlLable} value.");
            return false;
        }
    }
}
