using IADames.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IADames
{
    class CaseDames : Control
    {
        private int x, y;

        public Piece Piece { get; set; }

        public event EventHandler<SelectionCaseEventArg> CaseCliqueeEvent;

        private Boolean selectionnee = false;

        public CaseDames(int posX, int posY) : base()
        {
            x = posX;
            y = posY;
            if ((posX + posY) % 2 == 0)
            {
                BackColor = Color.BurlyWood;
            }
            else
            {
                BackColor = Color.Sienna;
            }
            this.Dock = DockStyle.Fill;
            Padding = new Padding(0);
            Margin = new Padding(0);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Image sprite = Piece?.GetSprite();
            if (sprite != null)
            {
                e.Graphics.DrawImage(sprite, new Rectangle(0, 0, this.Width, this.Height));
            }
            if (selectionnee)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(125, Color.White)), ClientRectangle);
            }
            
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            SelectionCaseEventArg args = new SelectionCaseEventArg(x, y, selectionnee, Deselectionner );
       
            CaseCliqueeEvent?.Invoke(this, args);
            if (args.Handled)
            {
                if (!args.Selectionnee)
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
            RefreshAsync();
        }
        public void Deselectionner()
        {
            Console.WriteLine("Deselection " + x + ";" + y);
            selectionnee = false;
            RefreshAsync();

        }
        public void RefreshAsync()
        {
            this.Invoke(new Action(() => Refresh()));
        }

        public void Reinitialiser()
        {
            foreach (Delegate d in CaseCliqueeEvent.GetInvocationList())
            {
                CaseCliqueeEvent -= (EventHandler<SelectionCaseEventArg>)d;
            }
            
            Piece = null;
        }
    }

    class SelectionCaseEventArg : EventArgs
    {
        public int X;
        public int Y;
        public bool Selectionnee;
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
