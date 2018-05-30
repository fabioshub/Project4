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
using Android.Support.V7.Widget;

namespace RecycleViewList
{

    public class Product
    {
        public DemiProductCategory category { get; }

        public DemiProductGroup group { get; }

        public string name { get; }

        public Product(DemiProductCategory category = DemiProductCategory.Other, DemiProductGroup group = DemiProductGroup.Other, string name = "")
        {
            this.category = category;
            this.group = group;
            this.name = name; 
        }
    }

    public class DemiProductList
    {

        private static Product[] mConfirmedProducts =
            {
            new Product( category: DemiProductCategory.Food,
                        group: DemiProductGroup.Fruits,
                        name: "Strawberries"),
            new Product( category: DemiProductCategory.Food,
                        group: DemiProductGroup.Grains,
                        name: "Bread"),
            new Product( category: DemiProductCategory.Food,
                        group: DemiProductGroup.Meat,
                        name: "Chicken"),
            new Product( category: DemiProductCategory.Food,
                        group: DemiProductGroup.Confections ),
            new Product( category: DemiProductCategory.Food,
                        group: DemiProductGroup.Vegtables ),

            new Product( category: DemiProductCategory.Drinks,
                        group: DemiProductGroup.Alcohol ),
            new Product( category: DemiProductCategory.Drinks,
                        group: DemiProductGroup.Dairy ),
            new Product( category: DemiProductCategory.Drinks,
                        group: DemiProductGroup.Caffinated ),
            new Product( category: DemiProductCategory.Drinks,
                        group: DemiProductGroup.Soda ),

            new Product( category: DemiProductCategory.Dishes,
                        group: DemiProductGroup.Pancakes ),
            new Product( category: DemiProductCategory.Dishes,
                        group: DemiProductGroup.Waffles ),
            new Product( category: DemiProductCategory.Dishes,
                        group: DemiProductGroup.Pizza ),
            new Product( category: DemiProductCategory.Dishes,
                        group: DemiProductGroup.Omelet ),

            new Product( category: DemiProductCategory.Nonfood,
                        group: DemiProductGroup.Cosmetics ),
            new Product( category: DemiProductCategory.Nonfood,
                        group: DemiProductGroup.Bathroom ),
            };


        private List<Product> mProducts;


        public DemiProductList()
        {
            mProducts = new List<Product>();
            mProducts.Add(new Product(DemiProductCategory.Food));
            int counter;

            counter = 0;

            for (int i = 0; i < mConfirmedProducts.Length; i++)
            {
                for (int j = 0; j < mProducts.Count; j++)
                {
                    if(mProducts[j].category != mConfirmedProducts[i].category)
                    {
                        counter += 1;
                    }
                    
                    if (counter == mProducts.Count)
                    {
                        mProducts.Add(mConfirmedProducts[i]);
                    }
                }

                counter = 0;
            }
        }


        public DemiProductList(DemiProductCategory CategoryID)
        {
            mProducts = new List<Product>();

            for (int i = 0; i < mConfirmedProducts.Length; i++)
            {
                if (mConfirmedProducts[i].category == CategoryID)
                {
                    mProducts.Add(mConfirmedProducts[i]);
                }
            }
        }

        public DemiProductList(DemiProductCategory CategoryID, DemiProductGroup GroupID)
        {
            mProducts = new List<Product>();

            for (int i = 0; i < mConfirmedProducts.Length; i++)
            {
                if (mConfirmedProducts[i].group == GroupID)
                {
                    mProducts.Add(mConfirmedProducts[i]);
                }
            }
        }

        public int NumProducts
        {
            get { return mProducts.Count; }
        }

        public Product this[int i]
        {
            get { return mProducts[i]; }
        }

    }
}