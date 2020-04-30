﻿using Android;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ObjectsLibrary;
using ObjectsLibrary.Components;
using Square.Picasso;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinAppLibrary;

namespace XamarinApp
{
    public class SavedIngredientsAdapter : RecyclerView.Adapter
    {
        private readonly List<Ingredient> _items;
        public override int ItemCount => _items.Count;

        public SavedIngredientsAdapter(List<Ingredient> ingredients)
        {
            _items = ingredients;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            SavedIngredientsViewHolder vh = holder as SavedIngredientsViewHolder;

            vh.Title.Text = "Название: " + _items[position].Name;
            vh.Unit.Text = "Количество: " + _items[position].Unit;
            vh.RecipeName.Text = "Для: " + _items[position].RecipeName;
        }
        public void RemoveItem(int position)
        {
            this.NotifyItemRemoved(position);
            IngredientData.DeleteIngredient(_items[position]);
            _items.RemoveAt(position);
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.ingredients_saved_list, parent, false);
            SavedIngredientsViewHolder vh = new SavedIngredientsViewHolder(itemView, RemoveItem);
            return vh;
        }

    }

    public class SavedIngredientsViewHolder : RecyclerView.ViewHolder
    {
        public Button CartButton { get; private set; }
        public TextView Title { get; private set; }
        public TextView Unit { get; private set; }
        public TextView RecipeName { get; private set; }

        public SavedIngredientsViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            CartButton = itemView.FindViewById<Button>(Resource.Id.cart_button_saved_ingredient);
            Title = itemView.FindViewById<TextView>(Resource.Id.title_saved_ingredient);
            Unit = itemView.FindViewById<TextView>(Resource.Id.unit_saved_ingredient);
            RecipeName = itemView.FindViewById<TextView>(Resource.Id.recipe_saved_ingredient);

            CartButton.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}