using CommunityToolkit.Maui.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui;

namespace ChainSpy.Converters
{
   
    public class BarcodeDetectedEventArgsConverter : BaseConverterOneWay<BarcodeDetectionEventArgs?, object?>
    {
        [return: NotNullIfNotNull("value")]
        public override object ConvertFrom(BarcodeDetectionEventArgs value, CultureInfo culture) => value switch
        {
            null => null,
            _ => value.Results
        };
    }
}
