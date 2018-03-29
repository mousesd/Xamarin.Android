using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace AndroidApp4
{
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }

        public PhotoViewHolder(View itemView) : base(itemView)
        {
            this.Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            this.Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
        }
    }
}