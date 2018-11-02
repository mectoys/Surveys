


namespace Surveys.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Xamarin.Forms;

    public class TeamColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value==null)
            {
                return null;
            }

            var team = (string)value;
            var color = Color.Transparent;

       

            switch (team)
            {
                case "América":
                case "Peñarol":
                    color = Color.Yellow;
                    break;
                case "Boca junior":
                case "Alianza Lima":
                    color = Color.Blue;
                    break;
                case "Caracas FC":
                case "Saprissa":
                    color = Color.Purple;
                    break;
                case "Real Madrid":
                    color = Color.Fuchsia;
                    break;             
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
