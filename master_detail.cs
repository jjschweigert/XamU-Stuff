/* Set the Master behavior of the page 
   Ignored when on a mobile platform for phones */
var md = new MasterDetailPage();
md.MasterBehavior = MasterBehavior.(Default, Popover, Split, SplitOnLandscape, SplitOnPortrait);

/* Create a master detail page which derives from MasterDetailPage */
public class AppMasterDetailPage : MasterDetailPage
{
    public AppMasterDetailPage()
    {
        base.Master = new AppMenuPage();
        base.Detail = new NavigationPage(new DefaultAppPage());

        // iOS requires explicit drawer navigation icons, there is no default icon
        if(Device.RuntimePlatform == Device.iOS)
        {
            Master.Icon = (FileImageSource)ImageSource.FromFile("image.png");
        }

        // Subscribe to the page changed event for the AppMenuPage to know when to change pages
        Master.SelectedPageChanged += OnNewPageSelected;
    }

    private void OnNewPageSelected(object sender, MasterPageType PageType)
    {
        switch(PageType)
        {
            case MasterPageType.Page_1 : Detail = new NavigationPage(new Page1()); break;
            case MasterPageType.Page_2 : Detail = new NavigationPage(new Page2()); break;
            case MasterPageType.Page_3 : Detail = new NavigationPage(new Page3()); break;
            default: break;
        }

        try { IsPresented = false; }
        catch { }
    }
}

/* In the main app entry point assign a new master detail page instead of a regular content page 
   This should always be the root page of the app UI */
public partial class App : Application
{
    public App()
    {
        ...
        MainPage = new AppMasterDetailPage();
    }
}

/* Create an enum for drawer navigation */
public enum MasterPageType
{
    Page_1,
    Page_2,
    Page_3
}

/* Create an App menu page that uses the enum above to change pages */
public partial class AppMenuPage : ContentPage
{
    public event EventHandler<MasterPageType> SelectedPageChanged;

    public AppMenuPage()
    {
        Page1Button.Clicked += (s, e) => SelectedPageChanged?.Invoke(this, MasterPageType.Page_1);
        Page2Button.Clicked += (s, e) => SelectedPageChanged?.Invoke(this, MasterPageType.Page_2);
        Page3Button.Clicked += (s, e) => SelectedPageChanged?.Invoke(this, MasterPageType.Page_3);
    }
}
