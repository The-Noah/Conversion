using System.Windows.Controls;

namespace Conversion.Converters{
  public class LengthConverter : Converter{
    public override string[] measurements => new string[]{"Inch", "Centimeter", "Foot", "Millimeter"};
    public override string name => "Length";

    private const double INCH_TO_METER = .0254;
    private const double CM_TO_METER = .01;
    private const double FOOT_TO_METER = .3048;
    private const double MM_TO_METER = .001;

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
        return INCH_TO_METER;
      }else if(index == 1){
        return CM_TO_METER;
      }else if(index == 2){
        return FOOT_TO_METER;
      }else if(index == 3){
        return MM_TO_METER;
      }

      return 1.0;
    }
  }
}
