/* If using custom data i.e not default views, should use class that derives from ViewCell to adjust properties for that type of cell manually 
   May be able to get most views with uneven rows but may require help, if so use this method */

/* Define a custom view cell with conditional height adjustment */
public class CustomViewCell : ViewCell
{
    ...
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        var classObject = (CustomClass)BindingContext;
        this.Height = classObject.Flag ? Height_If_True : Height_If_False;
    }
}

/* Example: Custom view cell has an image inside with a tap gesture wired to this event handler*/
public void OnImageTapped(object sender, EventArgs args)
{
    var image = sender as Image;
    /* The image sits inside of our custom view cell which sits inside the list view's view cell */
    var viewCell = image.Parent.Parent as ViewCell;

    if(image.HeightRequest < 250)
    {
        image.HeightRequest = image.Height + 100;
        viewCell.ForceUpdateSize();
    }
}

/* Listviews have no built in sort */
void OnSortAscending(object sender, EventArgs e)
{
    var data = DataSource;
    var sortedData = data.OrderBy(p => p.Name).ToList();
    ListView.ItemsSource = sortedData;
}

/* Listview filter */
void OnFilter(object sender, EventArgs e)
{
    var data = DataSource;
    var filteredData = data.Where(p => p.Name.StartsWith("A"));
    ListView.ItemsSource = filteredData;
}

/* Create a grouping class for list view grouping */
public class PersonGroup : ObservableCollection<CustomClass>
{
    public string FirstLetter {get;set;}
    public string GroupName {get;set;}
}

/* Generate a sub group of data from the full data source to use as a group list */
public void SetGroup()
{
    ILookup groupedContacts = DataSource.OrderBy(c => c.Name).ToLookup(a => a.Name[0].ToString());

    ListView.ItemSource = groupedContacts;
    ListView.IsGroupingEnabled = true;
}