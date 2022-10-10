using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLibrary
{
    /// <summary>
    /// 皆の日記共通のファイル情報
    /// </summary>
    public class ReportSaveLib
    {
        /// <summary>
        /// 保存する子供に指定されたマイナンバーみたいなもの
        /// </summary>
        public int SelectCharacterId;

        /// <summary>
        /// 日記の一覧
        /// 年→月から検索をする
        /// </summary>
        public Dictionary<int, Dictionary<int, Dictionary<int, DailyReportRow>>> DailyReportMap = new Dictionary<int, Dictionary<int, Dictionary<int, DailyReportRow>>>();

        /// <summary>
        /// にっきのファイル名を作成
        /// </summary>
        /// <param name="dirPath">日記保存箇所のディレクトリ</param>
        /// <param name="year">日記の年</param>
        /// <param name="month">日記の月</param>
        /// <param name="selectCaharacterId">日記をつけるこの番号</param>
        /// <returns></returns>
        public string CreateDailyReportFilePath(string dirPath, int year, int month, int selectCaharacterId)
        {
            return String.Format("{0}\\DailyReport{1}{2}{3}.csv", dirPath, year, month, selectCaharacterId);
        }

        /// <summary>
        /// 日記保存情報を年月日していしてセットアップする
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        public void SetUpReportMap(int year, int month, int day)
        {
            DailyReportMap.Add(year, new Dictionary<int, Dictionary<int, DailyReportRow>>());
            DailyReportMap[year].Add(month, new Dictionary<int, DailyReportRow>());
            DailyReportMap[year][month][day] = new DailyReportRow();
        }

        /// <summary>
        /// 書いてもらった子供のにっきを保存する
        /// </summary>
        public void AppendWriteReport( string DirPath,int SelectYear, int SelectMonth, int SelectDay, string title, string body)
        {
            // 今書いた、日記の内容をメモリに保存しておく
            DailyReportMap[SelectYear][SelectMonth][SelectDay].Title = title;
            DailyReportMap[SelectYear][SelectMonth][SelectDay].Body = body;

            // アプリ終了後でセーブデータを保存する
            var filePath = CreateDailyReportFilePath(DirPath, SelectYear, SelectMonth, SelectCharacterId);
            if (File.Exists(filePath) == false)
            {
                File.Create(filePath).Close();
            }
            using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Unicode))
            {
                // 当月のカレンダーを一括保存
                sw.Flush();
                foreach (KeyValuePair<int, DailyReportRow> row in DailyReportMap[SelectYear][SelectMonth])
                {
                    // つけた日記を先生に提出する
                    // 日,件名,本文でせいとからの日記を受け取る
                    sw.WriteLine("{0},{1},{2}", row.Key, row.Value.Title, row.Value.Body);
                }
            }

        }

        /// <summary>
        /// 日記を既に書いていたことがあるか
        /// </summary>
        /// <returns>日記が存在していればtrue</returns>
        public bool IsDailyReport(int SelectYear, int SelectMonth, int SelectDay)
        {
            // 未来や生まれる前の日記は存在しないので終了
            if (DailyReportMap.ContainsKey(SelectYear) == false)
            {
                return false;
            }
            if (DailyReportMap[SelectYear].ContainsKey(SelectMonth) == false)
            {
                return false;
            }
            if (DailyReportMap[SelectYear][SelectMonth].ContainsKey(SelectDay) == false)
            {
                return false;
            }

            return true;
        }


    }
}
