using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserMgtAndCURDOpr.Interfaces
{

    public interface IProjects
    {
         string ProjectId { get; set; }
         string ProjectName { get; set; }
         string ClientName { get; set; }
         string ProjDescription { get; set; }
    }

}