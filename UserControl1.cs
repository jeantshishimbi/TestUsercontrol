using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Database;
namespace TestProject.UserControls
{
    public partial class UserControl1 : UserControl
    {
        public event EventHandler<PassPrimaryKeyEventArgs> GetPrimaryKey; //this event allow to get primary key value of current select row
                                                                          //and add usercontrol2, remove usercontrol1 in the form1
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            employeeTableAdapter.Fill(this.dataSet11.Employee); //load data  
        }
        
        void OnGetPrimaryKey (PassPrimaryKeyEventArgs e)
        {
            EventHandler<PassPrimaryKeyEventArgs> handler = GetPrimaryKey;
            if (handler != null)
                handler(this, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PassPrimaryKeyEventArgs args = new PassPrimaryKeyEventArgs();
            string id = dataGridView1.CurrentRow.Cells["Idcol"].Value.ToString(); //get the value "id" of select row
            //MessageBox.Show(id); //>>>test 
            args.PK = int.Parse(id);
            OnGetPrimaryKey(args);
        }
    }
}
