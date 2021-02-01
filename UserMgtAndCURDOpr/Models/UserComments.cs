using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMgtAndCURDOpr.Interfaces;

namespace UserMgtAndCURDOpr.Models
{
    public class UserComments : IUserComments
    {
        public string UserCommentsId { get; set; }
        public string UserId { get; set; }
        public string ProjectId { get; set; }
        public string UserCommentsData { get; set; }

    }
}