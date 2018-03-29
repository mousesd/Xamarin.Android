using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace AndroidApp4
{
    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        public event EventHandler<ItemClickEventArgs> ItemClick;

        #region == Fields & Constructors ==
        private readonly PhotoAlbum photoAlbum;
        public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
        {
            this.photoAlbum = photoAlbum;
        }
        #endregion

        #region == Override members of the RecyclerView.Adapter class ==
        public override int ItemCount
        {
            get { return photoAlbum.PhotoCount; }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCardView, parent, false);
            return new PhotoViewHolder(view, this.OnItemClick);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is PhotoViewHolder viewHolder))
                return;

            viewHolder.Image.SetImageResource(photoAlbum[position].PhotoResourceId);
            viewHolder.Caption.Text = photoAlbum[position].Caption;
        } 
        #endregion

        protected virtual void OnItemClick(int position)
        {
            this.ItemClick?.Invoke(this, new ItemClickEventArgs(photoAlbum[position]));
        }
    }

    public class ItemClickEventArgs
    {
        public Photo Photo { get; }
        public ItemClickEventArgs(Photo photo)
        {
            this.Photo = photo;
        }
    }
}
