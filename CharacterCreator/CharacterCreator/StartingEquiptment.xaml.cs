using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CharacterCreator
{
  /// <summary>
  /// Interaction logic for StartingEquiptment.xaml
  /// </summary>
  public partial class StartingEquiptment : Window
  {
    public bool gold { get; set; }
    public bool equipment { get; set; }
    public StartingEquiptment()
    {
      InitializeComponent();
    }

    private void BtnMoneyStart_Click(object sender, RoutedEventArgs e)
    {
      gold = true;
      equipment = false;
      Close();
    }

    private void BtnEquipmentStart_Click(object sender, RoutedEventArgs e)
    {
      gold = false;
      equipment = true;
      Close();
    }
    
  }
}
