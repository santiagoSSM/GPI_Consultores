﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models
{
    public class UserWA
    {
        protected int idUser;
        protected string nameUser;

        public int IdUser
        {
            get
            {
                return idUser;
            }

            set
            {
                idUser = value;
            }
        }

        public string NameUser
        {
            get
            {
                return nameUser;
            }

            set
            {
                nameUser = value;
            }
        }
    }
}