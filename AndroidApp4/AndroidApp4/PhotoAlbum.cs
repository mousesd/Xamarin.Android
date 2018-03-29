using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp4
{
    public class PhotoAlbum
    {
        private readonly Photo[] photos;
        private readonly Random random;

        public Photo this[int index]
        {
            get { return this.photos[index]; }
        }

        public int PhotoCount
        {
            get { return photos?.Length ?? 0; }
        }

        public PhotoAlbum()
        {
            #region == Create the album ==
            this.photos = new[] {
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.buckingham_guards,
                    Caption = "Buckingham Palace"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.la_tour_eiffel,
                    Caption = "The Eiffel Tower"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.louvre_1,
                    Caption = "The Louvre"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.before_mobile_phones,
                    Caption = "Before mobile phones"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.big_ben_1,
                    Caption = "Big Ben skyline"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.big_ben_2,
                    Caption = "Big Ben from below"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.london_eye,
                    Caption = "The London Eye"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.eurostar,
                    Caption = "Eurostar Train"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.arc_de_triomphe,
                    Caption = "Arc de Triomphe"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.louvre_2,
                    Caption = "Inside the Louvre"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.versailles_fountains,
                    Caption = "Versailles fountains"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.modest_accomodations,
                    Caption = "Modest accomodations"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.notre_dame,
                    Caption = "Notre Dame"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.inside_notre_dame,
                    Caption = "Inside Notre Dame"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.seine_river,
                    Caption = "The Seine"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.rue_cler,
                    Caption = "Rue Cler"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.champ_elysees,
                    Caption = "The Avenue des Champs-Elysees"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.seine_barge,
                    Caption = "Seine barge"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.versailles_gates,
                    Caption = "Gates of Versailles"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.edinburgh_castle_2,
                    Caption = "Edinburgh Castle"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.edinburgh_castle_1,
                    Caption = "Edinburgh Castle up close"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.old_meets_new,
                    Caption = "Old meets new"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.edinburgh_from_on_high,
                    Caption = "Edinburgh from on high"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.edinburgh_station,
                    Caption = "Edinburgh station"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.scott_monument,
                    Caption = "Scott Monument"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.view_from_holyrood_park,
                    Caption = "View from Holyrood Park"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.tower_of_london,
                    Caption = "Outside the Tower of London"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.tower_visitors,
                    Caption = "Tower of London visitors"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.one_o_clock_gun,
                    Caption = "One O'Clock Gun"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.victoria_albert,
                    Caption = "Victoria and Albert Museum"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.royal_mile,
                    Caption = "The Royal Mile"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.museum_and_castle,
                    Caption = "Edinburgh Museum and Castle"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.portcullis_gate,
                    Caption = "Portcullis Gate"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.to_notre_dame,
                    Caption = "Left or right?"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.pompidou_centre,
                    Caption = "Pompidou Centre"
                },
                new Photo
                {
                    PhotoResourceId = Resource.Drawable.heres_lookin_at_ya,
                    Caption = "Here's Lookin' at Ya!"
                },
            }; 
            #endregion

            this.random = new Random();
        }

        /// <summary>
        /// Pick a random photo and swap it with the top
        /// </summary>
        public int RandomSwap()
        {
            var temp = photos[0];
            int index = random.Next(1, photos.Length);

            photos[0] = photos[index];
            photos[index] = temp;

            return index;
        }
    }
}
