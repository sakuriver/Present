using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyApp
{
    public partial class DailyReportList : Form
    {

        public int SelectCharacterId;

        public DailyReportList()
        {
            InitializeComponent();

            listView1.Items.Clear();
            listView1.GridLines = true;

            // ていしゅつしてもらった日記の一覧を設定

            ColumnHeader columnYear = new ColumnHeader
            {
                Text = "年",
                Width = 50,
            };

            ColumnHeader columnMonth = new ColumnHeader
            {
                Text = "年",
                Width = 50,
            };

            ColumnHeader columnDay = new ColumnHeader
            {
                Text = "日",
                Width = 50,
            };
            ColumnHeader columnTitle = new ColumnHeader
            {
                Text = "たいとる",
                Width = 50,
            };
            ColumnHeader columnBody = new ColumnHeader
            {
                Text = "ほんぶん",
                Width = 50,
            };

            ColumnHeader[] columnHeaders = { columnYear, columnMonth, columnDay, columnTitle, columnBody };

            listView1.Columns.AddRange(columnHeaders);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DailyReportList_Load(object sender, EventArgs e)
        {

        }

        public void LoadDisplayData()
        {
            if (SelectCharacterId == 1){
                label1.Text = "助手";
            }else {
                label1.Text = "夏月";
            }
        }

    }
}
