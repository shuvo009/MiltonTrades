// -----------------------------------------------------------------------
// <copyright file="SumDeposit.cs" company="">
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
    public class SumDeposit :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal totalDeposit = 0;
            try
            {
                if (value != null)
                {
                    var transctionInfo = value as BindingListCollectionView;
                    foreach (var teansction in transctionInfo)
                    {
                        if ((teansction as TransictionTable) != null)
                        {
                            totalDeposit += (teansction as TransictionTable).DepositAmount;
                        }
                    }
                }
                return totalDeposit;
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
