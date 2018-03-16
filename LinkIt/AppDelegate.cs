using AppKit;
using Foundation;

namespace LinkIt
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        private NSStatusItem _barItem;

        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
            _barItem =  NSStatusBar.SystemStatusBar.CreateStatusItem(NSStatusItemLength.Variable);
            _barItem.Title = "LINK IT!";
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
