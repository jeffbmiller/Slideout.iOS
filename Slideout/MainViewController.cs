using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Slideout
{
	partial class MainViewController : UIViewController
	{
		public MainViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.MenuBtn.Clicked += (object sender, EventArgs e) => {
				NSNotificationCenter.DefaultCenter.PostNotificationName("menuToggle",MenuBtn);
			};
		}
	}
}
