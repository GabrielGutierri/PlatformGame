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
        string nick;
        int pontos;
        string dificuldade;
        string[] linhas = File.ReadAllLines("ranking.txt");
        public frmRanking()
        {
            
            InitializeComponent();

            try
            {
                LeArquivoTexto();
                OrdenaGrid();
            }
            catch
            {
                MessageBox.Show("Nenhuma partida encontrada!", "Ranking Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LeArquivoTexto()
        {
            for (int i = 0; i < linhas.Length; i++)
            {
                string[] dadosLinha = linhas[i].Split(';');
                nick = dadosLinha[0];
                dificuldade = dadosLinha[1];
                pontos = Convert.ToInt32(dadosLinha[2]);


                dataGridView1.Rows.Add();

                dataGridView1.Rows[i].Cells[1].Value = nick;
                dataGridView1.Rows[i].Cells[2].Value = dificuldade;
                dataGridView1.Rows[i].Cells[3].Value = pontos;
            }
        }
        void OrdenaGrid()
        {
            dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Descending);

            for (int j = 0; j < linhas.Length; j++)
            {
                string posicao = $"{j + 1}°";
                dataGridView1.Rows[j].Cells[0].Value = posicao;

            }
        }
    }
}
