using IADames.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace IADames
{
    class SpriteProvider
    {
        public Image PionN { get; private set; }
        public Image PionB { get; private set; }

        public Image DameN { get; private set; }
        public Image DameB { get; private set; }

        private SpriteProvider()
        {
            Bitmap modele = new Bitmap(Resources.DamesPiecesArray);
            DameN = modele.Clone(new Rectangle(50, 50, 50, 50), modele.PixelFormat);
            DameB = modele.Clone(new Rectangle(50, 0, 50, 50), modele.PixelFormat);

            PionN = modele.Clone(new Rectangle(0, 50, 50, 50), modele.PixelFormat);
            PionB = modele.Clone(new Rectangle(0, 0, 50, 50), modele.PixelFormat);

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
