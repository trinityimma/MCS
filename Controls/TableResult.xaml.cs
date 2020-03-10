using System.Windows.Controls;

namespace MCS.Controls
{
    /// <summary>
    /// Interaction logic for TableResult.xaml
    /// </summary>
    public partial class TableResult : DataGrid
    {
        public TableResult()
        {
            InitializeComponent();
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
