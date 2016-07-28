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
    public partial class PictureItemContainer : UserControl
    {
        private int columns;
        private int rows;
        public int Columns 
        {
            get
            {
                return Math.Max(1, columns);
            }

            set
            {
                columns = value;
            }
        }
        public int Rows
        {
            get
            {
                return Math.Max(1, rows);
            }

            set
            {
                rows = value;
            }
        }

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

        public PictureItemContainer()
        {
            InitializeComponent();
        }
        
        private void pnlMain_DragDrop(object sender, DragEventArgs e)
        {
            Type t;
            if (IsPictureItem(e, out t))
            {
                var ctrl = (PictureItem)e.Data.GetData(t);
                pnlMain.Controls.Add(ctrl);
            }
        }

        private void pnlMain_DragEnter(object sender, DragEventArgs e)
        {
            if(IsPictureItem(e))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
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
    }
}
