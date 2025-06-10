using Microsoft.EntityFrameworkCore;
using TaskControl.Services;
namespace TaskTests
{
    public class Tests
    {
        TaskServices taskService = new TaskServices();
        PersonServices personService = new PersonServices();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTasks_ReturnsTasksWithStatuses()
        {
            var result = taskService.GetTasks();
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Contains.Item("Complete report"));
            Assert.That(result, Contains.Item("Pending"));
        }

        [Test]
        public void GetFirstName_ReturnsNonEmptyList()
        {
            var firstNames = personService.GetFirstName();
            Assert.That(firstNames, Is.Not.Empty);
            Assert.That(firstNames, Contains.Item("John"));
        }

        [Test]
        public void GetLastName_ReturnsNonEmptyList()
        {
            var lastNames = personService.GetLastName();
            Assert.That(lastNames, Is.Not.Empty);
            Assert.That(lastNames, Contains.Item("Doe"));
        }

        [Test]
        public void AddTask_AddsNewTaskSuccessfully()
        {
            string taskName = "Integration Test Task";
            string priority = "High";
            string category = "Work";
            DateOnly dueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
            taskService.AddTask(taskName, priority, category, dueDate);
            var tasks = taskService.GetTasks();
            Assert.That(tasks, Contains.Item(taskName));
            Assert.That(tasks, Contains.Item("Pending"));
            taskService.RemoveTask("Integration Test Task");
        }

        [Test]
        public void AddPerson_AddsPersonSuccessfully()
        {
            string firstName = "TestFirst";
            string lastName = "TestLast";
            int age = 30;
            string phone = "123-456-7890";
            personService.AddPerson(firstName, lastName, age, phone);
            var firstNames = personService.GetFirstName();
            var lastNames = personService.GetLastName();
            Assert.That(firstNames, Contains.Item(firstName));
            Assert.That(lastNames, Contains.Item(lastName));
            personService.RemovePerson(firstName+" "+lastName);
        }

        [Test]
        public void SearchTask_FindsMatchingTask()
        {
            string taskName = "Integration Test Task";
            string priority = "High";
            string category = "Work";
            DateOnly dueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
            taskService.AddTask(taskName, priority, category, dueDate);
            string keyword = "test";
            var result = taskService.SearchTask(keyword);
            Assert.That(result, Contains.Item("Integration Test Task"));
            taskService.RemoveTask("Integration Test Task");
        }

        
        [Test]
        public void AssignTask_AssignsTaskSuccessfully()
        {
            string taskName = "Integration Test Task";
            string priority = "High";
            string category = "Work";
            DateOnly dueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
            taskService.AddTask(taskName, priority, category, dueDate);
            string firstName = "Alice";
            string lastName = "Smith";
            int age = 30;
            string phone = "123-456-7890";
            int type = 1;
            personService.AddPerson(firstName, lastName, age, phone);
            taskService.AssignTask(taskName, firstName+" "+lastName,type);
            var assignedPeople = taskService.CheckAssigned(taskName);
            Assert.That(assignedPeople, Contains.Item("Alice"));
            Assert.That(assignedPeople, Contains.Item("Smith"));
            taskService.RemoveTask("Integration Test Task");
            personService.RemovePerson(firstName + " " + lastName);
        }

        [Test]
        public void CheckAssigned_ReturnsAssignedPersons()
        {
            string taskName = "Integration Test Task";
            string priority = "High";
            string category = "Work";
            DateOnly dueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
            taskService.AddTask(taskName, priority, category, dueDate);
            string firstName = "Alice";
            string lastName = "Smith";
            int age = 30;
            string phone = "123-456-7890";
            int type = 1;
            personService.AddPerson(firstName, lastName, age, phone);
            taskService.AssignTask(taskName, firstName + " " + lastName, type);
            var assignedPersons = taskService.CheckAssigned(taskName);
            Assert.That(assignedPersons, Contains.Item("Alice"));
            Assert.That(assignedPersons, Contains.Item("Smith"));
            taskService.RemoveTask("Integration Test Task");
            personService.RemovePerson(firstName + " " + lastName);
        }

        [Test]
        public void CompleteTask_MarksTaskAsCompleted()
        {
            string taskName = "Integration Test Task";
            string priority = "High";
            string category = "Work";
            DateOnly dueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
            taskService.AddTask(taskName, priority, category, dueDate);
            taskService.CompleteTask(taskName);
            var tasks = taskService.GetTasks();
            Assert.That(tasks[tasks.IndexOf("Integration Test Task") + 1], Is.EqualTo("Completed"));
            taskService.RemoveTask("Integration Test Task");
        }

        [Test]
        public void RemoveTask_DeletesTaskAndAssociations()
        {
            string taskName = "Integration Test Task";
            string priority = "High";
            string category = "Work";
            DateOnly dueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
            taskService.AddTask(taskName, priority, category, dueDate);
            taskService.RemoveTask(taskName);
            var tasks = taskService.GetTasks();
            Assert.That(tasks, Does.Not.Contain(taskName));
        }


        [Test]
        public void RemovePerson_RemovesPersonSuccessfully()
        {
            string firstName = "Alice";
            string lastName = "Smith";
            int age = 30;
            string phone = "123-456-7890";
            int type = 1;
            personService.AddPerson(firstName, lastName, age, phone);
            personService.RemovePerson(firstName+" "+lastName);

            var firstNames = personService.GetFirstName();
            var lastNames = personService.GetLastName();
            Assert.That(!(firstNames.Last() == "Alice" && lastNames.Last() == "Smith"));


        }
    }
}