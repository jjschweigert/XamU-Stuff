public class ToDo_Model : INotifyPropertyChanged
{
    private string _Title {get;set;}
    public string Title 
    {
        get
        {
            return _Title;
        }
        set
        {
            if(_Title != value)
            {
                _Title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }
    }

    private string _Notes {get;set;}
    public string Notes
    {
        get
        {
            return _Notes;
        }
        set
        {
            if(_Notes != value)
            {
                _Notes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Notes)));
            }
        }
    }

    private DateTime _By {get;set;}
    public DateTime By
    {
        get
        {
            return _By;
        }
        set
        {
            if(_By != value)
            {
                _By = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(By)));
            }
        }
    }

    private bool _Completed {get;set;}
    public bool Completed
    {
        get
        {
            return _Completed;
        }
        set
        {
            if(_Completed != value)
            {
                _Completed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Completed)));
            }
        }
    }

}