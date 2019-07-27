using System.Windows.Controls;

namespace Conversion.Converters{
  public class LengthConverter : Converter {
    public override string[] measurements => new string[]{"Inch", "Centimeter"};
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
      }

      toTextBox.Text = to.ToString();
    }
  }
}
