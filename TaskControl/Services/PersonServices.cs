using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskControl.Models;

namespace TaskControl.Services
{
    public class PersonServices
    {
        TaskListContext taskListContext;

        public PersonServices()
        {
            taskListContext = new TaskListContext();
        }

        /// <summary>
        /// Връща списък с всички малки имена (FirstName) на хората в базата.
        /// </summary>
        /// <returns>Списък от низове с малките имена на хората.</returns>
        public List<string> GetFirstName()
        {
            List<string> firstNames = taskListContext.People.Select(t => t.FirstName).ToList();
            return firstNames;
        }


        /// <summary>
        /// Връща списък с всички фамилии (LastName) на хората в базата.
        /// </summary>
        /// <returns>Списък от низове с фамилиите на хората.</returns>
        public List<string> GetLastName()
        {
            List<string> lastNames = taskListContext.People.Select(t => t.LastName).ToList();
            return lastNames;
        }

        /// <summary>
        /// Добавя нов човек в базата данни със зададено име, фамилия, възраст и телефон.
        /// </summary>
        /// <param name="firstName">Малко име на човека.</param>
        /// <param name="lastName">Фамилия на човека.</param>
        /// <param name="age">Възраст на човека.</param>
        /// <param name="phone">Телефонен номер на човека.</param>
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

        /// <summary>
        /// Премахва човек от базата данни по пълното му име (име и фамилия).
        /// Освен това премахва и всички задачи, които са били назначени на този човек.
        /// </summary>
        /// <param name="personName">Пълното име на човека (име и фамилия, разделени с интервал).</param>
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