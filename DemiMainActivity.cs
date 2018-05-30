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

namespace RecycleViewList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class DemiMainActivity : AppCompatActivity
    {
        RecyclerView                mRecyclerView;
        RecyclerView.LayoutManager  mLayoutManager;
        DemiProductListAdapter          mAdapter;
        DemiProductList                 mProductList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            mProductList    = new DemiProductList();

            SetContentView(Resource.Layout.Demiactivity_main);

            mRecyclerView   = FindViewById<RecyclerView>(Resource.Id.recyclerView1);



            //----------------------------------------------------------------------------------------
            // Layout Managing Set-up

            mLayoutManager  = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //----------------------------------------------------------------------------------------
            // Adapter Set-up
            mAdapter = new DemiProductListAdapter(mProductList);
            mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);

        }

        void OnItemClick(object sender, int position)
        {
            var intent = new Intent(this, typeof(DemiSecondActivity));

            Bundle b = new Bundle();
            b.PutInt("CategoryID", (int) mProductList[position].category);
            intent.PutExtras(b);

            Toast.MakeText(this, "This is in category " + mProductList[position].category, ToastLength.Short).Show();

            StartActivity(intent);
        }
    }
}

