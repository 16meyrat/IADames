
namespace IADames.Moteur
{
    interface IAffichageEchec
    {
        void AfficherPlateau(Plateau plateau);
        void AfficherTour(bool tourDesBlancs, string message);
        void AfficherGagnant(bool estBlanc);
    }
}
