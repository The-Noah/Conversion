using System.Windows.Controls;

namespace Conversion.Converters{
  public abstract class Converter{
    public abstract string[] measurements{get;}
    public abstract string name{get;}

    public abstract void Convert(TextBox fromTextBox, TextBox toTextBox, int fromIndex, int toIndex);
  }
}
