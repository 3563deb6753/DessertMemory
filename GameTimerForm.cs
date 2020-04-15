using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class GameTimerForm : Form
    {

        int total = 0;
        public GameTimerForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            total++;
            gameTimerLabel.Text = total.ToString();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
