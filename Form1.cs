using IADames.Moteur;
using IADames.Pieces;
using IAEchecs.IA;
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

        public static readonly string[] JoueursPossibles = new string[] { "Humain", "IALouis" };

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

            SelectionBlancs.DataSource = JoueursPossibles.Clone();
            SelectionNoirs.DataSource = JoueursPossibles.Clone();

        }

        Joueur JoueurFromString(string nom, bool estBlanc)
        {
            switch(nom)
            {
                case "Humain":
                    return new JoueurHumain(estBlanc, this);

                case "IALouis":
                    return new IALouis(estBlanc, 2);

                default:
                    throw new NotImplementedException("Cette IA n'existe pas : " + nom);
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

        public void AfficherTour(bool tourDesBlancs, string message)
        {
            Console.WriteLine("Tour des " + (tourDesBlancs ? "Blancs" : "Noirs"));
            Informations.Invoke(new Action(() => Informations.Text = message));
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
                Jeu = new Jeu(JoueurFromString((string)SelectionBlancs.SelectedItem, true), JoueurFromString((string)SelectionNoirs.SelectedItem, false), this); 
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

        public void AfficherGagnant(bool estBlanc)
        {
            MessageBox.Show("Les "+(estBlanc?"Blancs":"Noirs")+" ont gagné !", "Dames Internationales", MessageBoxButtons.OK);
        }

    }
}
