using Conversion.Converters;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Conversion{
  public partial class MainWindow : Window{
    private static readonly Regex numberRegex = new Regex("[^0-9.-]+");

    private List<Converter> converters = new List<Converter>();
    private int currentConverter = 0;

    public MainWindow(){
      InitializeComponent();

      converters.Add(new TempuratureConverter());
      converters.Add(new Converters.LengthConverter());

      foreach(Converter converter in converters){
        MeasurementComboBox.Items.Add(new ComboBoxItem(){
          Content = converter.name
        });
      }

      FromComboBox.ItemsSource = converters[currentConverter].measurements;
      ToComboBox.ItemsSource = converters[currentConverter].measurements;

      MeasurementComboBox.SelectedIndex = currentConverter;
    }

    private void UpdateCalculation(){
      converters[currentConverter].Convert(FromTextBox, ToTextBox, FromComboBox.SelectedIndex, ToComboBox.SelectedIndex);
    }

    private void TextBox_KeyUp(object sender, KeyEventArgs e){
      UpdateCalculation();
    }

    private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e){
      if(!e.DataObject.GetDataPresent(typeof(string))){
        e.CancelCommand();
        return;
      }

      string text = (string)e.DataObject.GetData(typeof(string));
      if(numberRegex.IsMatch(text)){
        e.CancelCommand();
      }
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
      UpdateCalculation();
    }

    private void SwapButton_Click(object sender, RoutedEventArgs e){
      int tmpIndex = FromComboBox.SelectedIndex;
      FromComboBox.SelectedIndex = ToComboBox.SelectedIndex;
      ToComboBox.SelectedIndex = tmpIndex;
    }

    private void MeasurementComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
      int index = (sender as ComboBox).SelectedIndex;

      if(index >= converters.Count || index < 0){
        (sender as ComboBox).SelectedIndex = 0;
        index = 0;
      }

      currentConverter = index;

      FromComboBox.ItemsSource = converters[currentConverter].measurements;
      ToComboBox.ItemsSource = converters[currentConverter].measurements;

      FromComboBox.SelectedIndex = 0;
      ToComboBox.SelectedIndex = 1;
    }
  }
}
