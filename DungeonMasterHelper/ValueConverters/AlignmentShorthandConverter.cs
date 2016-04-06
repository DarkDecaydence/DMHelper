using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DungeonMasterHelper.ValueConverters {
    public class AlignmentShorthandConverter : IValueConverter {

        private static readonly Regex regexTemplate = new Regex(@"([A-Z])\w+");

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (!(value is string))
                throw new ArgumentException("Convert value is not string");

            var shortHand = string.Empty;
            foreach (Match m in regexTemplate.Matches((value as string)))
                shortHand += m.Value[0];

            return shortHand;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
