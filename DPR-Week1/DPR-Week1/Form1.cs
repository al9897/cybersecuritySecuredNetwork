using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DPR_Week1
{
    public partial class Form1 : Form
    {
       // private Timer time;
        OS operatingSystem;
        private List<IScheduleStrategy> lstSchedulingStrategy;
        private List<int> random;
        enum Schedule
        {
            Fcfs,
            Sstf,
            Scan,
        };
        private IScheduleStrategy GetSchedule(Schedule schedule)
        {
            IScheduleStrategy tempSchedule;
            switch (schedule)
            {
                case Schedule.Fcfs:
                    tempSchedule = this.lstSchedulingStrategy[0];
                    break;
                case Schedule.Sstf:
                    tempSchedule = this.lstSchedulingStrategy[1];
                    break;
                case Schedule.Scan:
                    tempSchedule = this.lstSchedulingStrategy[2];
                    break;
                default:
                    return null;
            }
            return tempSchedule;
        }
        public Form1()
        {
            InitializeComponent();
            cbAlgorithm.Enabled = false;
            btAdd.Enabled = false;
            btStart.Enabled = false;
            //time = new Timer();
           // time.Interval = 1000;
            operatingSystem = new OS();
            lstSchedulingStrategy = new List<IScheduleStrategy>();
            addDiskSchedulingStrategy();
            foreach (IScheduleStrategy i in lstSchedulingStrategy)
            {
                cbAlgorithm.Items.Add(i.getName());
            }
             random = new List<int> { 23, 34, 80, 12, 33, 22, 12, 45, 34, 56, 45, 30, 25, 1 };
            foreach (int i in random)
            {
                this.operatingSystem.Add(i);
                listBox1.Items.Add(i);
            }
        }
        private void addNewNumberToListBox()
        {
            foreach (int i in operatingSystem.getlstRequest())
            {
                listBox1.Items.Add(i);
            }
        }

        private void cbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void addDiskSchedulingStrategy()
        {
            this.lstSchedulingStrategy.Add(new FCFSDiskScheduling());
            this.lstSchedulingStrategy.Add(new SSTFDiskScheduling());
            this.lstSchedulingStrategy.Add(new ScanDiskScheduling());
        }

        private void btStart_Click(object sender, EventArgs e)
        {
                  listBox2.Items.Clear();
                     this.operatingSystem.AddStrategy(this.GetSchedule((Schedule)this.cbAlgorithm.SelectedIndex));
                    this.operatingSystem.readNext();
            foreach(int i in operatingSystem.getAlreadyRead())
            {
                listBox2.Items.Add(i);
            }
                    

                
          
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            int numberToAdd = Convert.ToInt32(tbAdd.Text);
            this.operatingSystem.Add(numberToAdd);
            listBox1.Items.Clear();
            addNewNumberToListBox();

        }

        private void btReset_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            cbAlgorithm.Enabled = false;
            btAdd.Enabled = false;
            btStart.Enabled = false;
            operatingSystem.getAlreadyRead().Clear();
            operatingSystem.getlstRequest().Clear();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            this.operatingSystem.StartPoint = Convert.ToInt32(tbStartPoint.Text);
            cbAlgorithm.Enabled = true;
            btAdd.Enabled = true;
            btStart.Enabled = true;

        }
    }
}
