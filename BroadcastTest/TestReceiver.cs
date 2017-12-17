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
	/// <summary>
	/// ブロードキャストレシーバーを manifest に登録するパターン
	/// 特に何もしないでもアプリ起動中はずっといる
	/// </summary>
	[BroadcastReceiver(Enabled =true, Exported = false)]
	[IntentFilter(new[]{WifiManager.WifiStateChangedAction})]	// wifiのステートが変わったらブロードキャストされる
	class TestReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			Android.Util.Log.Info("TestReceiver", $"OnReceive. intent = {intent.Action}");
			Toast.MakeText(context, $"TestReceiver OnReceive. intent = {intent.Action}", ToastLength.Short).Show();

		}
	}
}