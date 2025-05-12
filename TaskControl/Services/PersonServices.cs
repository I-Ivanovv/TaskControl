using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskControl.Models;

namespace TaskControl.Services
{
    class PersonServices
    {
        TaskListContext taskListContext;

        public PersonServices()
        {
            taskListContext = new TaskListContext();
        }

        public List<string> GetFirstName()
        {
            List<string> firstNames = taskListContext.People.Select(t => t.FirstName).ToList();
            return firstNames;
        }
        public List<string> GetLastName()
        {
            List<string> lastNames = taskListContext.People.Select(t => t.LastName).ToList();
            return lastNames;
        }

        public void AddPerson(string firstName, string lastName, int age, string phone)
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