using System;

using Android.App;
using Android.Widget;
using Android.OS;

using Android.Content;
using Android.Net.Wifi;

namespace BroadcastTest
{
	[Activity(Label = "@string/app_name", MainLauncher = true)]
	public class MainActivity : Activity
	{

		Button _SwitchActivity = null;
		Switch _WifiSwitch = null;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			_SwitchActivity = FindViewById<Button>(Resource.Id.button1);
			_SwitchActivity.Click += OnClick;

			WifiManager wifiManager = (WifiManager)GetSystemService(Context.WifiService);
			_WifiSwitch = FindViewById<Switch>(Resource.Id.switch1);
			if(wifiManager?.IsWifiEnabled ?? false){
				_WifiSwitch.Checked = true;
			}
			_WifiSwitch.CheckedChange += OnCheckedChange;
		}

		/// <summary>
		/// ボタン押したときに呼ばれる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnClick(object sender, EventArgs e)
		{
			Intent ActivityIntent = new Intent(this, typeof(SecondActivity));
			StartActivity(ActivityIntent);
		}

		/// <summary>
		/// wifi swithc おした時に呼ばれる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{

			// スイッチの切り替えに合わせてWifiをON,OFFする
			WifiManager	wifiManager = (WifiManager)GetSystemService(Context.WifiService);
			if(wifiManager.IsWifiEnabled != e.IsChecked){
				wifiManager.SetWifiEnabled(e.IsChecked);
			}
		}
	}
}

