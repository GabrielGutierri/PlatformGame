using jogoN2v2._0.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogoN2v2._0
{
    public partial class frmRanking : Form
    {
        private string nickname;
        private int points;
        private string difficulty;
        private string[] lines = File.ReadAllLines("ranking.txt");
        public frmRanking()
        {
            
            InitializeComponent();

            try
            {
                ReadTextFile();
                OrderGrid();
            }
            catch
            {
                MessageBox.Show(RankingConstants.NO_MATCH_FOUND, RankingConstants.RANKING_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ReadTextFile()
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineData = lines[i].Split(';');
                nickname = lineData[0];
                difficulty = lineData[1];
                points = Convert.ToInt32(lineData[2]);


                dgvRanking.Rows.Add();

                dgvRanking.Rows[i].Cells[1].Value = nickname;
                dgvRanking.Rows[i].Cells[2].Value = difficulty;
                dgvRanking.Rows[i].Cells[3].Value = points;
            }
        }
        void OrderGrid()
        {
            dgvRanking.Sort(dgvRanking.Columns[3], ListSortDirection.Descending);

            for (int j = 0; j < lines.Length; j++)
            {
                string position = $"{j + 1}°";
                dgvRanking.Rows[j].Cells[0].Value = position;

            }
        }
    }
}
