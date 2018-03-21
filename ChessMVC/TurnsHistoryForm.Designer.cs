namespace ChessMVC
{
    partial class TurnsHistoryForm
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
            this.turnsHistoryListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.turnsHistoryListBox.FormattingEnabled = true;
            this.turnsHistoryListBox.Location = new System.Drawing.Point(1, -1);
            this.turnsHistoryListBox.Name = "listBox1";
            this.turnsHistoryListBox.Size = new System.Drawing.Size(424, 342);
            this.turnsHistoryListBox.TabIndex = 0;
            // 
            // TurnsHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 339);
            this.Controls.Add(this.turnsHistoryListBox);
            this.Name = "TurnsHistoryForm";
            this.Text = "Turns history";
            this.Load += new System.EventHandler(this.TurnsHistoryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox turnsHistoryListBox;
    }
}