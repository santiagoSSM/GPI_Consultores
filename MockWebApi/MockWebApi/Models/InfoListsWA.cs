using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace MockWebApi.Models
{
    public static class InfoListsWA
    {
        private static ObservableCollection<UserPassWA> listUserPass = new ObservableCollection<UserPassWA>()
        {
            new UserPassWA()
            {
                IdUser = 0,
                NameUser = "user",
                PassUser = "pass"
            },

            new UserPassWA()
            {
                IdUser = 1,
                NameUser = "user1",
                PassUser = "pass"
            },

            new UserPassWA()
            {
                IdUser = 2,
                NameUser = "user3",
                PassUser = "pass"
            },

            new UserPassWA()
            {
                IdUser = 3,
                NameUser = "user4",
                PassUser = "pass"
            },

            new UserPassWA()
            {
                IdUser = 4,
                NameUser = "user5",
                PassUser = "pass"
            },

            new UserPassWA()
            {
                IdUser = 5,
                NameUser = "user6",
                PassUser = "pass"
            },

            new UserPassWA()
            {
                IdUser = 6,
                NameUser = "user7",
                PassUser = "pass"
            },

            new UserPassWA()
            {
                IdUser = 7,
                NameUser = "user8",
                PassUser = "pass"
            }
        };
        private static ObservableCollection<PickersWA> listCategory = new ObservableCollection<PickersWA>()
        {
            new PickersWA()
            {
                IdValue = 0,
                TextValue = "Programación"
            },

            new PickersWA()
            {
                IdValue = 1,
                TextValue = "Base de Datos"
            },

            new PickersWA()
            {
                IdValue = 2,
                TextValue = "Diseño"
            },

            new PickersWA()
            {
                IdValue = 3,
                TextValue = "Otro"
            }
        };
        private static ObservableCollection<PickersWA> listPriority = new ObservableCollection<PickersWA>()
        {
            new PickersWA()
            {
                IdValue = 0,
                TextValue = "Crítica"
            },

            new PickersWA()
            {
                IdValue = 1,
                TextValue = "Media"
            },

            new PickersWA()
            {
                IdValue = 2,
                TextValue = "Baja"
            }
        };
        private static ObservableCollection<PickersWA> listRecurrence = new ObservableCollection<PickersWA>()
        {
            new PickersWA()
            {
                IdValue = 0,
                TextValue = "Rec"
            }
        };
        private static ObservableCollection<PickersWA> listFinalDate = new ObservableCollection<PickersWA>()
        {
            new PickersWA()
            {
                IdValue = 0,
                TextValue = "FinalDate"
            }
        };
        private static ObservableCollection<TaskWA> listTask = new ObservableCollection<TaskWA>()
        {
            new TaskWA()
            {
                //No Task Attributes
                IdUser = 0,
                IsDraft = false,

                //Task

                IdTask = 0,
                TextIssue = "tarea0",
                TextDescription = "descripcion",
                IdRespUser = 0,
                IdCopyUser = 1,
                IdCategory = 0,
                IsAprob = true,
                IdPriority = 1,

                //Recurrence

                IdRecu = 0,
                BeforeDays = 1,
                IsCancelRecu = false,

                //Daily,Montly,Annual Vector info

                SelectTimeOfRecu = false,
                TimeOfRecu0 = 0,
                TimeOfRecu1 = 0,
                TimeOfRecu2 = 0,

                //Final Date

                IdFinalDate = 0,
                NumRecu = 0,
                ContractExp = new DateTime(2010, 8, 10)
            },

            new TaskWA()
            {
                //No Task Attributes
                IdUser = 0,
                IsDraft = false,

                //Task

                IdTask = 1,
                TextIssue = "tarea1",
                TextDescription = "descripcion",
                IdRespUser = 0,
                IdCopyUser = 1,
                IdCategory = 0,
                IsAprob = true,
                IdPriority = 1,

                //Recurrence

                IdRecu = 0,
                BeforeDays = 1,
                IsCancelRecu = false,

                //Daily,Montly,Annual Vector info

                SelectTimeOfRecu = false,
                TimeOfRecu0 = 0,
                TimeOfRecu1 = 0,
                TimeOfRecu2 = 0,

                //Final Date

                IdFinalDate = 0,
                NumRecu = 0,
                ContractExp = new DateTime(2010, 8, 10)
            },

            new TaskWA()
            {
                //No Task Attributes
                IdUser = 0,
                IsDraft = false,

                //Task

                IdTask = 2,
                TextIssue = "tarea2",
                TextDescription = "descripcion",
                IdRespUser = 0,
                IdCopyUser = 1,
                IdCategory = 0,
                IsAprob = true,
                IdPriority = 1,

                //Recurrence

                IdRecu = 0,
                BeforeDays = 1,
                IsCancelRecu = false,

                //Daily,Montly,Annual Vector info

                SelectTimeOfRecu = false,
                TimeOfRecu0 = 0,
                TimeOfRecu1 = 0,
                TimeOfRecu2 = 0,

                //Final Date

                IdFinalDate = 0,
                NumRecu = 0,
                ContractExp = new DateTime(2010, 8, 10)
            }
        };

        public static ObservableCollection<UserPassWA> ListUserPass
        {
            get
            {
                return listUserPass;
            }

            set
            {
                listUserPass = value;
            }
        }

        public static ObservableCollection<PickersWA> ListCategory
        {
            get
            {
                return listCategory;
            }

            set
            {
                listCategory = value;
            }
        }

        public static ObservableCollection<PickersWA> ListPriority
        {
            get
            {
                return listPriority;
            }

            set
            {
                listPriority = value;
            }
        }

        public static ObservableCollection<PickersWA> ListRecurrence
        {
            get
            {
                return listRecurrence;
            }

            set
            {
                listRecurrence = value;
            }
        }

        public static ObservableCollection<PickersWA> ListFinalDate
        {
            get
            {
                return listFinalDate;
            }

            set
            {
                listFinalDate = value;
            }
        }

        public static ObservableCollection<TaskWA> ListTask
        {
            get
            {
                return listTask;
            }

            set
            {
                listTask = value;
            }
        }

        public static bool IsActive(int idTask)
        {
            var temp = listTask.FirstOrDefault(x => x.IdTask == idTask);

            if (temp != null)
            {
                //Todo agregar codigo para determinar tarea activa;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}