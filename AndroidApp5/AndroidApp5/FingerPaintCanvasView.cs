using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;

namespace AndroidApp5
{
    public class FingerPaintCanvasView : View
    {
        #region == Fields & Properties ==
        private readonly Dictionary<int, FingerPaintPolyLine> fingerIdPolylineDic
            = new Dictionary<int, FingerPaintPolyLine>();
        private readonly List<FingerPaintPolyLine> completedPolylines = new List<FingerPaintPolyLine>();
        private readonly Paint paint = new Paint();

        public Color Color { get; set; } = Color.Red;
        public float StrokeWidth { get; set; } = 2.0F; 
        #endregion

        #region == Constructors ==
        public FingerPaintCanvasView(Context context) : base(context) { }

        public FingerPaintCanvasView(Context context, IAttributeSet attrs) : base(context, attrs) { }
        #endregion

        #region == Override members of the View class ==
        public override bool OnTouchEvent(MotionEvent e)
        {
            //# Get the pointer index
            int pointerIndex = e.ActionIndex;

            //# Get the Id to idnetity a finger over the course of it's progress
            int id = e.GetPointerId(pointerIndex);

            switch (e.ActionMasked)
            {
                case MotionEventActions.Down:
                case MotionEventActions.PointerDown:
                    var polyline = new FingerPaintPolyLine
                    {
                        Color = this.Color,
                        StrokeWidth = this.StrokeWidth
                    };
                    polyline.Path.MoveTo(e.GetX(pointerIndex), e.GetY(pointerIndex));
                    fingerIdPolylineDic.Add(id, polyline);
                    break;

                case MotionEventActions.Move:
                    for (int index = 0; index < e.PointerCount; index++)
                    {
                        int moveFingerId = e.GetPointerId(index);
                        fingerIdPolylineDic[moveFingerId].Path.LineTo(e.GetX(index), e.GetY(index));
                    }
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.Pointer1Up:
                    fingerIdPolylineDic[id].Path.LineTo(e.GetX(pointerIndex), e.GetY(pointerIndex));
                    completedPolylines.Add(fingerIdPolylineDic[id]);
                    fingerIdPolylineDic.Remove(id);
                    break;

                case MotionEventActions.Cancel:
                    fingerIdPolylineDic.Remove(id);
                    break;
            }

            this.Invalidate();
            return true;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            //# Clear canvas to white
            paint.SetStyle(Paint.Style.Fill);
            paint.Color = Color.White;
            canvas.DrawPaint(paint);

            //# Draw strokes
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeCap = Paint.Cap.Round;
            paint.StrokeJoin = Paint.Join.Round;

            //# Draw the completed polylines
            foreach (var polyline in completedPolylines)
            {
                paint.Color = polyline.Color;
                paint.StrokeWidth = polyline.StrokeWidth;
                canvas.DrawPath(polyline.Path, paint);
            }

            //# Draw the in-progress polylines
            foreach (var polyline in fingerIdPolylineDic.Values)
            {
                paint.Color = polyline.Color;
                paint.StrokeWidth = polyline.StrokeWidth;
                canvas.DrawPath(polyline.Path, paint);
            }
        } 
        #endregion

        public void Clear()
        {
            fingerIdPolylineDic.Clear();
            completedPolylines.Clear();
            this.Invalidate();
        }
    }
}
