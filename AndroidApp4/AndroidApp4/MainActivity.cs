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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var photoAlbum = new PhotoAlbum();
            var adapter = new PhotoAlbumAdapter(photoAlbum);
            var recyclerView = this.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetAdapter(adapter);

            //# Use the built-in LinearLayoutManger.
            //recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            //# Use the built-in GridLayoutManager.
            recyclerView.SetLayoutManager(new GridLayoutManager(this, 2, GridLayoutManager.Horizontal, false));
        }
    }
}
