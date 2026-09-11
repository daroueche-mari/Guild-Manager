using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuildManagerProjet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InfoQuestOne.Text = "1";
            InfoQuestTwo.Text = "1";

        }
        public void ToResolveQuestOne(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.NarrationTextBlock.Text = "Je teste la premiere quete";
            gameWindow.Show();
        }

        public void ToResolveQuestTwo(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.NarrationTextBlock.Text = "Je teste la deuxieme quete";
            gameWindow.Show();
        }
    }
}