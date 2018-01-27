using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_034_PostageCalc_final
    // ========  requirements  ========
    // width height req'd - length is not
    // three types of shipping speed
    // width + height and radio button produces a result
    //
    // rates determined as follows:
    // Ground = .15 multiplier
    // Air = .25 multiplier
    // Overnight = .45 multiplier
    // width * height (opt * length) = multiplier
    // must use Methods - one thing per method
    // estimate 3-4 -- or more methods



{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }





        // Get length:
        //default length to 1, or valid input
        public void getLength()
        {   
            double length = 1.0;
            if (!Double.TryParse(lengthTextBox.Text, out length))
                return;
        }


        // Get height and test for valid entry
        public void getHeight()
        {
            if (heightTextBox.Text.Trim().Length == 0)
                return;
            double height = 0.0;
            if (!Double.TryParse(heightTextBox.Text, out height))
                return;
        }


        // Get width and test for valid entry
        public void getWidth()
        {
            if (widthTextBox.Text.Trim().Length == 0)
                return;
            double width = 0.0;
            if (!Double.TryParse(widthTextBox.Text, out width))
                return;
        }



        // Calculate area (width*height*length)
        public void calculateArea(double width, double height, double length)
        {  double totalArea = length * width * height;  }


        // Use radio buttons to designate specific mulitplier  
        public void multiplierRadio(double multiplier)
        {
            if (groundRadioButton.Checked)
                multiplier = 0.15;
            else if (airRadioButton.Checked)
                multiplier = 0.25;
            else if (nextDayRadioButton.Checked)
                multiplier = 0.45;
            else
                return;
        }


        double getCost = multiplier * totalArea;

        resultLabel.Text = String.Format("Your parcel will cost {0:N2} to ship.",
                getCost);


        // Print out result
        // String.Format()      




    }       
}