using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ASLRConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TransformBasePreset.SelectedIndex = IntPtr.Size == 4 ? 0 : 1;
        }

        private void TextChanged(object in_sender, TextChangedEventArgs in_args)
        {
            CalculateASLR();
        }

        private void TransformBasePreset_SelectionChanged(object in_sender, SelectionChangedEventArgs in_args)
        {
            if (TransformBasePreset.SelectedIndex == 0)
            {
                TransformBaseAddressField.Text = "0x400000";
            }
            else
            {
                TransformBaseAddressField.Text = "0x140000000";
            }

            CalculateASLR();
        }

        private void ASLRRadioButtons_SelectionChanged(object in_sender, SelectionChangedEventArgs in_args)
        {
            CalculateASLR();
        }

        private void CalculateASLR()
        {
            var baseStr = BaseAddressField?.Text;
            var transformBaseStr = TransformBaseAddressField?.Text;
            var transformStr = TransformAddressField?.Text;

            if (string.IsNullOrEmpty(baseStr) ||
                string.IsNullOrEmpty(transformBaseStr) ||
                string.IsNullOrEmpty(transformStr))
            {
                return;
            }

            baseStr = baseStr.Replace("0x", "");
            transformBaseStr = transformBaseStr.Replace("0x", "");
            transformStr = transformStr.Replace("0x", "");

            if (!ulong.TryParse(baseStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var out_baseAddr))
                return;

            if (!ulong.TryParse(transformBaseStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var out_transformBaseAddr))
                return;

            if (!ulong.TryParse(transformStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var out_transformAddr))
                return;

            switch (ASLRRadioButtons?.SelectedIndex)
            {
                case 0: // From ASLR
                    ResultField.Text = $"0x{out_transformAddr + out_transformBaseAddr - out_baseAddr:X}";
                    break;

                case 1: // To ASLR
                    ResultField.Text = $"0x{out_transformAddr - out_transformBaseAddr + out_baseAddr:X}";
                    break;
            }
        }
    }
}
