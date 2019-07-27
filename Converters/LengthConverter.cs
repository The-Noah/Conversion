using System.Windows.Controls;

namespace Conversion.Converters{
  public class LengthConverter : Converter {
    public override string[] measurements => new string[]{"Inch", "Centimeter", "Foot", "Millimeter"};
    public override string name => "Length";

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

      if(fromIndex == 0 && toIndex == 1){ // inch -> cm
        to = from * 2.54;
      }else if(fromIndex == 1 && toIndex == 0){ // cm -> inch
        to = from / 2.54;
      }else if(fromIndex == 0 && toIndex == 2){ // inch -> foot
        to = from / 12.0;
      }else if(fromIndex == 1 && toIndex == 2){ // cm -> foot
        to = from / 30.48;
      }else if(fromIndex == 2 && toIndex == 0){ // foot -> inch
        to = from * 12;
      }else if(fromIndex == 2 && toIndex == 1){ // foot -> cm
        to = from * 30.48;
      }else if(fromIndex == 0 && toIndex == 3){ // inch -> mm
        to = from * 2.54 * 10.0;
      }else if(fromIndex == 1 && toIndex == 3){ // cm -> mm
        to = from * 10.0;
      }else if(fromIndex == 2 && toIndex == 3){ // foot -> mm
        to = from * 304.8;
      }else if(fromIndex == 3 && toIndex == 0){ // mm -> inch
        to = from / 25.4;
      }else if(fromIndex == 3 && toIndex == 1){ // mm -> cm
        to = from / 10.0;
      }else if(fromIndex == 3 && toIndex == 2){ // mm -> foot
        to = from / 304.8;
      }

      toTextBox.Text = to.ToString();
    }
  }
}
