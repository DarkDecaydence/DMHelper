using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DungeonMasterHelper.ValueConverters {
    public class NullableBoolToGenderConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (!(value is bool?))
                return string.Empty;

            if ((value as bool?) == null)
                return "None";
            else {
                return (value as bool?).Value ? "Male" : "Female";
            } 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (!(value is string))
                return null;

            var stringValue = value as string;
            if (stringValue == "Male")
                return true;
            else if (stringValue == "Female")
                return false;
            else
                return null;
        }
    }
}
