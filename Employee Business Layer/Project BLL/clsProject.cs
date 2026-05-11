using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Business_Layer.Project_BLL
{
    public class clsProject
    {
       public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int StatusID { get; set; }
     
        public bool isActive { get; set; }
        public List<int> RolesIDs { get; set; } = new List<int>();
    public List<string> RolesNames {  get; set; } = new List<string>();

}
}
