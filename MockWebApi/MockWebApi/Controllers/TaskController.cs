using MockWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class TaskController : ApiController
    {
        [HttpGet]
        [ActionName("GetTP")]
        public TaskPickersWA GetTaskPickers()
        {
            try
            {
                var tmpTaskPickers = new TaskPickersWA()
                {
                    ListUser = new ObservableCollection<UserWA>(),
                    ListCategory = InfoListsWA.ListCategory,
                    ListPriority = InfoListsWA.ListPriority,
                    ListRecu = InfoListsWA.ListRecu
                };

                foreach (UserPassWA element in InfoListsWA.ListUserPass)
                {
                    tmpTaskPickers.ListUser.Add(new UserWA
                    {
                        IdUser = element.IdUser,
                        NameUser = element.NameUser
                    }
                    );
                }

                return tmpTaskPickers;
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [ActionName("GetST")]
        public TaskSeeWA GetSeeTask(int idTask)
        {
            try
            {
                var temp = InfoListsWA.ListTask.FirstOrDefault(x => x.IdTask == idTask);

                if (temp != null)
                {
                    var tmp = new TaskSeeWA()
                    {
                        IdTask = temp.IdTask,
                        TextIssue = temp.TextIssue,
                        TextDescription = temp.TextDescription,
                        NameRespUser = InfoListsWA.ListUserPass.FirstOrDefault(x => x.IdUser == temp.IdRespUser).NameUser,
                        NameCopyUser = InfoListsWA.ListUserPass.FirstOrDefault(x => x.IdUser == temp.IdCopyUser).NameUser,
                        TextCategory = InfoListsWA.ListCategory.FirstOrDefault(x => x.IdValue == temp.IdCategory).TextValue,
                        IsAprob = temp.IsAprob,
                        TextPriority = InfoListsWA.ListPriority.FirstOrDefault(x => x.IdValue == temp.IdPriority).TextValue,

                        //Recurrence

                        TextRecu = InfoListsWA.ListRecu.FirstOrDefault(x => x.IdValue == temp.IdRecu).TextValue,
                        BeforeDays = temp.BeforeDays,
                        IsCancelRecu = false,

                        //Daily,Montly,Annual Vector info

                        SelectTimeOfRecu = temp.SelectTimeOfRecu,
                        TimeOfRecu0 = temp.TimeOfRecu0,
                        TimeOfRecu1 = temp.TimeOfRecu1,
                        TimeOfRecu2 = temp.TimeOfRecu2,

                        //Final Date

                        FinalDate = temp.FinalDate,
                        NumRecu = temp.NumRecu,
                        ContractExp = temp.ContractExp,

                        IsActive = InfoListsWA.IsActive(temp.IdTask)
                    };

                    return tmp;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [ActionName("GetET")]
        public TaskBindingWA GetEditTask(int idTask)
        {
            try
            {
                var temp = InfoListsWA.ListTask.FirstOrDefault(x => x.IdTask == idTask);

                if (temp != null)
                {
                    var tmpTaskPickers = new TaskPickersWA()
                    {
                        ListUser = new ObservableCollection<UserWA>(),
                        ListCategory = InfoListsWA.ListCategory,
                        ListPriority = InfoListsWA.ListPriority,
                        ListRecu = InfoListsWA.ListRecu
                    };

                    foreach (UserPassWA element in InfoListsWA.ListUserPass)
                    {
                        tmpTaskPickers.ListUser.Add(new UserWA
                        {
                            IdUser = element.IdUser,
                            NameUser = element.NameUser
                        }
                        );
                    }

                    return new TaskBindingWA()
                    {
                        TaskPickers = tmpTaskPickers,

                        //NoTaskAttributes

                        IdUser = temp.IdUser,
                        IsDraft = temp.IsDraft,

                        //Task

                        IdTask = temp.IdTask,
                        TextIssue = temp.TextIssue,
                        TextDescription = temp.TextDescription,
                        NameRespUser = InfoListsWA.ListUserPass.FirstOrDefault(x => x.IdUser == temp.IdRespUser).NameUser,
                        NameCopyUser = InfoListsWA.ListUserPass.FirstOrDefault(x => x.IdUser == temp.IdCopyUser).NameUser,
                        TextCategory = InfoListsWA.ListCategory.FirstOrDefault(x => x.IdValue == temp.IdCategory).TextValue,
                        IsAprob = temp.IsAprob,
                        TextPriority = InfoListsWA.ListPriority.FirstOrDefault(x => x.IdValue == temp.IdPriority).TextValue,

                        //Recurrence

                        TextRecu = InfoListsWA.ListRecu.FirstOrDefault(x => x.IdValue == temp.IdRecu).TextValue,
                        BeforeDays = temp.BeforeDays,
                        IsCancelRecu = false,

                        //Daily,Montly,Annual Vector info

                        SelectTimeOfRecu = temp.SelectTimeOfRecu,
                        TimeOfRecu0 = temp.TimeOfRecu0,
                        TimeOfRecu1 = temp.TimeOfRecu1,
                        TimeOfRecu2 = temp.TimeOfRecu2,

                        //Final Date

                        FinalDate = temp.FinalDate,
                        NumRecu = temp.NumRecu,
                        ContractExp = temp.ContractExp
                    };
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        [HttpPut]
        [ActionName("Put")]
        public IEnumerable<TaskListItemWA> PutTaskListItem(int idUser)
        {
            try
            {
                ObservableCollection<TaskListItemWA> temp = new ObservableCollection<TaskListItemWA>();

                foreach (TaskWA element in InfoListsWA.ListTask)
                {
                    if (element.IdUser == idUser)
                    {
                        temp.Add(new TaskListItemWA
                        {
                            IdTask = element.IdTask,
                            TextIssue = element.TextIssue,
                            IdPriority = element.IdPriority,
                            IsActive = InfoListsWA.IsActive(element.IdTask)
                        });
                    }
                }

                return temp;
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [ActionName("Post")]
        public IHttpActionResult Post([FromBody]TaskWA value)
        {
            try
            {
                var temp = InfoListsWA.ListTask.FirstOrDefault(x => x.IdTask == value.IdTask);

                if (value.IdTask == -1 || temp == null)
                {
                    //New Task

                    value.IdTask = InfoListsWA.ListTask.Count();
                    InfoListsWA.ListTask.Add(value);

                    return Ok();
                }
                else
                {
                    //Edit Task

                    //NoTaskAttributes

                    temp.IdUser = value.IdUser;
                    temp.IsDraft = value.IsDraft;

                    //Task

                    temp.IdTask = value.IdTask;
                    temp.TextIssue = value.TextIssue;
                    temp.TextDescription = value.TextDescription;
                    temp.IdRespUser = value.IdRespUser;
                    temp.IdCopyUser = value.IdCopyUser;
                    temp.IdCategory = value.IdCategory;
                    temp.IsAprob = value.IsAprob;
                    temp.IdPriority = value.IdPriority;

                    //Recurrence

                    temp.IdRecu = value.IdRecu;
                    temp.BeforeDays = value.BeforeDays;
                    temp.IsCancelRecu = false;

                    //Daily;Montly;Annual Vector info

                    temp.SelectTimeOfRecu = value.SelectTimeOfRecu;
                    temp.TimeOfRecu0 = value.TimeOfRecu0;
                    temp.TimeOfRecu1 = value.TimeOfRecu1;
                    temp.TimeOfRecu2 = value.TimeOfRecu2;

                    //Final Date

                    temp.FinalDate = value.FinalDate;
                    temp.NumRecu = value.NumRecu;
                    temp.ContractExp = value.ContractExp;

                    return Ok();
                }
            }
            catch
            {
                return InternalServerError();
            }

            
        }
    }
}
