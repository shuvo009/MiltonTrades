// -----------------------------------------------------------------------
// <copyright file="MinusTwoValue.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MiltonTrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Data;
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class balance : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                decimal balance = 0;
                if (values[0] != null && values[1] != null)
                {
                    balance = System.Convert.ToDecimal(values[0]) - System.Convert.ToDecimal(values[1]);
                }
                return balance.ToString();
            }
            catch
            {
                return 0;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
