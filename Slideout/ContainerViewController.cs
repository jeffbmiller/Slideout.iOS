using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Slideout
{
	partial class ContainerViewController : UIViewController
	{
		UINavigationController mainNavigationController;
		UITableViewController menuTableViewController;
		private bool menuShown;

		public ContainerViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			mainNavigationController = (UINavigationController) Storyboard.InstantiateViewController ("mainNavigation");
			menuTableViewController = (UITableViewController) Storyboard.InstantiateViewController ("menuTableViewController");
			menuTableViewController.View.Layer.ShadowColor = UIColor.Black.CGColor;
			menuTableViewController.View.Layer.ShadowRadius = 3;
			menuTableViewController.View.Layer.ShadowOffset = new CoreGraphics.CGSize (2, 2);
			menuTableViewController.View.Layer.ShadowOpacity = 1;
			menuTableViewController.View.ClipsToBounds = false;
			this.View.AddSubview (menuTableViewController.View);
			this.View.AddSubview (mainNavigationController.View);
			NSNotificationCenter.DefaultCenter.AddObserver (new NSString("menuToggle"), x => {
				if (menuShown)
					hideMenu();
				else
					showMenu();
			});
		}

		private void showMenu() 
		{
			UIView.Animate (0.3, () => {
				mainNavigationController.View.Frame = new CoreGraphics.CGRect(View.Frame.X + 235,View.Frame.Y,View.Frame.Width, View.Frame.Height);
			}, ()=> {
				menuShown = true;
			});

		}

		private void hideMenu() 
		{
			UIView.Animate (0.3, () => {
				mainNavigationController.View.Frame = new CoreGraphics.CGRect(0,View.Frame.Y,View.Frame.Width, View.Frame.Height);
			}, ()=> {
				menuShown = false;
			});
		}

	}
}
