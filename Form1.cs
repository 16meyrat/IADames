using IAEchecs.Moteur;
using IAEchecs.Pieces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAEchecs
{
    public partial class MainWindowForm : Form, IAffichageEchec
    {

        internal CaseEchec[,] CasesEchec { get; private set; }
        private Jeu Jeu;

        public MainWindowForm()
        {
            InitializeComponent();
            
        }

        private void MainWindowForm_Load(object sender, EventArgs e)
        {
            CasesEchec = new CaseEchec[8, 8];

            for (int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    CaseEchec cellule = new CaseEchec(i, j);
                    CasesEchec[i, j] = cellule;
                    plateauLayout.Controls.Add(cellule, i, 7-j);
                }
            }
            CasesEchec[0, 1].Piece = new Pion(true);
            CasesEchec[2, 0].Piece = new Fou(true);
           
        }

        public void AfficherPlateau(Plateau plateau)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    CasesEchec[i, j].Piece = plateau.Grille[i, j];
                    Console.WriteLine("(" + i + ";" + j + ")");
                }
            }
        }

        public void AfficherTour(bool tourDesBlancs)
        {
            Console.WriteLine("Tour des " + (tourDesBlancs ? "Blancs" : "Noirs"));
        }

        private async void boutonDemarrer_Click(object sender, EventArgs e)
        {
            Jeu = new Jeu(new JoueurHumain(true, this), new JoueurHumain(false, this), this);
            await Jeu.Jouer();
        }
    }
}
