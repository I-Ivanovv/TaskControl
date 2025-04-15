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
            string test = "test";   
        }
        public void LoadTask()
        {
            List<string> tasks = taskServices.LoadTasks();
            foreach (var task in tasks)
            {
                listBox1.Items.Add(task);
                listBox2.Items.Add(task);
                listBox4.Items.Add(task);
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstName = TBFirstName.Text;
            string lastName = TBLastName.Text;
            int age = int.Parse(TBAge.Text);
            string phone = TBPhone.Text;
            taskServices.AddPerson(firstName, lastName, age, phone);
            MessageBox.Show("The Person has been added successfully!");
        }
    }
}
