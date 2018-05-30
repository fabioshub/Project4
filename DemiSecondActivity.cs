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

namespace RecycleViewList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class DemiSecondActivity : AppCompatActivity
    {
        RecyclerView                mRecyclerView;
        RecyclerView.LayoutManager  mLayoutManager;
        DemiProductGroupListAdapter     mAdapter;
        DemiProductList                 mProductList; // => List<Product>
        DemiProductCategory             CategoryID;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Demiactivity_main);

            mRecyclerView   = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            if (this.Intent.Extras != null)
            {
                var category = (DemiProductCategory) Intent.Extras.GetInt("CategoryID");
                CategoryID = category;
            }

            mProductList = new DemiProductList(CategoryID);

            //
            //var allProducts = DefaultProductList.Get().Where((product) => product.category == CategoryID);

            //----------------------------------------------------------------------------------------
            // Layout Managing Set-up

            mLayoutManager  = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //----------------------------------------------------------------------------------------
            // Adapter Set-up
            mAdapter = new DemiProductGroupListAdapter(mProductList);
            mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);

        }

        void OnItemClick(object sender, int position)
        {
            var intent = new Intent(this, typeof(DemiThirdActivity));

            Bundle b = new Bundle();
            b.PutInt("CategoryID", (int)mProductList[position].category);
            b.PutInt("GroupID", (int)mProductList[position].group);
            intent.PutExtras(b);

            Toast.MakeText(this, "This is in group " + mProductList[position].group, ToastLength.Short).Show();

            StartActivity(intent);
        }
    }
}

