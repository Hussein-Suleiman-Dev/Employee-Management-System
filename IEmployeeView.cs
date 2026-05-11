using Employee_Business_Layer;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Windows_Form1.ViewsModels.Projects;
namespace Test_Windows_Form1
{
    public interface IEmployeeView
    {

        void ShowEmployees(List<ProjectViewModel>employees);

    }
}
