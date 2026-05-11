using Employee_Business_Layer;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Windows_Form1.ViewsModels.Projects;

namespace Test_Windows_Form1
{
    public partial class Form1 : Form,IEmployeeView
    {
        private EmployeePresenter _presenter;
        public Form1()
        {
            InitializeComponent();
            _presenter = new EmployeePresenter(this);
        }

        public void ShowEmployees(List<ProjectViewModel>employees)
        { 
        dgvGetAll.DataSource = employees;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _presenter.LoadEmployee();
        }

        private void dgvGetAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
