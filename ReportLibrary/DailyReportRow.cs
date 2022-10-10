namespace ReportLibrary
{
    /// <summary>
    /// 日記の１行
    /// </summary>
    public class DailyReportRow
    {
        /// <summary>
        /// 日付
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// 日記のタイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 日記の本文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 日記の初期化
        /// </summary>
        public DailyReportRow()
        {
            this.Title = "";
            this.Body = "";
        }


    }
}