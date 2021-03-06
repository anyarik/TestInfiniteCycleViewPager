﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.View;
using InfiniteCycleViewPager.Sample.Adapters;
using Com.Gigamole.Navigationtabstrip;
using Android.Views;
using Android.Content;
using Android.Support.V4.App;
using static Android.Resource;
using Com.Gigamole.Infinitecycleviewpager;
using static Android.Locations.GpsStatus;
using Com.Bumptech.Glide;

namespace InfiniteCycleViewPager.Sample
{
    [Activity(Label = "InfiniteCycleViewPager.Sample", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        public RelativeLayout backgroundView;
        private float pointPosition;
        private ImageView movePoint;
        private RelativeLayout pointLay;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var horizontalInfiniteCycleViewPager = FindViewById<HorizontalInfiniteCycleViewPager>(Resource.Id.hicvp);
            horizontalInfiniteCycleViewPager.Adapter = new HorizontalPagerAdapter(this, false, this);

            horizontalInfiniteCycleViewPager.PageSelected += HorizontalInfiniteCycleViewPager_PageSelected;
            horizontalInfiniteCycleViewPager.PageScrolled += HorizontalInfiniteCycleViewPager_PageScrolled;

            this.backgroundView = FindViewById<RelativeLayout>(Resource.Id.main_view_layout);
            backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_one);

            this.pointLay = FindViewById<RelativeLayout>(Resource.Id.relLayPoints);
            this.movePoint = FindViewById<ImageView>(Resource.Id.movePoint);
            this.pointPosition = this.movePoint.GetX();
        }

        private void HorizontalInfiniteCycleViewPager_PageScrolled(object sender, Android.Support.V4.View.ViewPager.PageScrolledEventArgs e)
        {
        }

        private void HorizontalInfiniteCycleViewPager_PageSelected(object sender, Android.Support.V4.View.ViewPager.PageSelectedEventArgs e)
        {
            var Position = (sender as HorizontalInfiniteCycleViewPager).RealItem;
            switch (Position)
            {
                case 0:
                    //Glide.With(this)
                    //        .Load(position == -1 ? libraryObject.getImage() : libraryObject.getImages()[position])
                    //     .CenterCrop()
                    //     .DiskCacheStrategy(DiskCacheStrategy.None)
                    //     //.Listener(new RequestListener())
                    //     .Into(imageView);
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_one);
                    this.pointPosition = FindViewById(Resource.Id.firstPoint).GetX();
                    break;
                case 1:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_two);
                    this.pointPosition = FindViewById(Resource.Id.secondPoint).GetX();
                    break;
                case 2:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_three);
                    this.pointPosition = FindViewById(Resource.Id.thirdPoint).GetX();
                    break;
                case 3:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_one);
                    this.pointPosition = FindViewById(Resource.Id.fourthPoint).GetX();
                    break;
                case 4:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_one);
                    this.pointPosition = FindViewById(Resource.Id.fifthPoint).GetX();
                    break;
                case 5:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_two);
                    this.pointPosition = FindViewById(Resource.Id.sixthPoint).GetX();
                    break;

                default:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_three);
                    this.pointPosition = 0;
                    break;
            }

            float movePosition = 0;

            if (pointLay.Width != 0)
                movePosition = this.pointPosition;

            RunOnUiThread(() => movePoint.SetX(movePosition));

        }
    }
}


