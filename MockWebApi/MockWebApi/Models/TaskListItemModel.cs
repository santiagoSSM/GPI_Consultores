using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models
{
    public class TaskListItemModel
    {
        public int IdTask { get; set; }
        public string UserIssue { get; set; }
        public string UserPriority { get; set; }
        public bool ActiveTask { get; set; }
    }
}