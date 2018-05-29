using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace po4
{
    [Activity(Label = "boodschapp", MainLauncher = true, Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class FabioActivity : Activity
    {
        Button button;
        List<holder> mItems;
        ListView mListView;
        EditText editText1;
        EditText editText2;
        myListViewAdapter adapter; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainFabio);

            // Get our button from the layout resource,
            button = FindViewById<Button>(Resource.Id.button1);
            mListView = FindViewById<ListView>(Resource.Id.mylistView);
            mItems = new List<holder>();
            mItems.Add(new holder() { first = "Appel", second = "2 stuks"});
            adapter = new myListViewAdapter(this, mItems);
            mListView.Adapter = adapter;
     
            button.Click += Button_Click;
            mListView.ItemClick += MListView_ItemClick;
        }

        void Button_Click(object sender, System.EventArgs e)
        {
            editText1 = FindViewById<EditText>(Resource.Id.editText1);
            editText2 = FindViewById<EditText>(Resource.Id.editText2);
            var currentvar1 = editText1.Text;
            var currentvar2 = editText2.Text;
            if (currentvar1 != "")
            {
                mItems.Add(new holder() { first = currentvar1, second = currentvar2 });
                adapter.NotifyDataSetChanged();
                editText1.Text = "";
                editText2.Text = "";
            }
            if (currentvar1 == "")
            {
                System.Console.WriteLine("empty string");
            }
        }

        void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            mItems.Remove(mItems[e.Position]);
            adapter.NotifyDataSetChanged();

        }

    }

}

