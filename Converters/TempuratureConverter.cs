using System;
using System.Windows.Controls;

namespace Conversion.Converters{
  public class TempuratureConverter : Converter{
    public override string[] measurements => new string[]{"Fahrenheit", "Celsius", "Kelvin"};
    public override string name => "Tempurature";

    public override void Convert(TextBox fromTextBox, TextBox toTextBox, int fromIndex, int toIndex){
      if(fromIndex == toIndex){
        toTextBox.Text = fromTextBox.Text;
        return;
      }

      double from;
      double to = 0.0;

      if(!double.TryParse(fromTextBox.Text, out from)){
        return;
      }

      if(fromIndex == 0 && toIndex == 1){ // f -> c
        to = F2C(from);
      }else if(fromIndex == 1 && toIndex == 0){ // c -> f
        to = from * (9.0 / 5.0) + 32.0;
      }else if(fromIndex == 0 && toIndex == 2){ // f -> k
        to = C2K(F2C(from));
      }else if(fromIndex == 1 && toIndex == 2){ // c -> k
        to = C2K(from);
      }else if(fromIndex == 2 && toIndex == 0){ // k -> f
        to = (from - 273.15) * (9.0 / 5.0) + 32.0;
      }else if(fromIndex == 2 && toIndex == 1){ // k -> c
        to = from - 273.15;
      }

      toTextBox.Text = to.ToString();
    }

    private static double F2C(double f){
      return (f - 32.0) * (5.0 / 9.0);
    }

    private static double C2K(double c){
      return c + 273.15;
    }
  }
}
