public class ToDo
{
    public string Title {get;set;}
    public string Notes {get;set;}
    public bool Completed {get;set;}
}

void CreateBinding()
{
    // Source
    ToDo task = new ToDo() { Title="Pickup some milk" };

    // Destination
    Entry Name = new Entry();

    // Intermediary
    Binding nameBinding = new Binding();
    nameBinding.Source = task; // Set Source
    nameBinding.Path = "Title"; // Set bindable property available in the source
    Name.SetBinding(Entry.TextProperty, nameBinding); // Apply binding to destination
}

void UseBindingContext()
{
    ToDo task = new ToDo(){ Title = "Buy stuff" };
    Entry Name = new Entry();
    Name.BindingContext = task;
    Name.SetBinding<ToDo>(Entry.TextProperty, data => data.Title, BindingMode.TwoWay)
}

// Uses the stack layout called GlobalBindingContextView
void UseBindingContextGlobally()
{
    ToDo task = new ToDo(){ Title = "Buy stuff", Notes = "Some notes", Completed = false };
    BindingContext = task; // Bind all data
    InitializeComponent(); // Initialize UI with binded data
}