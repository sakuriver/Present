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
    public partial class DailySelectAfter : Form
    {

        // 日記を書く女の子を選択する
        public int DailySelectCharacterId { get; set; }

        // 日記を新規か上書きか
        public int UpdateMode { get; set; }

        public DailySelectAfter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 日記を書く人を選択した後の更新処理
        /// </summary>
        public void UpdateDailyMode()
        {

            // 前画面で選択したキャラクターの情報を使用する

            if (DailySelectCharacterId == 1)
            {
                // 透明探偵の場合
                pictureBox1.Show();
                pictureBox2.Hide();
            }
            else 
            {
                // 再生のカーネルの場合
                pictureBox1.Hide();
                pictureBox2.Show();
            }


        }

        private void DailySelectAfter_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DailyForm dailyForm = new DailyForm();
            dailyForm.Show();
            dailyForm.SelectCharacterId = DailySelectCharacterId;
            dailyForm.SetupDailyInformatiion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DailyForm dailyForm = new DailyForm();
            dailyForm.Show();
            dailyForm.SelectCharacterId = DailySelectCharacterId;
            dailyForm.SetupDailyInformatiion();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DailyForm dailyForm = new DailyForm();
            dailyForm.Show();
            dailyForm.SelectCharacterId = DailySelectCharacterId;
            dailyForm.SetupDailyInformatiion();
        }

        /// <summary>
        /// 過去に投稿してくれた日記一覧を確認する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // 夏月か、助手の日記一覧
            DailyReportList reportList = new DailyReportList();
            reportList.Show();
            reportList.SelectCharacterId = DailySelectCharacterId;
            reportList.LoadDisplayData();
        }

    }
}
