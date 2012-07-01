// -----------------------------------------------------------------------
// <copyright file="SumWithDraw.cs" company="">
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
    public class SumWithDraw : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                decimal totalWithDrawAmount = 0;
                if (value != null)
                {
                    var transctionInfo = value as BindingListCollectionView;
                    foreach (var teansction in transctionInfo)
                    {
                        if ((teansction as TransictionTable) != null)
                        {
                            totalWithDrawAmount += (teansction as TransictionTable).WithdrawAmount;
                        }
                    }
                }
                return totalWithDrawAmount;
            }
            catch
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
