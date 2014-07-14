using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardX.Utils
{
    public class Access
    {
        public static bool HasAccess(int actionID)
        {
            HardX.Models.User theUser = new HardX.Models.User();
            List<HardX.Models.User> theUserList = new List<Models.User>();
            if (HttpContext.Current.User.Identity.Name == "")
            {
                return false;
            }
            theUserList = (List<HardX.Models.User>)theUser.GetAll("UPPER(LOGIN) = '" + HttpContext.Current.User.Identity.Name.ToUpper() + "'");
            if (theUserList.Count == 1)
            {
                return true;
            }
            /*
            foreach (var theAction in theUserList[0].Role.Actions)
            {
                if (actionID == theAction.Id)
                {
                    return true;
                }
            }
             * */
            return false;
        }
    }
}