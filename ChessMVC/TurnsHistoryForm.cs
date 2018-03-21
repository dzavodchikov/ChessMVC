using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessMVC
{
    public partial class TurnsHistoryForm : Form
    {
        private ChessBoard board;

        public TurnsHistoryForm(ChessBoard board)
        {
            InitializeComponent();
            this.board = board;
            this.board.OnChanged += this.UpdateHistory;
        }

        private void TurnsHistoryForm_Load(object sender, EventArgs e)
        {
            this.UpdateHistory();
        }

        private void UpdateHistory()
        {
            this.turnsHistoryListBox.Items.Clear();
            foreach(String turn in this.board.Turns) {
                this.turnsHistoryListBox.Items.Add(turn);
            }
        }

    }
}
