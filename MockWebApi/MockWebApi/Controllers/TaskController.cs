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
                    ListUser = new ObservableCollection<string>(),
                    ListCategory = new ObservableCollection<string>(),
                    ListPriority = new ObservableCollection<string>(),
                    ListRecu = new ObservableCollection<string>(),
                    ListFinalDate = new ObservableCollection<string>()
                };

                #region foreach sequences
                foreach (UserPassWA element in InfoListsWA.ListUserPass)
                {
                    tmpTaskPickers.ListUser.Add(element.NameUser);
                }

                foreach (PickersWA element in InfoListsWA.ListCategory)
                {
                    tmpTaskPickers.ListCategory.Add(element.TextValue);
                }

                foreach (PickersWA element in InfoListsWA.ListPriority)
                {
                    tmpTaskPickers.ListPriority.Add(element.TextValue);
                }

                foreach (PickersWA element in InfoListsWA.ListRecurrence)
                {
                    tmpTaskPickers.ListRecu.Add(element.TextValue);
                }

                foreach (PickersWA element in InfoListsWA.ListFinalDate)
                {
                    tmpTaskPickers.ListFinalDate.Add(element.TextValue);
                }
                #endregion

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

                        TextRecu = InfoListsWA.ListRecurrence.FirstOrDefault(x => x.IdValue == temp.IdRecu).TextValue,
                        BeforeDays = temp.BeforeDays,
                        IsCancelRecu = false,

                        //Daily,Montly,Annual Vector info

                        SelectTimeOfRecu = temp.SelectTimeOfRecu,
                        TimeOfRecu0 = temp.TimeOfRecu0,
                        TimeOfRecu1 = temp.TimeOfRecu1,
                        TimeOfRecu2 = temp.TimeOfRecu2,

                        //Final Date

                        TextFinalDate = InfoListsWA.ListFinalDate.FirstOrDefault(x => x.IdValue == temp.IdFinalDate).TextValue,
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
                        ListUser = new ObservableCollection<string>(),
                        ListCategory = new ObservableCollection<string>(),
                        ListPriority = new ObservableCollection<string>(),
                        ListRecu = new ObservableCollection<string>(),
                        ListFinalDate = new ObservableCollection<string>()
                    };

                    #region foreach sequences
                    foreach (UserPassWA element in InfoListsWA.ListUserPass)
                    {
                        tmpTaskPickers.ListUser.Add(element.NameUser);
                    }

                    foreach (PickersWA element in InfoListsWA.ListCategory)
                    {
                        tmpTaskPickers.ListCategory.Add(element.TextValue);
                    }

                    foreach (PickersWA element in InfoListsWA.ListPriority)
                    {
                        tmpTaskPickers.ListPriority.Add(element.TextValue);
                    }

                    foreach (PickersWA element in InfoListsWA.ListRecurrence)
                    {
                        tmpTaskPickers.ListRecu.Add(element.TextValue);
                    }

                    foreach (PickersWA element in InfoListsWA.ListFinalDate)
                    {
                        tmpTaskPickers.ListFinalDate.Add(element.TextValue);
                    }
                    #endregion

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

                        TextRecu = InfoListsWA.ListRecurrence.FirstOrDefault(x => x.IdValue == temp.IdRecu).TextValue,
                        BeforeDays = temp.BeforeDays,
                        IsCancelRecu = false,

                        //Daily,Montly,Annual Vector info

                        SelectTimeOfRecu = temp.SelectTimeOfRecu,
                        TimeOfRecu0 = temp.TimeOfRecu0,
                        TimeOfRecu1 = temp.TimeOfRecu1,
                        TimeOfRecu2 = temp.TimeOfRecu2,

                        //Final Date

                        TextFinalDate = InfoListsWA.ListFinalDate.FirstOrDefault(x => x.IdValue == temp.IdFinalDate).TextValue,
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
        public IHttpActionResult Post([FromBody]TaskUserDraftWA value)
        {
            try
            {
                var temp = InfoListsWA.ListTask.FirstOrDefault(x => x.IdTask == value.IdTask);

                if (value.IdTask == -1 || temp == null)
                {
                    //New Task

                    InfoListsWA.ListTask.Add(new TaskWA()
                    {
                        //NoTaskAttributes

                        IdUser = value.IdUser,
                        IsDraft = value.IsDraft,

                        //Task

                        IdTask = InfoListsWA.ListTask.Count(),
                        TextIssue = value.TextIssue,
                        TextDescription = value.TextDescription,
                        IdRespUser = InfoListsWA.ListUserPass.FirstOrDefault(x => x.NameUser == value.NameRespUser).IdUser,
                        IdCopyUser = InfoListsWA.ListUserPass.FirstOrDefault(x => x.NameUser == value.NameCopyUser).IdUser,
                        IdCategory = InfoListsWA.ListCategory.FirstOrDefault(x => x.TextValue == value.TextCategory).IdValue,
                        IsAprob = value.IsAprob,
                        IdPriority = InfoListsWA.ListPriority.FirstOrDefault(x => x.TextValue == value.TextPriority).IdValue,

                        //Recurrence

                        IdRecu = InfoListsWA.ListRecurrence.FirstOrDefault(x => x.TextValue == value.TextRecu).IdValue,
                        BeforeDays = value.BeforeDays,
                        IsCancelRecu = false,

                        //Daily,Montly,Annual Vector info

                        SelectTimeOfRecu = value.SelectTimeOfRecu,
                        TimeOfRecu0 = value.TimeOfRecu0,
                        TimeOfRecu1 = value.TimeOfRecu1,
                        TimeOfRecu2 = value.TimeOfRecu2,

                        //Final Date

                        IdFinalDate = InfoListsWA.ListFinalDate.FirstOrDefault(x => x.TextValue == value.TextFinalDate).IdValue,
                        NumRecu = value.NumRecu,
                        ContractExp = value.ContractExp
                    });

                    return Ok();
                }
                else
                {
                    //Edit Task

                    //NoTaskAttributes

                    temp.IdUser = value.IdUser;
                    temp.IsDraft = value.IsDraft;

                    //Task

                    temp.IdTask = InfoListsWA.ListTask.Count();
                    temp.TextIssue = value.TextIssue;
                    temp.TextDescription = value.TextDescription;
                    temp.IdRespUser = InfoListsWA.ListUserPass.FirstOrDefault(x => x.NameUser == value.NameRespUser).IdUser;
                    temp.IdCopyUser = InfoListsWA.ListUserPass.FirstOrDefault(x => x.NameUser == value.NameCopyUser).IdUser;
                    temp.IdCategory = InfoListsWA.ListCategory.FirstOrDefault(x => x.TextValue == value.TextCategory).IdValue;
                    temp.IsAprob = value.IsAprob;
                    temp.IdPriority = InfoListsWA.ListPriority.FirstOrDefault(x => x.TextValue == value.TextPriority).IdValue;

                    //Recurrence

                    temp.IdRecu = InfoListsWA.ListRecurrence.FirstOrDefault(x => x.TextValue == value.TextRecu).IdValue;
                    temp.BeforeDays = value.BeforeDays;
                    temp.IsCancelRecu = false;

                    //Daily;Montly;Annual Vector info

                    temp.SelectTimeOfRecu = value.SelectTimeOfRecu;
                    temp.TimeOfRecu0 = value.TimeOfRecu0;
                    temp.TimeOfRecu1 = value.TimeOfRecu1;
                    temp.TimeOfRecu2 = value.TimeOfRecu2;

                    //Final Date

                    temp.IdFinalDate = InfoListsWA.ListFinalDate.FirstOrDefault(x => x.TextValue == value.TextFinalDate).IdValue;
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
