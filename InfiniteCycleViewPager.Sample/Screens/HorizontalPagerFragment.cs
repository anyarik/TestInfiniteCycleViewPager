using System;
using Android.Support.V4.App;
using Com.Gigamole.Infinitecycleviewpager;
using InfiniteCycleViewPager.Sample.Adapters;
using Android.Widget;
using Android.Content;
using Android.Views;

namespace InfiniteCycleViewPager.Sample.Screens
{
    public class HorizontalPagerFragment : Fragment
    {
        public RelativeLayout backgroundView;
        private float pointPosition;
        private ImageView movePoint;
        private RelativeLayout pointLay;

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_horizontal, container, false);
        }

        public override void OnViewCreated(Android.Views.View view, Android.OS.Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var horizontalInfiniteCycleViewPager = view.FindViewById<HorizontalInfiniteCycleViewPager>(Resource.Id.hicvp);
            horizontalInfiniteCycleViewPager.Adapter = new HorizontalPagerAdapter(Context, false);

            horizontalInfiniteCycleViewPager.PageSelected += HorizontalInfiniteCycleViewPager_PageSelected;
            horizontalInfiniteCycleViewPager.PageScrolled += HorizontalInfiniteCycleViewPager_PageScrolled;

            horizontalInfiniteCycleViewPager.Click += HorizontalInfiniteCycleViewPager_Click; ;
            horizontalInfiniteCycleViewPager.ContextClick += HorizontalInfiniteCycleViewPager_ContextClick1;

            backgroundView = view.FindViewById<RelativeLayout>(Resource.Id.current_view);
            
            this.pointLay = view.FindViewById<RelativeLayout>(Resource.Id.relLayPoints);
            this.movePoint = view.FindViewById<ImageView>(Resource.Id.movePoint);
            this.pointPosition = this.movePoint.GetX();
        }

        private void HorizontalInfiniteCycleViewPager_ContextClick1(object sender, View.ContextClickEventArgs e)
        {
           
        }

        private void HorizontalInfiniteCycleViewPager_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(YourSecondActivity));

            // Get the transition name from the string
            String transitionName = this.Activity.GetString(Resource.String.transition_string);

            // Define the view that the animation will start from
            View viewStart = this.Activity.FindViewById(Resource.Id.card_view);

            ActivityOptionsCompat options =

            ActivityOptionsCompat.MakeSceneTransitionAnimation(this.Activity,
                        viewStart,   // Starting view
                        transitionName    // The String
                );
            //Start the Intent
            ActivityCompat.StartActivity(this.Activity, intent, options.ToBundle());
        }

        [Java.Interop.Export("animateIntent")]
        public void animateIntent(View view)
        {
        }



        //public void animateIntent(View view)
        //{

        //    // Ordinary Intent for launching a new activity
         

        //}

    private void HorizontalInfiniteCycleViewPager_PageScrolled(object sender, Android.Support.V4.View.ViewPager.PageScrolledEventArgs e)
        {
            var Position = (sender as HorizontalInfiniteCycleViewPager).RealItem;
            switch (Position)
            {
                case 0:
                    this.pointPosition = this.Activity.FindViewById(Resource.Id.firstPoint).GetX();
                    break;
                case 1:
                    this.pointPosition = this.Activity.FindViewById(Resource.Id.secondPoint).GetX();
                    break;
                case 2:
                    this.pointPosition = this.Activity.FindViewById(Resource.Id.thirdPoint).GetX();
                    break;
                case 3:
                    this.pointPosition = this.Activity.FindViewById(Resource.Id.fourthPoint).GetX();
                    break;
                case 4:
                    this.pointPosition = this.Activity.FindViewById(Resource.Id.fifthPoint).GetX();
                    break;
                case 5:
                    this.pointPosition = this.Activity.FindViewById(Resource.Id.sixthPoint).GetX();
                    break;
                //case 6:
                //    this.pointPosition = this.Activity.FindViewById(Resource.Id.seventhPoint).GetX();
                //    break;
                default:
                    this.pointPosition = 0;
                    break;
            }

            float movePosition = 0;

            if (pointLay.Width != 0)
                movePosition = this.pointPosition + ((float)e.PositionOffsetPixels
                                                    / (float)((Resources.DisplayMetrics.WidthPixels / this.pointLay.Width) *6));

            this.Activity.RunOnUiThread(() => movePoint.SetX(movePosition));
        }

    private void HorizontalInfiniteCycleViewPager_PageSelected(object sender, Android.Support.V4.View.ViewPager.PageSelectedEventArgs e)
        {
            var Position = (sender as HorizontalInfiniteCycleViewPager).RealItem;
            switch (Position)
            {
                case 0:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_one);
                    break;
                case 1:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_two);
                    break;
                case 2:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_three);
                    break;
                case 3:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_one);
                    break;
                case 4:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_one);
                    break;
                case 5:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_one);
                    break;
                //case 6:
                //    this.pointPosition = this.Activity.FindViewById(Resource.Id.seventhPoint).GetX();
                //    break;
                default:
                    backgroundView.Background = Resources.GetDrawable(Resource.Drawable.background_one);
                    break;
            }


        }

    }
}

