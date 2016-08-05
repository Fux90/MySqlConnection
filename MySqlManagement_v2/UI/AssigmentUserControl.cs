using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MySqlManagement_v2.UI
{
    public partial class AssigmentUserControl : UserControl
    {
        private const float MinSpacing = 10.0f;

        [Browsable(true)]
        public string Text
        {
            get
            {
                return grpMain.Text;
            }

            set
            {
                grpMain.Text = value;
            }
        }


        private float spacing;

        [Browsable(true)]
        public float Spacing
        {
            get
            {
                return Math.Max(spacing, MinSpacing);
            }

            set
            {
                spacing = value;
            }
        }

        public PictureItem AssignedTo{ get; set; }

        public AssigmentUserControl()
        {
            InitializeComponent();
        }

        private void pnlAssigned_DragEnter(object sender, DragEventArgs e)
        {
            if (IsPictureItem(e))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pnlAssigned_DragDrop(object sender, DragEventArgs e)
        {
            Type t;
            if (IsPictureItem(e, out t))
            {
                var ctrl = (PictureItem)e.Data.GetData(t);
                Add(ctrl);
            }
        }

        public void Add(PictureItem ctrl)
        {
            if (!pnlAssigned.Controls.Contains(ctrl))
            {
                pnlAssigned.Controls.Add(ctrl);
                UpdateChildrens(this);
            }
        }

        private static void UpdateChildrens(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Invalidate();
                if (ctrl.HasChildren)
                {
                    UpdateChildrens(ctrl);
                }
            }
        }

        private bool IsPictureItem(DragEventArgs e, out Type type)
        {
            Type parent = typeof(PictureItem);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes(); // Maybe select some other assembly here, depending on what you need
            var inheritingTypes = types.Where(t => parent.IsAssignableFrom(t));

            foreach (var item in inheritingTypes)
            {
                if (e.Data.GetDataPresent(item))
                {
                    type = item;
                    return true;
                }
            }

            type = null;
            return false;
        }

        private bool IsPictureItem(DragEventArgs e)
        {
            Type dummy;
            return IsPictureItem(e, out dummy);
        }

        private void pnlAssigned_Paint(object sender, PaintEventArgs e)
        {
            var dim = pnlAssigned.ClientRectangle.Height - Padding.All;
            var size = new Size(dim, dim);
            var location = new PointF(Padding.All, Padding.All);

            var g = e.Graphics;
            var picItemType = typeof(SameImagePictureItem);

            foreach (var ctrl in pnlAssigned.Controls)
            {
                if(picItemType.IsAssignableFrom(ctrl.GetType()))
                {
                    g.DrawImage(((SameImagePictureItem)ctrl).ClassImage, new RectangleF(location, size));
                    location.X += Spacing;
                }
            }
        }
    }
}
