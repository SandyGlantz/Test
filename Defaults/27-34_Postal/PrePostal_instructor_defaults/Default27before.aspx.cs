using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_027
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random random = new Random();

            int heroHealth = 30;
            int monsterHealth = 30;

            string result = "";

            // Hero gets bonus first attack 
            monsterHealth -= random.Next(1, 100);

            int round = 0;
            result += "<br />Round: " + round;
            result += String.Format("<br />Hero attacks first, leaving monster with {0} health.", 
                monsterHealth);


            // Need battle logic here!


            if (heroHealth > 0)
            {
                result += "<br />Hero wins!";
            }
            else
            {
                result += "<br /> Monster wins!";
            }


            resultLabel.Text = result;

        }
    }
}