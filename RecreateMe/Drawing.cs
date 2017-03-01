using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace RecreateMe
{
    public partial class Drawing : Control
    {
        public Drawing()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
