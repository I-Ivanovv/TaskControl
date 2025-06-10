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

        /// <summary>
        /// Връща списък със задачите и състоянията им ("Pending", "In Progress" или "Completed").
        /// </summary>
        /// <returns>Списък от низове, съдържащи името на задачата и нейното състояние.</returns>
        public List<string> GetTasks()
        {
            List<Models.Task> tasks = taskListContext.Tasks.ToList();
            List<string> taskAndS = new List<string>();
            foreach (var task in tasks)
            {
                taskAndS.Add(task.Task1);
                if (task.StatusId == 1)
                {
                    taskAndS.Add("Pending");
                }
                else if (task.StatusId == 2)
                {
                    taskAndS.Add("In Progress");
                }
                else
                {
                    taskAndS.Add("Completed");
                }
            }
            return taskAndS;

        }

        /// <summary>
        /// Добавя нова задача в базата данни със зададени приоритет, категория и срок.
        /// </summary>
        /// <param name="task">Името на задачата.</param>
        /// <param name="priority">Приоритетът на задачата (напр. "High", "Medium").</param>
        /// <param name="category">Категорията, към която принадлежи задачата.</param>
        /// <param name="duedate">Краен срок на задачата.</param>
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

        /// <summary>
        /// Търси задачи, които съдържат дадена ключова дума в името си.
        /// </summary>
        /// <param name="keyword">Ключова дума за търсене.</param>
        /// <returns>Списък с намерените задачи и техния статус.</returns>
        public List<string> SearchTask(string keyword)
        {
            List<Models.Task> taskList = taskListContext.Tasks.Where(t => t.Task1.Contains(keyword)).ToList();
            List<string> tasks = new List<string>();
            foreach (var task in taskList)
            {
                tasks.Add(task.Task1);
                if (task.StatusId == 1)
                {
                    tasks.Add("Pending");
                }
                else if (task.StatusId == 2)
                {
                    tasks.Add("In Progress");
                }
                else
                {
                    tasks.Add("Completed");
                }
            }
            return tasks;
        }

        /// <summary>
        /// Назначава задача на конкретен човек.
        /// </summary>
        /// <param name="taskName">Името на задачата.</param>
        /// <param name="name">Пълното име на лицето (име и фамилия, разделени с интервал).</param>
        /// <param name="type">0 за съобщение с MessageBox, 1 за съобщение в конзолата.</param>
        public void AssignTask(string taskName, string name, int type)
        {
            List<string> FirstAndLastName = name.Split(' ').ToList();
            Models.Task task = taskListContext.Tasks.Where(t => t.Task1 == taskName).FirstOrDefault();
            int tId = task.TaskId;
            int pId = taskListContext.People.Where(p => p.FirstName == FirstAndLastName[0] && p.LastName == FirstAndLastName[1]).Select(p => p.PersonId).FirstOrDefault();
            TaskPerson tp = new TaskPerson()
            {
                TaskId = tId,
                PersonId = pId,
                TimeAssigned = DateOnly.FromDateTime(DateTime.Now)
            };
            TaskPerson checkTP = taskListContext.TaskPeople.Where(t => t.TaskId == tId && t.PersonId == pId).FirstOrDefault();
            if (checkTP != null)
            {
                if (type == 0)
                {
                    MessageBox.Show("The task has already been assigned to this Person!");
                }
                else
                {
                    Console.WriteLine("- The task has already been assigned to this Person! -");
                }
                return;
            }
            taskListContext.TaskPeople.Add(tp);
            task.StatusId = 2;
            taskListContext.SaveChanges();
            if (type == 0)
            {
                MessageBox.Show("The task has been successfully assigned!");
            }
            else
            {
                Console.WriteLine("- The Task has been successfully assigned! -");
            }
        }
        /// <summary>
        /// Маркира задача като завършена и премахва свързаните с нея назначения.
        /// </summary>
        /// <param name="taskName">Името на задачата.</param>
        public void CompleteTask(string taskName)
        {
            Models.Task task = taskListContext.Tasks.Where(t => t.Task1 == taskName).FirstOrDefault();
            task.StatusId = 3;
            List<TaskPerson> tp = taskListContext.TaskPeople.Where(taskp => taskp.TaskId == task.TaskId).ToList();
            foreach (var item in tp)
            {
                taskListContext.Remove(item);
            }
            taskListContext.SaveChanges();
        }

        /// <summary>
        /// Изтрива задача от базата данни, заедно с всички свързани категории и назначения.
        /// </summary>
        /// <param name="taskName">Името на задачата, която ще бъде премахната.</param>
        public void RemoveTask(string taskName)
        {
            Models.Task task = taskListContext.Tasks.Where(t => t.Task1 == taskName).FirstOrDefault();
            TaskCategory tc = taskListContext.TaskCategories.Where(t => t.TaskId == task.TaskId).FirstOrDefault();;
            List<TaskPerson> tpList = taskListContext.TaskPeople.Where(t => t.TaskId == task.TaskId).ToList();
            foreach (var tp in tpList)
            {
                taskListContext.Remove(tp);
            }
            taskListContext.TaskCategories.Remove(tc);
            taskListContext.Tasks.Remove(task);
            taskListContext.SaveChanges();

        }

        /// <summary>
        /// Проверява кои хора са назначени на дадена задача.
        /// </summary>
        /// <param name="task">Името на задачата.</param>
        /// <returns>Списък от низове, съдържащи имената на лицата (име и фамилия поотделно).</returns>
        public List<string> CheckAssigned(string task)
        {
            Models.Task ta = taskListContext.Tasks.Where(t => t.Task1 == task).FirstOrDefault();
            List<TaskPerson> tpList = taskListContext.TaskPeople.Where(tp => tp.TaskId == ta.TaskId).ToList();
            List<Person> people = new List<Person>();
            foreach (var tp in tpList)
            {
                people.Add(taskListContext.People.Where(p => p.PersonId == tp.PersonId).FirstOrDefault());
            }
            List<string> names = new List<string>();
            foreach (var p in people)
            {
                names.Add(taskListContext.People.Where(pe => pe.PersonId == p.PersonId).Select(p => p.FirstName).FirstOrDefault());
                names.Add(taskListContext.People.Where(pe => pe.PersonId == p.PersonId).Select(pe => pe.LastName).FirstOrDefault());
            }
            return names;
        }


    }
}