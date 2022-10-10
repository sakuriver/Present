namespace DailyApp
{
    partial class DailyReportList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ちゃんの日記一覧 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ちゃんの日記一覧
            // 
            this.ちゃんの日記一覧.AutoSize = true;
            this.ちゃんの日記一覧.Font = new System.Drawing.Font("Yu Gothic UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ちゃんの日記一覧.Location = new System.Drawing.Point(255, 41);
            this.ちゃんの日記一覧.Name = "ちゃんの日記一覧";
            this.ちゃんの日記一覧.Size = new System.Drawing.Size(411, 72);
            this.ちゃんの日記一覧.TabIndex = 1;
            this.ちゃんの日記一覧.Text = "ちゃんの日記一覧";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(20, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(510, 568);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DailyReportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 801);
            this.Controls.Add(this.ちゃんの日記一覧);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DailyReportList";
            this.Text = "DailyReportList";
            this.Load += new System.EventHandler(this.DailyReportList_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label ちゃんの日記一覧;
        private ListView listView1;
        private GroupBox groupBox1;
    }
}