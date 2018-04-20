using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp5
{
    public class FingerPaintPolyLine
    {
        public Color Color { get; set; }
        public float StrokeWidth { get; set; }
        public Path Path { get; }

        public FingerPaintPolyLine()
        {
            this.Path = new Path();
        }
    }
}
