using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockWebApi.Models
{
    public class PickersWA
    {
        protected int idValue;
        protected string textValue;

        public int IdValue
        {
            get
            {
                return idValue;
            }

            set
            {
                idValue = value;
            }
        }

        public string TextValue
        {
            get
            {
                return textValue;
            }

            set
            {
                textValue = value;
            }
        }
    }
}