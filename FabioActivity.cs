using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;
using PCLStorage;
using System.Threading.Tasks;
using Android.Content;

namespace po4
{
    public class holder
    {
        public string first;
        public string second;
    }

    [Activity(Label = "boodschapp", MainLauncher = false, Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class FabioActivity : Activity
    {
        Button button, buttonDemi;
        public List<holder> mItems = new List<holder>();
        ListView mListView;
        EditText editText1;
        EditText editText2;
        myListViewAdapter adapter;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainFabio);

            button = FindViewById<Button>(Resource.Id.button1);
            buttonDemi = FindViewById<Button>(Resource.Id.demi);
            mListView = FindViewById<ListView>(Resource.Id.mylistView);


            mItems.Add(new holder() { first = "Appel", second = "2 stuks"});

            adapter = new myListViewAdapter(this, mItems);
            mListView.Adapter = adapter;
     
            button.Click += Button_Click;
            mListView.ItemClick += MListView_ItemClick;
            buttonDemi.Click += ButtonDemi_Click;

        }

        //public async Task PCLStorageSample()
        //{
        //    IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder", CreationCollisionOption.OpenIfExists);
        //    IFile file = await folder.CreateFileAsync("answer.txt", CreationCollisionOption.ReplaceExisting);
        //    await file.WriteAllTextAsync("42");
        //} 


        //public static async Task<string> ReadFileContent(string fileName, IFolder rootFolder)
        //{
        //    ExistenceCheckResult exist = await rootFolder.CheckExistsAsync(fileName);

        //    string text = null;
        //    if (exist == ExistenceCheckResult.FileExists)
        //    {
        //        IFile file = await rootFolder.GetFileAsync(fileName);
        //        text = await file.ReadAllTextAsync();
        //    }

        //    return text;
        //}

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
                Toast.MakeText(this, "Spoor jij Niet? nigga u gay lil fag ass midget strapon anal bish", ToastLength.Long).Show();
            }
        }

        void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            mItems.Remove(mItems[e.Position]);
            adapter.NotifyDataSetChanged();

        }

        void ButtonDemi_Click(object sender, EventArgs e)
        {
            var demiIntent = new Intent(this, typeof(DemiMainActivity));
            StartActivity(demiIntent);
        }

        public void functio()
        {
            mItems.Add(new holder() { first = "Appel", second = "2 stuks" });
            adapter.NotifyDataSetChanged();
            var intent = new Intent(this, typeof(FabioActivity));
            StartActivity(intent);
        }

    }

}

