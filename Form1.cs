using IADames.Moteur;
using IADames.Pieces;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IADames
{
    public partial class MainWindowForm : Form, IAffichageEchec
    {

        internal CaseDames[,] CasesDames { get; private set; }
        private Jeu Jeu;
        CancellationTokenSource annulation;

        public MainWindowForm()
        {
            InitializeComponent();
            
        }

        private void MainWindowForm_Load(object sender, EventArgs e)
        {
            CasesDames = new CaseDames[10, 10];

            for (int i=0; i<10; i++)
            {
                for (int j=0; j<10; j++)
                {
                    CaseDames cellule = new CaseDames(i, j);
                    CasesDames[i, j] = cellule;
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
                    CasesDames[i, j].Piece = plateau.Grille[i, j];
                    CasesDames[i, j].RefreshAsync();
                }
            }
        }

        public void AfficherTour(bool tourDesBlancs)
        {
            Console.WriteLine("Tour des " + (tourDesBlancs ? "Blancs" : "Noirs"));
        }

        private async void boutonDemarrer_Click(object sender, EventArgs e)
        {
            if(annulation != null)
            {
                try
                {
                    annulation.Cancel(true);
                    
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("La partie a été annulée");             
                }
                foreach (var cellule in CasesDames)
                {
                  
                    cellule.Reinitialiser();
                }

            }
            
            try {
                annulation = new CancellationTokenSource();
                Jeu = new Jeu(new JoueurHumain(true, this), new JoueurHumain(false, this), this); 
                await Jeu.Jouer(annulation.Token);

            }
            catch (OperationCanceledException)
            { 
                Console.WriteLine("Annulation ");
            }
            finally
            {
                annulation?.Dispose();
                annulation = null;
            }
            
        }

    }
}
