﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace BattleShip
{
    public class SizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double) value * double.Parse(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double) value / double.Parse(parameter.ToString());
        }
    }
}
