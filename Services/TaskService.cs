using Tasks.Models;

namespace Tasks.Services;

public static class TaskService
{
    private static List<MyTask> myTasks;

    static TaskService()
    {
        myTasks= new List<MyTask>
        {
            new MyTask{ID=1, NameOfTask="core HomeWork", IsDone=true},
            new MyTask{ID=2, NameOfTask="shopping",IsDone=false},
            new MyTask{ID=3, NameOfTask="go to sleep early",IsDone=false}
        };
    }
    public static List<MyTask> GetAll()=>myTasks;

    public static MyTask GetByID(int id)
    {
        return myTasks.FirstOrDefault(t=>t.ID==id);
    }

    public static int Add(MyTask newTask)
    {
        if(myTasks.Count==0)
        {
            newTask.ID=1;
        }
        else
        {
            newTask.ID=myTasks.Max(t=>t.ID)+1;
        }
        myTasks.Add(newTask);
        return newTask.ID;
    }

    public static bool Update(int id,MyTask newTask)
    {
        if(id!=newTask.ID)
            return false;

        var existingTask = GetByID(id);
        if (existingTask == null )
            return false;

        var index=myTasks.IndexOf(existingTask);
        if(index==-1)
            return false;

        myTasks[index]=newTask;


        return true;
    }

    public static bool Delete(int id)
    {
        var existingTask=GetByID(id);

        if(existingTask==null)
            return false;

        var index=myTasks.IndexOf(existingTask);
        if(index==-1)
             return false;

        myTasks.RemoveAt(index);
        return true;
    }
}
