using System;
using System.Diagnostics.CodeAnalysis;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace AndroidApp4
{
    [Activity(Label = "AndroidApp4", MainLauncher = true)]
    [SuppressMessage("ReSharper", "AccessToStaticMemberViaDerivedType")]
    public class MainActivity : AppCompatActivity
    {
        private readonly PhotoAlbum photoAlbum = new PhotoAlbum();
        private PhotoAlbumAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            adapter = new PhotoAlbumAdapter(photoAlbum);
            adapter.ItemClick += this.OnItemClick;

            var recyclerView = this.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetAdapter(adapter);

            //# Use the built-in LinearLayoutManger.
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            //# Use the built-in GridLayoutManager.
            //recyclerView.SetLayoutManager(new GridLayoutManager(this, 2, GridLayoutManager.Horizontal, false));

            var randomPickButton = this.FindViewById<Button>(Resource.Id.randomPickButton);
            randomPickButton.Click += this.OnClickRandomPickButton;
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            Toast.MakeText(this, $"ResourceId={e.Photo.PhotoResourceId}, Caption={e.Photo.Caption}"
                , ToastLength.Short).Show();
        }

        private void OnClickRandomPickButton(object sender, EventArgs e)
        {
            if (photoAlbum == null)
                return;

            int index = photoAlbum.RandomSwap();
            adapter.NotifyItemChanged(0);
            adapter.NotifyItemChanged(index);
        }
    }
}
