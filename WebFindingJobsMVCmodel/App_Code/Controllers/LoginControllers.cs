using System.Data;
using Models.Objects;

namespace Controllers
{
    /// <summary>
    /// Summary description for LoginControllers
    /// </summary>
    public class LoginControllers:GenaralController
    {
        public LoginControllers()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        protected bool CheckSessionLogin()
        {
            var session = (User)Session["Users"];
            if (session == null)
            {
                return false;
            }
            return true;
        }
        protected bool CheckSessionAdminLogin()
        {
            var session = (User)Session["Admin"];
            if (session == null)
            {
                return false;
            }
            return true;
        }
      
       
    }
}