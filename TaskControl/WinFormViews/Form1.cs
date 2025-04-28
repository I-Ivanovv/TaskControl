using TaskControl.Models;
using TaskControl.Services;
namespace TaskControl
{
    public partial class Form1 : Form
    {
        TaskServices taskServices;
        public Form1()
        {
            InitializeComponent();
            taskServices = new TaskServices();
            LoadTask();
            LoadPeople();
        }
        public void LoadTask()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox4.Items.Clear();
            List<string> tasks = taskServices.GetTasks();
            foreach (var task in tasks)
            {
                listBox1.Items.Add(task);
                listBox2.Items.Add(task);
                listBox4.Items.Add(task);
            }
        }
        public void LoadPeople()
        {
            listBox3.Items.Clear();
            listBox5.Items.Clear();
            List<string> firstNames = taskServices.GetFirstName();
            List<string> lastNames = taskServices.GetLastName();
            for (int i = 0; i < firstNames.Count; i++)
            {
                listBox3.Items.Add(firstNames[i] + " " + lastNames[i]);
                listBox5.Items.Add(firstNames[i] + " " + lastNames[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string task = TBTask.Text;
            string priority = CBPrio.Text;
            string category = CBCat.Text;
            DateOnly duedate;
            try
            {
                duedate = DateOnly.Parse(TBDueDate.Text);
                if (duedate < DateOnly.FromDateTime(DateTime.Now))
                {
                    MessageBox.Show("The due date is before today!");
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Enter a valid date! FORMAT: YYYY-DD-MM");
                return;
            }

            taskServices.AddTask(task, priority, category, duedate);
            MessageBox.Show("The Task has been added successfully!");
            LoadTask();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstName = TBFirstName.Text;
            string lastName = TBLastName.Text;
            int age = int.Parse(TBAge.Text);
            string phone = TBPhone.Text;
            taskServices.AddPerson(firstName, lastName, age, phone);
            MessageBox.Show("The Person has been added successfully!");
            LoadPeople();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string keyword = TBKeyword.Text;
            List<string> taskList = taskServices.SearchTask(keyword);
            listBox1.Items.Clear();
            if (taskList.Count == 0)
            {
                MessageBox.Show("There are no such tasks!");
                return;
            }
            foreach (string task in taskList)
            {
                listBox1.Items.Add(task);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string taskName;
            string name;
            try
            {
                taskName = listBox2.SelectedItem.ToString();
                name = listBox3.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("You have not seleced a Task or a Person!");
                return;
            }
            taskServices.AssignTask(taskName, name);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string taskName;
            try
            {
                taskName = listBox2.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("You have not seleced a Task!");
                return;
            }
            taskServices.CompleteTask(taskName);
            MessageBox.Show("The task has been successfully completed!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string taskName;
            try
            {
                taskName = listBox4.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("You have not seleced a Task!");
                return;
            }
            taskServices.RemoveTask(taskName);
            MessageBox.Show("The task has been successfully removed!");
            LoadTask();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string personName;
            try
            {
                personName = listBox5.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("You have not seleced a Person!");
                return;
            }
            taskServices.RemovePerson(personName);
            MessageBox.Show("The person has been successfully removed!");
            LoadPeople();
        }
    }
}
