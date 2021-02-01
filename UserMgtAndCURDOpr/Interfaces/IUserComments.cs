using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserMgtAndCURDOpr.Interfaces
{
    public class IUserComments
    {
         string UserCommentsId { get; set; }
         string UserId { get; set; }
         string ProjectId { get; set; }
         string UserCommentsData { get; set; }
    }
}