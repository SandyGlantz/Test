using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                // first three will require a for statement


            // 1.  Reverse your name
            string name = "Bob Tabor";
            // In my case, the result would be:
            // robaT boB



            // 2.  Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke




            // 3. Use the sequence to create ascii art:
            // 14 characters per line
            // *****luke***** (5, 4, 5)
            // *****leia***** (5, 4, 5)
            // *****han****** (5, 3, 6)
            // **Chewbacca*** (2, 9, 3)





            // 4. Solve this puzzle:

            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";

            // Once you fix it with string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.

        }
    }
}