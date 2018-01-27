using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_034_PostageCalc_final


{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            resultLabel.Text = "";
            lengthTextBox.Text = "1";
        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        { calculatePostage(); }
        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        { calculatePostage(); }
        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        { calculatePostage(); }

        protected void widthTextBox_CheckedChanged(object sender, EventArgs e)
        { calculatePostage(); }
        protected void heightTextBox_CheckedChanged(object sender, EventArgs e)
        { calculatePostage(); }
        protected void lengthTextBox_CheckedChanged(object sender, EventArgs e)
        { calculatePostage(); }


        private void calculatePostage()
        {
            if (widthTextBox.Text.Trim().Length == 0)
                return;
            double width = 0.0;
            if (!Double.TryParse(widthTextBox.Text, out width))
                return;

            if (heightTextBox.Text.Trim().Length == 0)
                return;
            double height = 0.0;
            if (!Double.TryParse(heightTextBox.Text, out height))
                return;

            double length = 0.0;
            //if (lengthTextBox.Text.Trim().Length == 0)
             //   return length = 1;
            if (!Double.TryParse(lengthTextBox.Text, out length))
                return;
            else if (lengthTextBox.Text.Trim().Length == 0)
                length = 1.0;



            double postage = 0.0;

            if (groundRadioButton.Checked) postage = (width * height * length) * 0.15;
            else if (airRadioButton.Checked) postage = (width * height * length) * 0.25;
            else if (nextDayRadioButton.Checked) postage = (width * height * length) * 0.45;


resultLabel.Text = String.Format("The postage for this package is $" 
                + "{0:N2}", postage);
                
                
        }



    }
}