using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;

namespace MySqlManagement_v2.UI
{
    public partial class PictureItem : PictureBox, IDraggable
    {
        private const string unkownID = "???";
        public static readonly Point defaultCenterPosition = new Point(50, 50);
        private readonly Font defaultFont = new Font(FontFamily.GenericMonospace, 8.0f, FontStyle.Bold);
        private readonly Color defaultColor = Color.Yellow;
        private const float ptRectSize = 5.0f;
        private const float ptRectSize2 = ptRectSize / 2.0f;

        private bool ptRectToRecompute { get; set; }

        private static Assembly currentAssembly;
        protected static Assembly CurrentAssembly
        {
            get
            {
                if(currentAssembly == null)
                {
                    currentAssembly = Assembly.GetExecutingAssembly();
                }

                return currentAssembly;
            }
        }

        private RectangleF ptRect;
        private RectangleF PtRect
        {
            get
            {
                if (ptRect == null || ptRectToRecompute)
                {
                    ptRect = new RectangleF(XPos - ptRectSize2, YPos - ptRectSize2, ptRectSize, ptRectSize);
                    ptRectToRecompute = false;
                }

                return ptRect;
            }
        }

        private string debugString;
        public string DebugString
        {
            get
            {
                if (debugString == null)
                {
                    debugString = string.Empty;
                }

                return debugString;
            }

            private set
            {
                debugString = value;
            }
        }

        private Point centerPosition;
        [Browsable(true)]
        [TypeConverter(typeof(PointConverter))]
        public Point CenterPosition 
        {
            get
            {
                if (centerPosition == null)
                {
                    centerPosition = defaultCenterPosition;
                }
                
                return centerPosition;
            }

            set
            {
                centerPosition = value;
                ptRectToRecompute = true;
            }
        }

        private float XPos
        {
            get
            {
                return (float)CenterPosition.X / 100.0f * this.Width;
            }
        }

        private float YPos
        {
            get
            {
                return (float)CenterPosition.Y / 100.0f * this.Height;
            }
        }

        private string id;
        [Browsable(true)]
        public string ID 
        {
            get
            {
                if (id == null)
                {
                    return unkownID;
                }

                return id;
            }

            set
            {
                id = value;
            }
        }

        private Font font;
        [Browsable(true)]
        public Font Font 
        {
            get
            {
                if (font == null)
                {
                    font = defaultFont;
                }

                return font;
            }

            set
            {
                font = value;
            }
        }

        private Color? foreColor = null;
        [Browsable(true)]
        public Color ForeColor
        {
            get
            {
                if (foreColor == null)
                {
                    foreColor = defaultColor;
                }

                return (Color)foreColor;
            }

            set
            {
                foreColor = value;
                foreColorBrush = new SolidBrush((Color)foreColor);
            }
        }

        private Brush foreColorBrush = null;
        [Browsable(false)]
        private Brush ForeColorBrush
        {
            get
            {
                if (foreColorBrush == null)
                {
                    foreColorBrush = new SolidBrush(ForeColor);
                }
                return (Brush)foreColorBrush;
            }
        }

        public bool Dragged { get; private set; }
        private Point? positionOnDragBegin;
        private Point? positionOffset;

        #region CONSTRUCTORS

        public PictureItem()
            : this(null, null, null)
        {
        }

        public PictureItem(Image image, Point? centerPosition)
            : this(image, null, centerPosition)
        {
        }

        public PictureItem(Image image, string id)
            : this(image, id, null)
        {
        }

        public PictureItem(Image image, string id, Point? centerPosition)
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SizeMode = PictureBoxSizeMode.Zoom;

            this.Image = image;
            this.ID = id;
            if (centerPosition != null)
            {
                this.CenterPosition = (Point)centerPosition;
            }

            ptRectToRecompute = true;
        }

        #endregion

        private PointF getCenterPosition()
        {
            return new PointF(XPos, YPos);
        }

        private static SizeF StringGraphicalLength(Graphics g, string str, Font f)
        {
            return g.MeasureString(str, f);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ptRectToRecompute = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.DoDragDrop(this, DragDropEffects.Copy | DragDropEffects.Move);
            OnBeginDrag(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            OnEndDrag(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //MoveOnCursor();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var g = pe.Graphics;

            if (DesignMode)
            {
                g.FillEllipse(Brushes.Red, PtRect);
                DebugString = PtRect.ToString();
            }

            var strLen = StringGraphicalLength(g, ID, Font);
            var xOffset = (float)strLen.Width / 2.0f;
            var yOffset = (float)strLen.Height / 2.0f;

            var stringOrigin = new PointF()
            {
                X = XPos - xOffset,
                Y = YPos - yOffset
            };

            g.DrawString(ID, Font, ForeColorBrush, stringOrigin);
        }

        public void MoveOnCursor()
        {
            if (Dragged)
            {
                var newPos = this.PointToClient(Cursor.Position);
                newPos.Offset((Point)positionOffset);
                this.Location = newPos;
            }
        }

        public event EventHandler<MouseEventArgs> BeginDrag;
        public event EventHandler<MouseEventArgs> EndDrag;

        protected void OnBeginDrag(MouseEventArgs e)
        {
            var beginDrag = BeginDrag;
            Dragged = true;
            positionOnDragBegin = this.Location;
            var relativeCursorPos = this.PointToClient(Cursor.Position);
            positionOffset = new Point()
            {
                X = this.Location.X - relativeCursorPos.X,
                Y = this.Location.Y - relativeCursorPos.Y,
            };
            if (beginDrag != null)
            {
                beginDrag(this, e);
            }
        }

        protected void OnEndDrag(MouseEventArgs e)
        {
            var endDrag = EndDrag;
            Dragged = false;
            var oldParent = this.Parent;
            if (endDrag != null)
            {
                endDrag(this, e);
            }
            if (oldParent == this.Parent)
            {
                this.Location = (Point)positionOnDragBegin;
            }

            positionOnDragBegin = null;
            positionOffset = null;
        }
    }

    public partial class SameImagePictureItem : PictureItem
    {
        public static Image classImage;
        public Image ClassImage
        {
            get
            {
                return SameImagePictureItem.classImage;
            }
        }

        public SameImagePictureItem(string baseImagePath)
            : this(Image.FromFile(baseImagePath))
        {

        }

        public SameImagePictureItem(Image baseImage)
        {
            if (classImage == null)
            {
                if (baseImage != null)
                {
                    classImage = baseImage;
                }
                else
                {
                    classImage = null;
                }
            }

            this.Image = ClassImage;
            this.Font = new Font(FontFamily.GenericMonospace, 15.0f, FontStyle.Bold);
            this.ForeColor = Color.Red;
        }

        protected virtual void ShowInfo()
        {
            MessageBox.Show(String.Format("Pic ID: {0}", ID));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            ShowInfo();
        }
    }

    public static class SameImagePictureItemNames
    {
        public const string MonitorImg = "MySqlManagement_v2.Resources.Images.monitor.png";
        public const string CaseImg = "MySqlManagement_v2.Resources.Images.pc.png";
        public const string UserImg = "MySqlManagement_v2.Resources.Images.user.png";
    }

    public partial class LcdMonitorPictureItem : SameImagePictureItem
    {
        private static readonly Size FavouriteSize = new Size(103, 93);

        public LcdMonitorPictureItem()
            : base(Image.FromStream(SameImagePictureItem.CurrentAssembly.GetManifestResourceStream(SameImagePictureItemNames.MonitorImg)))
        {
            this.CenterPosition = new Point(50, 50);
        }
    }

    public partial class CasePictureItem : SameImagePictureItem
    {
        private static readonly Size FavouriteSize = new Size(80, 178);

        public CasePictureItem()
            : base(Image.FromStream(SameImagePictureItem.CurrentAssembly.GetManifestResourceStream(SameImagePictureItemNames.CaseImg)))
        {
            this.CenterPosition = new Point(50, 55);
        }
    }

    public partial class UserPictureItem : SameImagePictureItem
    {
        private static readonly Size FavouriteSize = new Size(103, 93);

        public UserPictureItem()
            : base(Image.FromStream(SameImagePictureItem.CurrentAssembly.GetManifestResourceStream(SameImagePictureItemNames.UserImg)))
        {
            this.CenterPosition = new Point(50, 85);
        }
    }

}
