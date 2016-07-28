using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MySqlManagement_v2.UI
{
    interface IDraggable
    {
        /// <summary>
        /// Check if item is involved in a drag&drop operation
        /// </summary>
        bool Dragged { get; }
        /// <summary>
        /// Moves the item according to cursor position while it's being dragged
        /// </summary>
        /// <param name="cursorPosition"></param>
        void MoveOnCursor();
        /// <summary>
        /// Begin drag event
        /// </summary>
        event EventHandler<MouseEventArgs> BeginDrag;
        /// <summary>
        /// End drag event
        /// </summary>
        event EventHandler<MouseEventArgs> EndDrag;
    }
}
