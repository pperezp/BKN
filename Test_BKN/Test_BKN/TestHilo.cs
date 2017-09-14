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

namespace Test_BKN {
    public partial class TestHilo : Form {
        public TestHilo() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Invoke((MethodInvoker)async delegate {
                for (int i = 0; i <= 5; i++) {
                    label1.Text = ">--> " + i;
                    await Task.Delay(1000);
                }
            });
            
        }
        
    }
}
