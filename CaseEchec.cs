using IAEchecs.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IAEchecs
{
    class CaseEchec : Control
    {
        private int x, y;

        public Piece Piece { get; set; }

        public event EventHandler<SelectionCaseEventArg> CaseCliqueeEvent;

        private Boolean selectionnee = false;

        public CaseEchec(int posX, int posY) : base()
        {
            x = posX;
            y = posY;
            if ((posX + posY) % 2 == 0)
            {
                BackColor = Color.BurlyWood;
            }
            else
            {
                BackColor = Color.Teal;
            }
            this.Dock = DockStyle.Fill;
            Padding = new Padding(0);
            Margin = new Padding(0);
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

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            SelectionCaseEventArg args = new SelectionCaseEventArg(x, y, !selectionnee, Deselectionner );
       
            CaseCliqueeEvent?.Invoke(this, args);
            if (args.Handled)
            {
                if (selectionnee)
                {
                    Deselectionner();
                }
                else
                {
                    Selectionner();
                }
            }

        }

        public void Selectionner()
        {
            selectionnee = true;
            this.ForeColor = Color.FromArgb(150, Color.Orange);
        }
        public void Deselectionner()
        {
            selectionnee = false;
            this.ForeColor = default(Color);
        }
    }

    class SelectionCaseEventArg : EventArgs
    {
        public int X;
        public int Y;
        public readonly bool Selectionnee;
        public Action Deselectionner; // a appeler quand on veut deselectionner la case qui a ete cliquee
        public bool Handled = false;

        public SelectionCaseEventArg(int x, int y, bool selectionnee, Action deselectionner)
        {
            X = x;
            Y = y;
            Selectionnee = selectionnee;
            Deselectionner = deselectionner;
        }
    }
}
