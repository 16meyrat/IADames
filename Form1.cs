using IADames.Moteur;
using IADames.Pieces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IADames
{
    public partial class MainWindowForm : Form, IAffichageEchec
    {

        internal CaseDames[,] CasesEchec { get; private set; }
        private Jeu Jeu;

        public MainWindowForm()
        {
            InitializeComponent();
            
        }

        private void MainWindowForm_Load(object sender, EventArgs e)
        {
            CasesEchec = new CaseDames[10, 10];

            for (int i=0; i<10; i++)
            {
                for (int j=0; j<10; j++)
                {
                    CaseDames cellule = new CaseDames(i, j);
                    CasesEchec[i, j] = cellule;
                    plateauLayout.Controls.Add(cellule, i, 9-j);
                }
            }
           
        }

        public void AfficherPlateau(Plateau plateau)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    CasesEchec[i, j].Piece = plateau.Grille[i, j];
                    CasesEchec[i, j].Refresh();
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

        private void plateauLayout_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
