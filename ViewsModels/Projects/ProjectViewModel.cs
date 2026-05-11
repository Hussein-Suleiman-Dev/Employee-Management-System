using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Windows_Form1.ViewsModels.Projects
{
    public class ProjectViewModel
    {
       public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public int StatusID { get; set; }
        public string StatusName { get; set; }

        public bool IsActive { get; set; }

       
        public List<int> RolesIDs { get; set; } = new List<int>();

        public List<string> RolesNames { get; set; } = new List<string>();

        
        public string DisplayStatus
        {
            get => IsActive ? "Active" : "Inactive";
        }

    }
}
