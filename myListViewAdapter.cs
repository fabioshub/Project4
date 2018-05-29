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
using Java.Lang;

namespace po4
{
    class myListViewAdapter : BaseAdapter<holder>
    {

        private List<holder> mItems;
        private Context mContext;

        public myListViewAdapter(Context context, List<holder> items)
        {
            mItems = items;
            mContext = context;
        }

        public override int Count => mItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override holder this[int position] => mItems[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.RowFabio, null, false);
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.txt1);
            txt1.Text = mItems[position].first;

            TextView txt2 = row.FindViewById<TextView>(Resource.Id.txt2);
            txt2.Text = mItems[position].second;





            return row;
        }
    }
}