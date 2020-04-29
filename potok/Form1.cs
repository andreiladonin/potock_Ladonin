using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace potok
{
    public partial class Form1 : Form
    {
        Multi multi = new Multi();
        public Form1()
        {
            InitializeComponent();

            Startbutton.Click += Startbutton_Click;
            Stopbutton.Click += Startbutton_Click;
        }

        private void Stopbutton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            multi = new Multi();
            multi.ProcessChanged += Multi_ProcessChanged;
            multi.WorkCompletd += Multi_WorkCompletd;

            Startbutton.Enabled = false;

            Thread thread = new Thread(multi.Work);
            thread.Start();
        }

        private void Multi_WorkCompletd(bool obj)
        {

            Action action = () =>
            {
                string messs = obj ? "Процесс Отмнеен" : "Завершен";
                MessageBox.Show(messs);
                Startbutton.Enabled = true;
            };

            Invoke(action);
        }

        private void Multi_ProcessChanged(int progress)
        {
            Action action = () => { progressBar1.Value = progress; };

            Invoke(action);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
