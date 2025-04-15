using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskControl.Models;

namespace TaskControl.Services
{
    public class TaskServices
    {
        TaskListContext taskListContext;

        public TaskServices()
        {
            taskListContext = new TaskListContext();
        }
        
        public List<string> LoadTasks()
        {
            List<string> tasks = taskListContext.Tasks.Select(t=>t.Task1).ToList();
            return tasks;
        }

        public void AddTask(string task, string priority, string category, DateOnly duedate)
        {

                
                int pId = taskListContext.Priorities.Where(p => p.Priority1 == priority).Select(i => i.PriorityId).FirstOrDefault();

                Models.Task task1 = new Models.Task()
                {
                    Task1 = task,
                    StatusId = 1,
                    PriorityId = pId,
                    DueDate = duedate,
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now)
                };
                taskListContext.Tasks.Add(task1);
                TaskCategory tc = new TaskCategory()
                {
                    TaskId = taskListContext.Tasks.OrderByDescending(t => t.TaskId).Select(t => t.TaskId).FirstOrDefault(),
                    CategoryId = taskListContext.Categories.Where(c => c.CategoryName == category).Select(c => c.CategoryId).FirstOrDefault(),
                };
                taskListContext.TaskCategories.Add(tc);
                taskListContext.SaveChanges();
                
            
        }
        public void AddPerson(string firstName, string lastName,int age,string phone)
        {

                Person person = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    PhoneNumber = phone
                };
                taskListContext.People.Add(person);
                taskListContext.SaveChanges();
            
            
        }
    }
}
