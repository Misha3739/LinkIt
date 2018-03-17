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
            _barItem.Image = NSImage.ImageNamed("AppIcon");
            var menu = new NSMenu();
            menu.AddItem(new NSMenuItem()
            {
                Action = new ObjCRuntime.Selector("linkedAction"),
                Title = "LinkIt",
                KeyEquivalent = "L"
            });
            menu.AddItem(new NSMenuItem()
            {
                Action = new ObjCRuntime.Selector("quitAction"),
                Title = "Quit",
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

            var items = NSPasteboard.GeneralPasteboard.PasteboardItems;
            const string textType = "public.utf8-plain-text";
            foreach(var item in items)
            {
                foreach(var type in item.Types)
                {
                    if(type == textType)
                    {
                        string clipboardText = item.GetStringForType(textType);
                        NSPasteboard.GeneralPasteboard.ClearContents();

                        NSPasteboard.GeneralPasteboard.SetStringForType($"<a href =\"{clipboardText}\">{clipboardText}</a>","public.html");

                    }
                }
            }
        }

        [Action("quitAction")]
        private void Quit()
        {
            NSApplication.SharedApplication.Terminate(this);
        }
    }
}
