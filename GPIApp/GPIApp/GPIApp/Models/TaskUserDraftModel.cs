namespace GPIApp.Models
{
    public class TaskUserDraftModel : TaskStringModel
    {
        private int idUser;
        private bool isDraft;

        //Properties

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

        public bool IsDraft
        {
            get
            {
                return isDraft;
            }

            set
            {
                isDraft = value;
            }
        }
    }
}