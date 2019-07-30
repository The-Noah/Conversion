using System.Windows.Controls;

namespace Conversion.Converters{
  public class LengthConverter : Converter{
    public override string[] measurements => new string[]{"Inch", "Foot", "Yard", "Mile", "Millimeter", "Centimeter", "Meter", "Kilometer"};
    public override string name => "Length";

    private const double INCH_TO_METER = .0254;
    private const double FOOT_TO_METER = .3048;
    private const double YARD_TO_METER = .9144;
    private const double MILE_TO_METER = 1609.344;
    private const double MM_TO_METER = .001;
    private const double CM_TO_METER = .01;
    private const double KM_TO_METER = 1000.0;

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
        return FOOT_TO_METER;
      }else if(index == 2){
        return YARD_TO_METER;
      }else if(index == 3){
        return MILE_TO_METER;
      }else if(index == 4){
        return MM_TO_METER;
      }else if(index == 5){
        return CM_TO_METER;
      }else if(index == 6){
        return 1.0;
      }else if(index == 7){
        return KM_TO_METER;
      }

      return 0.0;
    }
  }
}
