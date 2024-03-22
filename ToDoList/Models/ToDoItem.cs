namespace ToDoList.Models;

public class ToDoItem(string title, int priority)
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime CreationTime { get; } = DateTime.Now;
    public bool IsDone { get; set; } = false;
    public string Title { get; set; } = title;
    public int Priority { get; set; } = priority;


    public TextDecorations TitleTextDecoration { get; set; } = TextDecorations.None;
    public string DoneButtonText { get; set; } = "Done";
}
