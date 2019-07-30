using System.Windows.Controls;

namespace Conversion.Converters{
  public class FrequencyConverter : Converter{
    public override string[] measurements => new string[]{"Hertz", "Kilohertz", "Megahertz", "Gigahertz"};
    public override string name => "Frequency";

    private const double KH_TO_HERTZ = 1000.0;
    private const double MH_TO_HERTZ = 1000000.0;
    private const double GH_TO_HERTZ = 1000000000.0;

    public override void Convert(TextBox fromTextBox, TextBox toTextBox, int fromIndex, int toIndex){
      if(fromIndex == toIndex){
        toTextBox.Text = fromTextBox.Text;
        return;
      }

      double from;
      if(!double.TryParse(fromTextBox.Text, out from)){
        return;
      }

      toTextBox.Text = (from * GetFactor(fromIndex) / GetFactor(toIndex)).ToString();
    }

    private double GetFactor(int index){
      if(index == 0){
        return 1.0;
      }else if(index == 1){
        return KH_TO_HERTZ;
      }else if(index == 2){
        return MH_TO_HERTZ;
      }else if(index == 3){
        return GH_TO_HERTZ;
      }

      return 0.0;
    }
  }
}
