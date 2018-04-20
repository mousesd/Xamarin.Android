using System;
using System.Diagnostics.CodeAnalysis;
using Android.App;
using Android.Graphics;
using Android.Widget;
using Android.OS;

namespace AndroidApp5
{
    [Activity(Label = "AndroidApp5", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private FingerPaintCanvasView canvasView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //# Set up the Spinner to select stroke color
            var colorSpinner = this.FindViewById<Spinner>(Resource.Id.colorSpinner);
            colorSpinner.ItemSelected += this.OnColorItemSelected;

            var colorAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.colors_array
                , Android.Resource.Layout.SimpleSpinnerItem);
            colorAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            colorSpinner.Adapter = colorAdapter;

            //# Set up the Spinner to select stroke width
            var widthSpinner = this.FindViewById<Spinner>(Resource.Id.widthSpinner);
            widthSpinner.ItemSelected += this.OnWidthItemSelected;

            var widthAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.widths_array
                , Android.Resource.Layout.SimpleSpinnerItem);
            widthAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            widthSpinner.Adapter = widthAdapter;

            //# Set up the clear button
            var clearButton = this.FindViewById<Button>(Resource.Id.clearButton);
            clearButton.Click += this.OnClearButtonClick;

            canvasView = this.FindViewById<FingerPaintCanvasView>(Resource.Id.canvasView);
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private void OnColorItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (!(sender is Spinner spinner))
                return;

            string colorString = (string)spinner.GetItemAtPosition(e.Position);
            var color = (Color)(typeof(Color).GetProperty(colorString).GetValue(null));
            canvasView.Color = color;
        }

        private void OnWidthItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (!(sender is Spinner spinner))
                return;

            float width = new float[] { 2, 5, 10, 20, 50 }[e.Position];
            canvasView.StrokeWidth = width;
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            canvasView.Clear();
        }
    }
}
