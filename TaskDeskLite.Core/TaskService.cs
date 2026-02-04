using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace TaskDeskLite.Core;

public class TaskService : ITaskService
{
    // Persistência em memória
    private readonly List<TaskItem> _tasks = new();

    public IReadOnlyList<TaskItem> GetAll()
        => _tasks.OrderByDescending(t => t.CreatedAt).ToList();

    public TaskItem GetById(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null) throw new NotFoundException("Tarefa não encontrada.");
        return task;
    }

    public TaskItem Create(TaskItem task)
    {
        var Tarefa = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = task.Title,
            Description = task.Description,
            Priority = task.Priority,
            DueDate = task.DueDate,
            Status = TaskStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };

        
           _tasks.Add(Tarefa);
             return Tarefa;
    }

    public TaskItem Update(TaskItem task) {

        var Busca = new TaskItem
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Priority = task.Priority,
            DueDate = task.DueDate,
            Status = task.Status,
            CreatedAt = task.CreatedAt
        };


        _tasks.Add(Busca);
        return Busca;
    }

    public void Delete(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            throw new NotImplementedException("Tarefa não encontrada.");

        _tasks.Remove(task);

       
       
                }

    public void MarkAsDone(Guid id)
    {

        

        

    }
}
