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
        
        public List<string> GetTasks()
        {
            List<string> tasks = taskListContext.Tasks.Select(t=>t.Task1).ToList();
            return tasks;
            
        }
        public List<string> GetFirstName()
        {
            List<string> firstNames = taskListContext.People.Select(t=>t.FirstName).ToList();
            return firstNames;
        }
        public List<string> GetLastName()
        {
            List<string> lastNames = taskListContext.People.Select(t=>t.LastName).ToList();
            return lastNames;
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
            taskListContext.SaveChanges();
            TaskCategory tc = new TaskCategory()
            {
                TaskId = task1.TaskId,
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

        public List<string> SearchTask(string keyword)
        {
            List<string> taskList = taskListContext.Tasks.Where(t=>t.Task1.Contains(keyword)).Select(t=>t.Task1).ToList();
            return taskList;
        }

        public void AssignTask(string taskName,string name)
        {
            List<string> FirstAndLastName = name.Split(' ').ToList();
            Models.Task task = taskListContext.Tasks.Where(t => t.Task1 == taskName).FirstOrDefault();
            int tId = task.TaskId;
            int pId = taskListContext.People.Where(p => p.FirstName == FirstAndLastName[0] && p.LastName == FirstAndLastName[1]).Select(p=>p.PersonId).FirstOrDefault();
            TaskPerson tp = new TaskPerson()
            {
                TaskId = tId,
                PersonId = pId,
                TimeAssigned = DateOnly.FromDateTime(DateTime.Now)
            };
            TaskPerson checkTP = taskListContext.TaskPeople.Where(t => t.TaskId == tId && t.PersonId == pId).FirstOrDefault();
            if (checkTP != null)
            {
                MessageBox.Show("The task has already been assigned to this Person!");
                return;
            }
            taskListContext.TaskPeople.Add(tp);
            task.StatusId = 2;
            taskListContext.SaveChanges();
            MessageBox.Show("The task has been successfully assigned!");
        }
        public void CompleteTask(string taskName)
        {
            Models.Task task = taskListContext.Tasks.Where(t => t.Task1 == taskName).FirstOrDefault();
            task.StatusId = 3;
            taskListContext.SaveChanges();
        }
        public void RemoveTask(string taskName)
        {
            Models.Task task = taskListContext.Tasks.Where(t => t.Task1 == taskName).FirstOrDefault();
            taskListContext.Tasks.Remove(task);
            TaskCategory tc = taskListContext.TaskCategories.Where(t => t.TaskId == task.TaskId).FirstOrDefault();
            taskListContext.TaskCategories.Remove(tc);
            List<TaskPerson> tpList = taskListContext.TaskPeople.Where(t => t.TaskId == task.TaskId).ToList();
            foreach (var tp in tpList)
            {
                taskListContext.Remove(tp);
            }
            taskListContext.SaveChanges();

        }

        public void RemovePerson(string personName)
        {
            List<string> FirstAndLastName = personName.Split(' ').ToList();
            Person per = taskListContext.People.Where(p => p.FirstName == FirstAndLastName[0] && p.LastName == FirstAndLastName[1]).FirstOrDefault();
            taskListContext.People.Remove(per);
            List<TaskPerson> tpList = taskListContext.TaskPeople.Where(t => t.PersonId == per.PersonId).ToList();
            foreach (var tp in tpList)
            {
                taskListContext.Remove(tp);
            }
            taskListContext.SaveChanges();
        }
    }
}
