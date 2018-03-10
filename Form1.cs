using IAEchecs.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAEchecs
{
    public partial class MainWindowForm : Form
    {

        private CaseEchec[,] casesEchec;

        public MainWindowForm()
        {
            InitializeComponent();
            
        }

        private void MainWindowForm_Load(object sender, EventArgs e)
        {
            casesEchec = new CaseEchec[8, 8];

            for (int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    CaseEchec cellule = new CaseEchec(i, j);
                    casesEchec[i, j] = cellule;
                    plateauLayout.Controls.Add(cellule, i, 7-j);
                }
            }
            casesEchec[0, 1].Piece = new Pion(true);
            casesEchec[2, 0].Piece = new Fou(true);
           
        }

       
    }
}
