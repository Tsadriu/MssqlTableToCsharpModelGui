using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MssqlTableToCsharpModelGui.Classes;

namespace MssqlTableToCsharpModelGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddConnectionStringButton_Click(object sender, RoutedEventArgs e)
        {
            //Open dialog for adding new connection
            var dialog = new AddConnectionStringDialog();
            if (dialog.ShowDialog() == true)
            {
                //Save the connection string to file
                System.IO.File.WriteAllText("connectionString.txt", dialog.ConnectionString);
            }
        }

        private void LoadSchemas_Click(object sender, RoutedEventArgs e)
        {
            //Read the saved connection string from file
            var connectionString = System.IO.File.ReadAllText("connectionString.txt");
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT schema_name FROM information_schema.schemata", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Add each schema name to a ListBox (schemasListBox) in your XAML
                        schemasListBox.Items.Add(reader.GetString(0));
                    }
                }
            }
        }

        private void SchemasListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clear previously loaded tables
            tablesListBox.Items.Clear();

            //Load tables of the selected schema
            var selectedSchema = schemasListBox.SelectedItem.ToString();
            var connectionString = System.IO.File.ReadAllText("connectionString.txt");
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT table_name FROM information_schema.tables WHERE table_schema = '{selectedSchema}'", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Add each table name to a ListBox (tablesListBox) in your XAML
                        tablesListBox.Items.Add(reader.GetString(0));
                    }
                }
            }
        }
    }
}
