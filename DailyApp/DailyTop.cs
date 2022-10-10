namespace DailyApp
{
    public partial class DailyTop : Form
    {

        private int SelectCharacterId = 1;

        public DailyTop()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            SelectCharacterId = 2;
            DailySelectAfter selectAfter = new DailySelectAfter();
            selectAfter.DailySelectCharacterId = SelectCharacterId; ;
            selectAfter.UpdateDailyMode();
            selectAfter.Show();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            SelectCharacterId = 1;
            DailySelectAfter selectAfter = new DailySelectAfter();
            selectAfter.DailySelectCharacterId = SelectCharacterId; ;
            selectAfter.UpdateDailyMode();
            selectAfter.Show();
        }
    }
}