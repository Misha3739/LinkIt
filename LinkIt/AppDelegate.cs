using System.Diagnostics;
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
            _barItem = NSStatusBar.SystemStatusBar.CreateStatusItem(NSStatusItemLength.Variable);
            _barItem.Title = "LINK IT!";
            var menu = new NSMenu();
            menu.AddItem(new NSMenuItem()
            {
                Action = new ObjCRuntime.Selector("linkedAction"),
                Title = "Linked action",
                KeyEquivalent = "L"
            });
            menu.AddItem(new NSMenuItem()
            {
                Action = new ObjCRuntime.Selector("quitAction"),
                Title = "Quit action",
                KeyEquivalent = "Q"
            });
            _barItem.Menu = menu;
           // _barItem.Action = new ObjCRuntime.Selector("linkedAction");
        }
        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
        [Action("linkedAction")]
        private void Linked()
        {
            Debug.WriteLine("Linked pressed");
        }

        [Action("quitAction")]
        private void Quit()
        {
            NSApplication.SharedApplication.Terminate(this);
        }
    }
}
