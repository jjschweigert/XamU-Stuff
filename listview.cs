public void SetListViewSource(IEnumerable source)
{
    listview.Source = source;
}

public Recipe GetSelectedRecipe()
{
    return (Recipe)listview.SelectedItem;
}

public void SetRecipe()
{
    listview.SelectedItem = Cookbook.Recipes.Last();
}

/* Open a new page passing a tapped item from a list view */
async void OnRecipeTapped(object sender, ItemTappedEventArges e)
{
    Recipe selection = (Recipe)e.item;
    await Navigation.PushAsync(new DetailsPage(selection));
}

/* Use an observable collection which implements the INotifyCollectionChanged interface by default 
   Any operation on the colleciton must occur on the main UI thread i.e. use Device.BeginInvokeOnMainThread(()=>{}); */

public static class Cookbook
{
    public static IList<Recipe> Recipes {get; private set;}
    static Cookbook()
    {
        Recipes = new ObservableCollection<Recipe>();
    }
}

/* Can modify collection in background but must instruct binding system to manage collection in a thread safe manner */
BindingBase.EnableCollectionSynchronization
(
    // Instance of collection assigned to the list view
    Recipes,
    // Optional context parameter - additional data passed to the locking method
    null,
    // Must pass delegate that the listview will use to access the collection
    // Method is passed the Collection, Context, an Action, and permissions distinguishing if the collection will be altered i.e read and write
    (list, context, action, writeAccess) =>
    {
        lock (list)
        {
            action();
        }
    }
);

/* Pull To Refresh Command - See listview.xaml for implementation */
public class ViewModel : INotifyPropertyChanged
{
    public ICommand RefreshCommand {get; private set;}
    public bool IsRefreshing {get;set;}
}

public void ManuallyRefreshListViewAsIfUser()
{
    listview.BeginRefresh();
    ...
    listview.EndRefresh();
}

public void SetDataTemplate()
{
    var dt = new DataTemplate(typeof(CustomViewCell));
    dt.SetBinding(CustomViewCell.TextProperty, "Name");
    ));

    listview.ItemTemplate = dt;
}