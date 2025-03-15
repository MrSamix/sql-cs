using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace _03_WPF_ADO.NET;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    DataSet set;
    SqlDataAdapter dataAdapter;
    SqlConnection connection;
    SqlCommandBuilder build;

    public MainWindow()
    {
        InitializeComponent();
        connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
        connection.Open();
    }

    private void LoadTable(object sender, RoutedEventArgs e)
    {
        string selectedTable = ((ComboBoxItem)Tables.SelectedItem).Content.ToString();
        string query = $"SELECT * FROM {selectedTable}";

        dataAdapter = new SqlDataAdapter(query, connection);
        build = new SqlCommandBuilder(dataAdapter);

        set = new DataSet();
        dataAdapter.Fill(set, "MyTable");
        DataGrid.ItemsSource = set.Tables["MyTable"].DefaultView;
    }

    private void ApplyFilter(object sender, RoutedEventArgs e)
    {
        string filter = FilterTextBox.Text;
        string selectedTable = ((ComboBoxItem)Tables.SelectedItem).Content.ToString();
        string query;
        if (!string.IsNullOrEmpty(filter))
        {
            query = $"SELECT * FROM {selectedTable} where {filter}";
        }
        else
        {
            query = $"SELECT * FROM {selectedTable}";
        }

        dataAdapter = new SqlDataAdapter(query, connection);
        build = new SqlCommandBuilder(dataAdapter);

        set = new DataSet();
        dataAdapter.Fill(set, "MyTable");
        DataGrid.ItemsSource = set.Tables["MyTable"].DefaultView;
    }

    private void UpdateTable(object sender, RoutedEventArgs e)
    {
        dataAdapter.Update(set, "MyTable");
    }
}
