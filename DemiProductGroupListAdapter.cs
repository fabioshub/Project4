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

namespace po4
{
    public class DemiProductGroupListAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public DemiProductList mGroupList;


        public DemiProductGroupListAdapter(DemiProductList grouplist)
        {
            mGroupList = grouplist;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DemiGroupCardView, parent, false);
            DemiRecycleViewHolderClass vh = new DemiRecycleViewHolderClass(itemView, OnClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DemiRecycleViewHolderClass vh = holder as DemiRecycleViewHolderClass;
            //vh.Category.Text = mGroupList[position].CategoryName;
            vh.Group.Text = mGroupList[position].group.ToString();
        }

        public override int ItemCount
        {
            get { return mGroupList.NumProducts; }
        }

        void OnClick(int position)
        {
            if (ItemClick != null) ItemClick(this, position);
        }


    }

}