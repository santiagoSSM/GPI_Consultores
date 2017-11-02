using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.Models
{
    public class PickersModel
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
