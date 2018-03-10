using System;
using System.Collections.Generic;
using System.Drawing;


namespace IAEchecs
{
    class SpriteProvider
    {
        public Image PionN { get; private set; }
        public Image PionB { get; private set; }
        public Image FouN { get; private set; }
        public Image FouB { get; private set; }
        public Image CavalierN { get; private set; }
        public Image CavalierB { get; private set; }
        public Image TourN { get; private set; }
        public Image TourB { get; private set; }
        public Image DameN { get; private set; }
        public Image DameB { get; private set; }
        public Image RoiN { get; private set; }
        public Image RoiB { get; private set; }

        private SpriteProvider()
        {
            Bitmap modele = new Bitmap(IAEchecs.Properties.Resources.ChessPiecesArray);
            DameN = modele.Clone(new Rectangle(0, 0, 30, 30), modele.PixelFormat);
            DameB = modele.Clone(new Rectangle(0, 30, 30, 30), modele.PixelFormat);

            RoiN = modele.Clone(new Rectangle(30, 0, 30, 30), modele.PixelFormat);
            RoiB = modele.Clone(new Rectangle(30, 30, 30, 30), modele.PixelFormat);

            TourN = modele.Clone(new Rectangle(60, 0, 30, 30), modele.PixelFormat);
            TourB = modele.Clone(new Rectangle(60, 30, 30, 30), modele.PixelFormat);

            CavalierN = modele.Clone(new Rectangle(90, 0, 30, 30), modele.PixelFormat);
            CavalierB = modele.Clone(new Rectangle(90, 30, 30, 30), modele.PixelFormat);

            FouN = modele.Clone(new Rectangle(121, 0, 30, 30), modele.PixelFormat);
            FouB = modele.Clone(new Rectangle(120, 30, 30, 30), modele.PixelFormat);

            PionN = modele.Clone(new Rectangle(150, 0, 30, 30), modele.PixelFormat);
            PionB = modele.Clone(new Rectangle(150, 30, 30, 30), modele.PixelFormat);

        }
        private static SpriteProvider instance;

        public static SpriteProvider Instance
        {
            get
            {
                if (instance == null) instance = new SpriteProvider();
                return instance;
            }
        }

}
}
