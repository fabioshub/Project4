using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V7.App;
using System.Linq;

namespace po4
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = false)]
    public class DemiThirdActivity : AppCompatActivity
    {
        RecyclerView                mRecyclerView;
        RecyclerView.LayoutManager  mLayoutManager;
        DemiProductAdapter              mAdapter;
        DemiProductList                 mProductList;
        DemiProductCategory             CategoryID;
        DemiProductGroup                GroupID;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Demiactivity_main);

            mRecyclerView   = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            if (this.Intent.Extras != null)
            {
                var category    = (DemiProductCategory) Intent.Extras.GetInt("CategoryID");
                var group       = (DemiProductGroup)    Intent.Extras.GetInt("GroupID");
                CategoryID      = category;
                GroupID         = group;
            }

            mProductList = new DemiProductList(CategoryID, GroupID);

            //----------------------------------------------------------------------------------------
            // Layout Managing Set-up

            mLayoutManager  = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //----------------------------------------------------------------------------------------
            // Adapter Set-up
            mAdapter = new DemiProductAdapter(mProductList);
            mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);

        }

        void OnItemClick(object sender, int position)
        {
            Toast.MakeText(this, "This is product  " + mProductList[position].name, ToastLength.Short).Show();
        }
    }
}

