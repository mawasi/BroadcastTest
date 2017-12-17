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
using Android.Net.Wifi;

namespace BroadcastTest
{
	[Activity(Label = "@string/app_name")]
	public class SecondActivity : Activity
	{
		Button _SwitchActivity = null;
		Switch _WifiSwitch = null;

		SecondActivityReceiver _Receiver = null;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Second);

			Android.Util.Log.Info("SecondActivity", "OnCreate");

			_SwitchActivity = FindViewById<Button>(Resource.Id.button1);
			_SwitchActivity.Click += OnClick;


			WifiManager wifiManager = (WifiManager)GetSystemService(Context.WifiService);
			_WifiSwitch = FindViewById<Switch>(Resource.Id.switch1);
			if(wifiManager?.IsWifiEnabled ?? false){
				_WifiSwitch.Checked = true;
			}
			_WifiSwitch.CheckedChange += OnCheckedChange;
		}


		protected override void OnResume()
		{
			base.OnResume();

			Android.Util.Log.Info("SecondActivity", "OnResume");

			// このActivityが有効な間のみレシーバーに登録される
			var NetintentFilter = new IntentFilter();
			NetintentFilter.AddAction(WifiManager.WifiStateChangedAction);
			_Receiver = new SecondActivityReceiver();
			RegisterReceiver(_Receiver, NetintentFilter);

		}

		protected override void OnPause()
		{
			base.OnPause();

			Android.Util.Log.Info("SecondActivity", "OnPause");

			// レシーバーの登録解除
			if(_Receiver != null){
				UnregisterReceiver(_Receiver);
			}
		}



		void OnClick(object sender, EventArgs e)
		{
			Finish();
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