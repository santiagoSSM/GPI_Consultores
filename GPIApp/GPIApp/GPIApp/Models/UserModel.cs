﻿namespace GPIApp.Models
{
    public class UserModel
    {
        protected int idUser = -1;
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