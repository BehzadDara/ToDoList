using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
