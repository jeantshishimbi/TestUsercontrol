using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.UserControls;

namespace TestProject
{
    public partial class Form1 : Form
    {
        private UserControl1 uc1;
        private UserControl2 uc2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            uc1 = new UserControl1();
            uc2 = new UserControl2();
            this.Controls.Add(uc1);
            uc1.Dock = DockStyle.Fill;
            uc1.GetPrimaryKey += Usercontrol1_GetPrimaryKey;     //we register this event which is used to add usercontrol2 and remove usercontrol1 in the form      
            uc2.BackToUsercontrol1 += Usercontrol2_BackToUsercontrol1; //we register this event which is used to go back to usercontrol1
        }

        private void Usercontrol1_GetPrimaryKey(object sender, PassPrimaryKeyEventArgs e)
        {            
            uc2 = new UserControl2();
            uc2.PkEmpployee = e.PK; // pass value to property PkEmpployee
            this.Controls.Add(uc2);
            uc2.Dock = DockStyle.Fill;
            this.Controls.Remove(uc1);  
        }

        private void Usercontrol2_BackToUsercontrol1(object sender, EventArgs e)
        {
            uc1 = new UserControl1();
            uc2 = new UserControl2();           
            this.Controls.Add(uc1);
            uc1.Dock = DockStyle.Fill;
            this.Controls.Remove(uc2);
        }

    }
}
