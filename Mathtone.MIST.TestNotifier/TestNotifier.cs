﻿namespace Mathtone.MIST.Tests {


	[Notifier]
	public class TestNotifier : NotifierBase {

		[Notify]
		public string SomeProperty { get; set; }

		[Notify("SomeProperty", "AllProperties")]
		public string AllProperties { get; set; }
	}

	[Notifier(NotificationMode.Implicit)]
	public class TestNotifier2 : NotifierBase {

		public string SomeProperty { get; set; }

		[Notify("SomeProperty", "AllProperties")]
		public string AllProperties { get; set; }
	}

	[Notifier(NotificationMode.Implicit)]
	public class TestNotifier3 : NotifierBase {

		public string Property1 { get; set; }

		public string Property2 { get { return Property1; } }

		int property3;
		public int Property3 {
			get { return property3; }
			set { property3 = value; }
		}
	}

	[Notifier(NotificationMode.Implicit)]
	public class TestNotifier4:NotifierBase {

		public string Property1 { get; set; }

		[NotifyTarget]
		void Notify(params string[] names) {
			foreach(var name in names) {
				base.RaisePropertyChanged(name);
			}
		}
	}
}