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
using Xamarin.Forms;
using Android.Gms.Ads;
using Xamarin.Forms.Platform.Android;
using PingTest.ViewModels;
using PingTest.Droid.Helpers;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(PingTest.ViewModels.AdMobView), typeof(AdViewRenderer))]
namespace PingTest.Droid.Helpers
{
    public class AdViewRenderer : ViewRenderer<AdMobView, AdView>
    {
        public AdViewRenderer(Context context) : base(context) { }
        string myAdID = "ca-app-pub-6838059012127071/4253322273";
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;
        AdView CreateAdView()
        {
            if (adView != null) return adView;
            adView = new AdView(Context);
            adView.AdSize = adSize;
            adView.AdUnitId = myAdID;
            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

            adView.LayoutParameters = adParams;
            AdRequest adRequest = new AdRequest.Builder().Build();
            adView.LoadAd(adRequest);
            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateAdView();
                SetNativeControl(adView);
            }
        }
    }
}