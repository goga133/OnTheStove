﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using RecipesAndroid;
using RecipesAndroid.Objects;
using RecipesAndroid.Objects.Boxes.Elements;

namespace XamarinApp
{
    [Activity(Label = "На плите!", Theme = "@style/AppTheme.NoActionBar", Icon = "@drawable/icon", MainLauncher = true)]
    
    public class MainActivity : AppCompatActivity
    {
        private ListView _listView;
        private List<RecipeShort> recipes;
        private RecipeShortAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_search);
            
            UpdateListView();

        }

        private async Task UpdateCollectionRecipes()
        {
            await Task.Run(() =>
            {
                recipes = HttpGet.GetRecipes();
            });
        }
        private async void UpdateListView()
        {
            await UpdateCollectionRecipes();

            _listView = FindViewById<ListView>(Resource.Id.listRecipeShorts);

            if (adapter == null)
                adapter = new RecipeShortAdapter(this, recipes);

            _listView.Adapter = adapter;
        }

       
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

