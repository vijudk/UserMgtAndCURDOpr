using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMgtAndCURDOpr.Interfaces;

namespace UserMgtAndCURDOpr.Models
{
    public class Projects : IProjects
    {
        
            public string ProjectId { get; set; }
            public string ProjectName { get; set; }
            public string ClientName { get; set; }
            public string ProjDescription { get; set; }
       
    }
}