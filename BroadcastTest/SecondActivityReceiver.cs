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

namespace BroadcastTest
{
	/// <summary>
	/// manifestには登録しない
	/// どこかのアクティビティなどからインスタンス化される際に登録してもらう
	/// このレシーバーを明示的にインスタンス化してやる必要がある
	/// </summary>
	class SecondActivityReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			Android.Util.Log.Info("SecondActivityReceiver", $"OnReceive. intent = {intent.Action}");
			Toast.MakeText(context, $"SecondActivityReceiver OnReceive. intent = {intent.Action}", ToastLength.Short).Show();

		}
	}
}