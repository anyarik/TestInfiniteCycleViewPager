﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace InfiniteCycleViewPager.Sample
{
    [Activity(Label = "CardsActivity", Theme = "@style/AppTheme")]
    public class YourSecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_second);
            // Create your application here
        }

      
    }
}