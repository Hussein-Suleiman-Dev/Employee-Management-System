using System;
using System.Linq;
using Employee_Business_Layer;
using Employee_Business_Layer.Project_BLL;
using Presentation.ViewModels;
using Test_Windows_Form1.ViewsModels.Projects;

namespace Test_Windows_Form1
{
    public class EmployeePresenter
    {
        private readonly IEmployeeView _view;

        public EmployeePresenter(IEmployeeView view)
        {
            _view = view;
        }

        public void LoadEmployee()
        {
            var employees = Project_Services.GetAllProject();

            var result = clsProjectMapper.ToViewList(employees);

            _view.ShowEmployees(result);
        }

    }
}