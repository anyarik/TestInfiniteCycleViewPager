using System;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Com.Gigamole.Infinitecycleviewpager;

using InfiniteCycleViewPager.Sample.Utils;

namespace InfiniteCycleViewPager.Sample.Adapters
{
    public class HorizontalPagerAdapter : PagerAdapter
    {
        private Utils.LibraryObject[] LIBRARIES = new Utils.LibraryObject[]{
            new Utils.LibraryObject(
                    "https://github.com/DevLight-Mobile-Agency/NavigationTabBar",
                    "https://lh4.googleusercontent.com/-mF70XCnMpgk/V1NnK34tnhI/AAAAAAAACkY/z0Z15Q_7gg4fMovWiEvo9agJgz7m933cQCL0B/w323-h552-no/btbntb.gif"
            ),
            new Utils.LibraryObject(
                    "https://github.com/DevLight-Mobile-Agency/NavigationTabStrip",
                    "https://lh6.googleusercontent.com/-wpGnxe1Vefc/VziiygaS9WI/AAAAAAAACd4/c4fU_EG-DHkoby1SIbI5BDtqITpGiZZhwCL0B/w326-h551-no/nts.gif"
            ),
            new Utils.LibraryObject(
                    "https://github.com/DevLight-Mobile-Agency/ShadowLayout",
                    "https://lh4.googleusercontent.com/-2JB-2cEv8lk/Vx4FmHQhjOI/AAAAAAAACTA/nrRGFjcQXBsGiISYSZ5k8gUsVcRw5GSRQCL0B/w349-h552-no/sl.png"
            ),
               new Utils.LibraryObject(
                    "https://github.com/DevLight-Mobile-Agency/NavigationTabBar",
                    "https://lh4.googleusercontent.com/-mF70XCnMpgk/V1NnK34tnhI/AAAAAAAACkY/z0Z15Q_7gg4fMovWiEvo9agJgz7m933cQCL0B/w323-h552-no/btbntb.gif"
            ),
            new Utils.LibraryObject(
                    "https://github.com/DevLight-Mobile-Agency/NavigationTabStrip",
                    "https://lh6.googleusercontent.com/-wpGnxe1Vefc/VziiygaS9WI/AAAAAAAACd4/c4fU_EG-DHkoby1SIbI5BDtqITpGiZZhwCL0B/w326-h551-no/nts.gif"
            ),
            new Utils.LibraryObject(
                    "https://github.com/DevLight-Mobile-Agency/ShadowLayout",
                    "https://lh4.googleusercontent.com/-2JB-2cEv8lk/Vx4FmHQhjOI/AAAAAAAACTA/nrRGFjcQXBsGiISYSZ5k8gUsVcRw5GSRQCL0B/w349-h552-no/sl.png"
            )
    };

        private Context mContext;
        private LayoutInflater mLayoutInflater;

        private bool mIsTwoWay;
        private MainActivity mainActivity;

        public HorizontalPagerAdapter(Context context, bool isTwoWay)
        {
            mContext = context;
            mLayoutInflater = LayoutInflater.From(context);
            mIsTwoWay = isTwoWay;
        }

        public HorizontalPagerAdapter(Context context, bool isTwoWay, MainActivity mainActivity) : this(context, isTwoWay)
        {
            this.mainActivity = mainActivity;
        }

        public override int Count
        {
            get
            {
                return  LIBRARIES.Length;
            }
        }

        public override int GetItemPosition(Java.Lang.Object objectValue)
        {
            return PositionNone;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View view;

            view = mLayoutInflater.Inflate(Resource.Layout.item, container, false);
            AppUtils.SetupImage(mContext, view.FindViewById<ImageView>(Resource.Id.image), LIBRARIES[position], mainActivity);
          
            container.AddView(view);

            return view;
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object objectValue)
        {
            return view.Equals(objectValue);
        }
        

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object objectValue)
        {
            container.RemoveView((View)objectValue);
        }
    }
}

