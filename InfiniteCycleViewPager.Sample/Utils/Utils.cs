using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Load.Engine;
using Com.Bumptech.Glide.Request;
using Com.Bumptech.Glide.Request.Animation;
using Com.Bumptech.Glide.Request.Target;

namespace InfiniteCycleViewPager.Sample.Utils
{
    public class LibraryObject
    {

        private string mUrl;
        private string mImage;
        private string[] mImages = null;

        public LibraryObject(string url, string image)
        {
            mUrl = url;
            mImage = image;
        }

        public LibraryObject(string url, string[] images)
        {
            mUrl = url;
            mImages = images;
        }

        public string getUrl()
        {
            return mUrl;
        }

        public string getImage()
        {
            return mImage;
        }

        public string[] getImages()
        {
            return mImages;
        }
    }

    public class mOnImageClickListener : Java.Lang.Object, View.IOnClickListener
    {
        private MainActivity mainActivity;

        public mOnImageClickListener(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

        public void OnClick(View v)
        {
            Intent intent = new Intent(mainActivity, typeof(YourSecondActivity));

            // Get the transition name from the string
            string transitionName = mainActivity.GetString(Resource.String.transition_string);

            // Define the view that the animation will start from
            View viewStart = mainActivity.FindViewById(Resource.Id.image);

            ActivityOptionsCompat options =

            ActivityOptionsCompat.MakeSceneTransitionAnimation(mainActivity,
                        viewStart,   // Starting view
                        transitionName    // The String
                );
            //Start the Intent
            ActivityCompat.StartActivity(mainActivity, intent, options.ToBundle());
            //IntentHelper.OpenUrlInBrowser(view.Context, (string)view.GetTag(view.getId()));
        }
    }

    public class RequestListener : Java.Lang.Object, IRequestListener
    {
        public bool OnException(Java.Lang.Exception p0, Java.Lang.Object p1, ITarget p2, bool p3)
        {
            return false;
        }

        public bool OnResourceReady(Java.Lang.Object resource, Java.Lang.Object model, ITarget target, bool isFromMemoryCache, bool isFirstResource)
        {
            var imageViewTarget = (ImageViewTarget)target;

            return new DrawableCrossFadeFactory()
                    .Build(isFromMemoryCache, isFirstResource)
                    .Animate(
                            new BitmapDrawable(
                        ((View)imageViewTarget.View).Resources,
                        //Cast to Bitmap is not valid
                        (Bitmap)resource
                            ),
                            imageViewTarget
                    );
        }
    }

    public static class AppUtils
    {
        public static void SetupImage(Context context, ImageView imageView, LibraryObject libraryObject, MainActivity mainActivity)
        {
            SetupImage(context, imageView, libraryObject, -1,  mainActivity);
        }

        public static void SetupImage(Context context, ImageView imageView, LibraryObject libraryObject, int position,  MainActivity mainActivity)
        {
            imageView.SetTag(imageView.Id, libraryObject.getUrl());
            imageView.SetOnClickListener(new mOnImageClickListener(mainActivity));

            //Will load the images, but is quite slow
            //Glide.With(context)
            //        .Load(position == -1 ? libraryObject.getImage() : libraryObject.getImages()[position])
            //     .CenterCrop()
            //     .DiskCacheStrategy(DiskCacheStrategy.None)
            //     //.Listener(new RequestListener())
            //     .Into(imageView);
        }
    }
}