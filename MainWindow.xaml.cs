using System.ComponentModel;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WPF_INotifyPropertyChanged
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private string boundText;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string BoundText
        {
            get { return boundText; }
            set { 
                boundText = value;
                OnPropertyChange();
            }
        }


        void OnPropertyChange([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            BoundText = "Changed from code";
        }
    }
}