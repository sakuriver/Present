using ReportLibrary;
namespace DailyApp
{

    /// <summary>
    /// 日記きろく画面
    /// </summary>
    public partial class DailyForm : Form
    {

        // カレンダーの年
        public int SelectYear { get; set; }
        // カレンダーの月
        public int SelectMonth { get; set; }
        // カレンダーの日
        public int SelectDay { get; set; }

        /// <summary>
        ///日記をつける子の番号 
        /// </summary>
        public int SelectCharacterId { get; set; }


        /// <summary>
        /// にっきを保存しておくディレクトリ
        /// </summary>
        private string baseDirPath;

        /// <summary>
        /// 
        /// </summary>
        private ReportSaveLib reportSaveLib;

        public DailyForm()
        {
            baseDirPath = Directory.GetCurrentDirectory();

            InitializeComponent();
            // にっきを作った後に、当日が多いので当日の開きなおしをしている
            DateTime dateTime = DateTime.Now;
            SelectYear = dateTime.Year;
            SelectMonth = dateTime.Month;
            SelectDay = dateTime.Day;

            // 保存するにっきライブラリから情報を取得する
            reportSaveLib = new ReportSaveLib();
            reportSaveLib.SetUpReportMap(SelectYear, SelectMonth, SelectDay);
            // カレンダーの日記情報を読み込む
            label4.Text = SelectYear.ToString();
            label5.Text = SelectMonth.ToString();
            label6.Text = SelectDay.ToString();
        }


        /// <summary>
        /// 新しいカレンダーの日付情報を読み込む
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            var changeYear = reportSaveLib.DailyReportMap.ContainsKey(SelectYear) == false;
           SelectYear = monthCalendar1.SelectionStart.Year;
           if (changeYear) {
                reportSaveLib.DailyReportMap.Add(SelectYear, new Dictionary<int, Dictionary<int, DailyReportRow>>());
           }


           SelectMonth = monthCalendar1.SelectionStart.Month;
           var changeMonth = reportSaveLib.DailyReportMap[SelectYear].ContainsKey(SelectMonth) == false;
           if (changeMonth) {
                reportSaveLib.DailyReportMap[SelectYear].Add(SelectMonth, new Dictionary<int, DailyReportRow>());
           }

           reportSaveLib.DailyReportMap[SelectYear][SelectMonth][SelectDay] = new DailyReportRow();
           SelectMonth = monthCalendar1.SelectionStart.Month;
           SelectDay = monthCalendar1.SelectionStart.Day;
           // 何月何日かの情報を画面用に反映をする
           label4.Text = SelectYear.ToString();
           label5.Text = SelectMonth.ToString();
           label6.Text = SelectDay.ToString();
            // 日記を付けていたら、読み込む
            if (reportSaveLib.IsDailyReport(SelectYear, SelectMonth, SelectDay))
            {
                textBox1.Text = reportSaveLib.DailyReportMap[SelectYear][SelectMonth][SelectDay].Title;
                richTextBox1.Text = reportSaveLib.DailyReportMap[SelectYear][SelectMonth][SelectDay].Body;
            }
            else
            {
                // 新しい日付だったらカレンダー情報を再作成する
                if (reportSaveLib.DailyReportMap.ContainsKey(SelectYear) == false)
                {
                    reportSaveLib.DailyReportMap[SelectYear] = new Dictionary<int, Dictionary<int, DailyReportRow>>();
                }

                if (reportSaveLib.DailyReportMap[SelectYear].ContainsKey(SelectMonth) == false)
                {
                    reportSaveLib.DailyReportMap[SelectYear][SelectMonth] = new Dictionary<int, DailyReportRow>();
                }
                reportSaveLib.DailyReportMap[SelectYear][SelectMonth][SelectDay] = new DailyReportRow();
                reportSaveLib.DailyReportMap[SelectYear][SelectMonth][SelectDay].Day = SelectDay;
            }

            // 月の日記情報を読み込む
            readDailyReport();

        }

        private void readDailyReport()
        {
            // DailyReportYearMonthCharacterId.csvを読み込む
            // 先頭文字列 DailyReport
            // Year       選択年
            // Month      選択月
            // CharacterId 日記を書いている子

            string line = "";
            var filePath =  reportSaveLib.CreateDailyReportFilePath(baseDirPath, SelectYear, SelectMonth, SelectCharacterId);
            // 新しい月の場合は、何もしないで終了
            if (File.Exists(filePath) == false) {
                label11.Text = "0";
                return;
            }
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Unicode, false))
            {
                var isBaseSaveData = false;
                var monthlyDayCount = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        continue;
                    }
                    var columns = line.Split(",");
                    if (columns.Length < 3)
                    {
                        continue;
                    }
                    var dayInt = int.Parse(columns[0].Replace("\"", ""));
                    if (reportSaveLib.DailyReportMap[SelectYear][SelectMonth].ContainsKey(dayInt) == false)
                    {
                        // 日記を読み込む
                        reportSaveLib.DailyReportMap[SelectYear][SelectMonth][dayInt] = new DailyReportRow();
                    }
                    reportSaveLib.DailyReportMap[SelectYear][SelectMonth][dayInt].Day = dayInt;
                    reportSaveLib.DailyReportMap[SelectYear][SelectMonth][dayInt].Title = columns[1];
                    reportSaveLib.DailyReportMap[SelectYear][SelectMonth][dayInt].Body = columns[2].Replace("\"", "");
                    if (reportSaveLib.DailyReportMap[SelectYear][SelectMonth][dayInt].Title.Length > 0 &&
                        reportSaveLib.DailyReportMap[SelectYear][SelectMonth][dayInt].Body.Length > 0) { 
                        // 投稿済みの日記の場合はカウントをする
                        monthlyDayCount ++;

                    }
                    // uiに画面を反映する
                    if (SelectDay == dayInt)
                    {
                        textBox1.Text = reportSaveLib.DailyReportMap[SelectYear][SelectMonth][SelectDay].Title;
                        richTextBox1.Text = reportSaveLib.DailyReportMap[SelectYear][SelectMonth][SelectDay].Body;
                        isBaseSaveData = true;
                    }
                    DateTime dateTime = new DateTime(SelectYear,SelectMonth,dayInt);
                    monthCalendar1.AddMonthlyBoldedDate(dateTime);
                }
                
                // 貰った日記の数を数えてくれる
                label11.Text = monthlyDayCount.ToString();

                // 日記で保存していない日だったら、空文字にする
                if (isBaseSaveData == false)
                {
                    textBox1.Text = "";
                    richTextBox1.Text = "";
                }
            }
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        // 日記を新しく上書きする
        // 選択した年              SelectYear
        // 選択した月              SelectMonth
        // 選択した日              SelectDay
        // 日記の本文と件名        richTextBoxとtextbox
        private void appendWriteReport()
        {

            // 今書いた、日記の内容をメモリに保存しておく
            reportSaveLib.DailyReportMap[SelectYear][SelectMonth][SelectDay].Title = textBox1.Text;
            reportSaveLib.DailyReportMap[SelectYear][SelectMonth][SelectDay].Body = richTextBox1.Text;

            // アプリ終了後でセーブデータを保存する
            var filePath = reportSaveLib.CreateDailyReportFilePath(baseDirPath, SelectYear, SelectMonth, SelectCharacterId);
            if (File.Exists(filePath) == false) { 
                File.Create(filePath).Close();
            }
            using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Unicode))
            {
                // 当月のカレンダーを一括保存
                sw.Flush();
                foreach (KeyValuePair<int, DailyReportRow> row in reportSaveLib.DailyReportMap[SelectYear][SelectMonth] )
                {
                    // つけた日記を先生に提出する
                    // 日,件名,本文でせいとからの日記を受け取る
                    sw.WriteLine("{0},{1},{2}", row.Key, row.Value.Title, row.Value.Body);
                }
                MessageBox.Show("にっきつけたよ", "先生よろしくね", MessageBoxButtons.OK);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 日記を保存する
            appendWriteReport();

            MessageBox.Show("にっきつけたよ", "先生よろしくね", MessageBoxButtons.OK);

        }

        /// <summary>
        /// どっちの、日記ちょうかを確認する
        /// </summary>
        public void SetupDailyInformatiion()
        {
            if (SelectCharacterId == 1) {
                pictureBox1.Hide();
                pictureBox2.Show();
            }else {
                pictureBox1.Show();
                pictureBox2.Hide();
            }
            // 月の日記情報を読み込む
            readDailyReport();
        }

    }
}
