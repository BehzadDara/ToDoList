using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ToDoList.Models;

namespace ToDoList.ViewModels;

public partial class MainPageViewModel(ToDoListDbContext dbContext) : ObservableObject
{
    [ObservableProperty]
    private Guid id;

    [ObservableProperty]
    private bool isDone;

    [ObservableProperty]
    private TextDecorations titleTextDecoration;

    [ObservableProperty]
    private string doneButtonText = string.Empty;

    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private int? priority;

    [ObservableProperty]
    List<ToDoItem> items = [];// new([.. dbContext.ToDoItems]);

    public ObservableCollection<ToDoItem> OrderedItems
    {
        get
        {
            var orderedItems = Items
                .OrderBy(x => x.IsDone)
                .ThenBy(x => x.Priority)
                .ThenByDescending(x => x.CreationTime);

            return new ObservableCollection<ToDoItem>(orderedItems);
        }
    }

    [RelayCommand]
    void Add()
    {
        //var x = dbContext.ToDoItems.ToList();
        if (string.IsNullOrEmpty(Title) || !Priority.HasValue || Priority.Value < 1 || Priority.Value > 99)
        {
            return;
        }

        Items.Add(new(Title, Priority.Value));
        OnPropertyChanged(nameof(OrderedItems));

        //dbContext.ToDoItems.Add(new(Title, Priority!.Value));
        //dbContext.SaveChanges();

        Title = string.Empty;
        Priority = null;
    }

    [RelayCommand]
    void Update(Guid id)
    {
        var toDoItem = Items.First(x => x.Id == id);
        toDoItem.IsDone = !toDoItem.IsDone;

        //dbContext.Update(toDoItem);
        //dbContext.SaveChanges();

        OnPropertyChanged(nameof(OrderedItems));
    }

    [RelayCommand]
    void Delete(Guid id)
    {
        var toDoItem = Items.First(x => x.Id == id);
        Items.Remove(toDoItem);

        //dbContext.Remove(toDoItem);
        //dbContext.SaveChanges();

        OnPropertyChanged(nameof(OrderedItems));
    }
}
