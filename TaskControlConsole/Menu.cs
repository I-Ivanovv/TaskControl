using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskControl.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskControlConsole
{
    internal class Menu
    {
        TaskServices taskServices;
        PersonServices personServices;

        public Menu()
        {
            taskServices = new TaskServices();
            personServices = new PersonServices();
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========= Task Control =========");
                Console.WriteLine("| [1] Create Task              |");
                Console.WriteLine("| [2] Add Person               |");
                Console.WriteLine("| [3] Search Task              |");
                Console.WriteLine("| [4] Check Assigned Person    |");
                Console.WriteLine("| [5] Assign Person to Task    |");
                Console.WriteLine("| [6] Complete Task            |");
                Console.WriteLine("| [7] Remove Task              |");
                Console.WriteLine("| [8] Remove Person            |");
                Console.WriteLine("| [0] Exit App                 |");
                Console.WriteLine("================================");
                Console.Write("\nSelect Option: ");
                int option;
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("- Invalid Option! Press Enter to Continue -");
                    Console.ReadLine();
                    continue;
                }
                switch (option)
                {
                    default:
                        Console.Write("- Invalid Option! Press Enter to Continue -");
                        Console.ReadLine();
                        continue;
                    case 1:
                        CreateTask();
                        continue;
                    case 2:
                        AddPerson();
                        continue;
                    case 3:
                        SearchTask();
                        continue;
                    case 4:
                        CheckAssigned();
                        continue;
                    case 5:
                        AssignTask();
                        continue;
                    case 6:
                        CompleteTask();
                        continue;
                    case 7:
                        RemoveTask();
                        continue;
                    case 8:
                        RemovePerson();
                        continue;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void CreateTask()
        {
            Console.Clear();
            Console.WriteLine("========= Creating Task =========");
            Console.WriteLine("- Enter X anytime to go back -");
            bool valid = false;
            string task = "";
            string priority = "";
            string category = "";
            DateOnly dueDate = new DateOnly(1111,1,1);

            while (valid == false)
            {
                Console.Write("Enter Task: ");
                task = Console.ReadLine();
                if (task.ToLower() == "x")
                {
                    return;
                }
                if (task == "")
                {
                    Console.WriteLine("- The Task cannot be empty! -");
                    continue;
                }
                valid = true;
            }
            valid = false;

            while (valid == false)
            {
                Console.Write("Enter Priority (Low, Medium, High) : ");
                priority = Console.ReadLine().ToLower();
                if (priority == "x")
                {
                    return;
                }
                if (priority != "low" && priority != "medium" && priority != "high")
                {
                    Console.WriteLine("You have not selected one of the options!");
                    continue;
                }
                valid = true;
            }
            valid = false;

            while (valid == false)
            {
                Console.Write("Enter Category (Work, Personal, Home) : ");
                category = Console.ReadLine().ToLower();
                if (category == "x")
                {
                    return;
                }
                if (category != "work" && category != "personal" && category != "home")
                {
                    Console.WriteLine("- You have not selected one of the options! -");
                    continue;
                }
                valid = true;
            }
            valid = false;

            while (valid == false)
            {
                Console.Write("Enter Due Date (FORMAT: YYYY-MM-DD) : ");
                try
                {
                    string temp = Console.ReadLine();
                    if (temp.ToLower() == "x")
                    {
                        return;
                    }
                    dueDate = DateOnly.Parse(temp);
                    if (dueDate < DateOnly.FromDateTime(DateTime.Now))
                    {
                        Console.WriteLine("- The Due Date cannot be before today! -");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("- You have not entered a valid date! -");
                    continue; ;
                }
                valid = true;
            }

            taskServices.AddTask(task, priority, category, dueDate);

            Console.WriteLine("- You have successfully created the Task! -");
            Console.Write("- Press Enter to go back! -");
            Console.ReadLine();           
        }

        public void AddPerson()
        {
            Console.Clear();
            Console.WriteLine("========= Adding Person =========");
            Console.WriteLine("- Enter X anytime to go back -");
            bool valid = false;
            string firstName = "";
            string lastName = "";
            int age = 0;
            string number = "";

            while (valid == false)
            {
                Console.Write("Enter First Name: ");
                firstName = Console.ReadLine();
                if (firstName.ToLower() == "x")
                {
                    return;
                }
                if (firstName == "")
                {
                    Console.WriteLine("- The Name cannot be empty! -");
                    continue;
                }
                valid = true;
            }
            valid = false;

            while (valid == false)
            {
                Console.Write("Enter Last Name : ");
                lastName = Console.ReadLine();
                if (lastName.ToLower() == "x")
                {
                    return;
                }
                if (lastName == "")
                {
                    Console.WriteLine("- The Name cannot be empty! -");
                    continue;
                }
                valid = true;
            }
            valid = false;

            while (valid == false)
            {
                Console.Write("Enter Age : ");
                try
                {
                    string temp = Console.ReadLine();
                    if (temp.ToLower() == "x")
                    {
                        return;
                    }
                    age = int.Parse(temp);
                    if (age < 0)
                    {
                        Console.WriteLine("- You have not entered a valid age! -");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("- You have not entered a valid age! -");
                    continue;
                }
                valid = true;
            }
            valid = false;

            while (valid == false)
            {
                Console.Write("Enter Phone Number : ");
                number = Console.ReadLine();
                if (number.ToLower() == "x")
                {
                    return;
                }
                if (number == "")
                {
                    Console.WriteLine("- The Number cannot be empty -");
                    continue;
                }             
                valid = true;
            }

            personServices.AddPerson(firstName, lastName,age,number);
            Console.WriteLine("- You have successfully added the Person! -");
            Console.Write("- Press Enter to go back! -");
            Console.ReadLine();
        }

        public void SearchTask()
        {
            Console.Clear();
            Console.WriteLine("========= Searching Tasks =========");
            Console.WriteLine("- List of Tasks -");
            List<string> tasks = taskServices.GetTasks();
            for (int i = 0; i < tasks.Count; i+=2)
            {
                Console.WriteLine($"{tasks[i]} - {tasks[i+1]}");
            }
            bool valid = false;
            string keyword = "";
            while (valid == false)
            {
                Console.Write("Enter keyword to search for a Task (X to go back) : ");
                keyword = Console.ReadLine();
                if(keyword.ToLower() == "x")
                {
                    return;
                }
                List<string> taskList = taskServices.SearchTask(keyword);
                Console.Clear();
                Console.WriteLine("========= Searching Tasks =========");
                if (taskList.Count == 0)
                {
                    Console.WriteLine("- There are no such tasks! -");
                }
                else
                {
                    Console.WriteLine("- List of Tasks -");
                    for (int i = 0; i < taskList.Count; i += 2)
                    {
                        Console.WriteLine($"{taskList[i]} - {taskList[i + 1]}");
                    }
                }


            } 
            
        }

        public void CheckAssigned()
        {
            Console.Clear();
            Console.WriteLine("========= Checking Assigned Person =========");
            LoadTasks();
            string task = SelectTask();
            if (task == "x")
            {
                return;
            }
            Console.Clear();
            Console.WriteLine("========= Checking Assigned Person =========");
            Console.WriteLine("- Assigned People -");
            List<string> names = taskServices.CheckAssigned(task);
            if (names.Count == 0)
            {
                Console.WriteLine("- There is no one assigned to this task! -");
            }
            else
            {
                for (int i = 0; i < names.Count; i += 2)
                {
                    Console.WriteLine($"{names[i]} {names[i + 1]}");
                }
            }
            Console.Write("- Press Enter to go back! -");
            Console.ReadLine();
        }

        public void AssignTask()
        {
            Console.Clear();
            Console.WriteLine("========= Assigning Task =========");
            LoadTasks();
            string task = SelectTask();
            if (task == "x")
            {
                return;
            }
            Console.Clear();
            Console.WriteLine("========= Assigning Task =========");
            LoadPeople();
            string name = SelectPerson();
            if (name == "x")
            {
                return;
            }
            taskServices.AssignTask(task, name, 1);
            Console.WriteLine("- Press Enter to go back -");
            Console.ReadLine();
        }

        public void CompleteTask()
        {
            Console.Clear();
            Console.WriteLine("========= Completing Task =========");
            LoadTasks();
            string task = SelectTask();
            if (task == "x")
            {
                return;
            }
            taskServices.CompleteTask(task);
            Console.WriteLine("- The Task has been successfully completed! -");
            Console.WriteLine("- Press Enter to go back! -");
            Console.ReadLine();
        }

        public void RemoveTask()
        {
            Console.Clear();
            Console.WriteLine("========= Removing Task =========");
            LoadTasks();
            string task = SelectTask();
            if (task == "x")
            {
                return;
            }
            taskServices.RemoveTask(task);
            Console.WriteLine("- The Task has been successfully removed! -");
            Console.WriteLine("- Press Enter to go back! -");
            Console.ReadLine();
        }

        public void RemovePerson()
        {
            Console.Clear();
            Console.WriteLine("========= Removing Person =========");
            LoadPeople();
            string name = SelectPerson();
            if (name == "x")
            {
                return;
            }
            personServices.RemovePerson(name);
            Console.WriteLine("- The Person has been successfully removed! -");
            Console.WriteLine("- Press Enter to go back! -");
            Console.ReadLine();
        }



        public void LoadTasks()
        {
            Console.WriteLine("- List of Tasks -");
            List<string> tasks = taskServices.GetTasks();
            for (int i = 1; i < tasks.Count ; i += 1)
            {
                tasks.Remove(tasks[i]);
            }
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{tasks[i]} [{i + 1}]");
            }
        }
        public string SelectTask()
        {
            List<string> tasks = taskServices.GetTasks();
            for (int i = 1; i < tasks.Count; i += 1)
            {
                tasks.Remove(tasks[i]);
            }
            bool valid = false;
            int num = 0;
            while (valid == false)
            {
                try
                {
                    Console.Write("Enter Task number (X to go back): ");
                    string temp = Console.ReadLine();
                    if (temp.ToLower() == "x")
                    {
                        return temp;
                    }
                    num = int.Parse(temp) - 1;
                    if (num >= tasks.Count || num < 0)
                    {
                        Console.WriteLine("- You have not entered a valid number! -");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("- You have not entered a valid number! -");
                    continue;
                }
                valid = true;
            }
            return tasks[num];
        }

        public void LoadPeople()
        {
            Console.WriteLine("- List of People -");
            List<string> firstNames = personServices.GetFirstName();
            List<string> lastNames = personServices.GetLastName();
            for (int i = 0; i < firstNames.Count; i++)
            {
                Console.WriteLine($"{firstNames[i]} {lastNames[i]} [{i + 1}]");
            }
        }
        public string SelectPerson()
        {
            List<string> firstNames = personServices.GetFirstName();
            List<string> lastNames = personServices.GetLastName();
            bool valid = false;
            int numP = 0;
            while (valid == false)
            {
                try
                {
                    Console.Write("Enter Person number (X to go back): ");
                    string temp = Console.ReadLine();
                    if (temp.ToLower() == "x")
                    {
                        return temp;
                    }
                    numP = int.Parse(temp) - 1;
                    if (numP >= firstNames.Count || numP < 0)
                    {
                        Console.WriteLine("- You have not entered a valid number! -");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("- You have not entered a valid number! -");
                    continue;
                }
                valid = true;
            }
            return firstNames[numP] + " " + lastNames[numP];
        }
    }
}
