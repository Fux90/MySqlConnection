using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        public PictureItemContainer()
        {
            InitializeComponent();
        }
    }
}
