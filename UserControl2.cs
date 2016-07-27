using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject.UserControls
{
    public partial class UserControl2 : UserControl
    {
        public event EventHandler BackToUsercontrol1;
        
        private int pk;
        public int PkEmpployee
        {
            get { return pk; }
            set { pk = value; }
        }

        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            employeeTableAdapter.FillById(this.dataSet1.Employee, PkEmpployee); // fill the data by id value which is set by event "GetPrimaryKey"
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.employeeBindingSource.EndEdit();
            //this.employeeBindingSource.CancelEdit();

            if (BackToUsercontrol1 != null)
                BackToUsercontrol1(sender, e);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);
        }       
    }
}
