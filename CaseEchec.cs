using IAEchecs.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IAEchecs
{
    class CaseEchec : System.Windows.Forms.Control
    {
        private int x, y;

        public Piece Piece { get; set; }

        public CaseEchec(int posX, int posY) : base()
        {
            x = posX;
            y = posY;
            if ((posX + posY) % 2 == 0)
            {
                BackColor = System.Drawing.Color.BurlyWood;
            }
            else
            {
                BackColor = System.Drawing.Color.Teal;
            }
            this.Dock = DockStyle.Fill;
            Padding = new Padding(0);
            Margin = new Padding(0);
            Console.WriteLine(this.Width);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Image sprite = Piece?.GetSprite();
            if (sprite != null)
            {
                e.Graphics.DrawImage(sprite, new Rectangle(0, 0, this.Width, this.Height));
            }    
            
        }
    }
}
