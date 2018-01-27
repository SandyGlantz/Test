using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_034b_MegaChallenge_Casino_final
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
//  ============   priming the pump ... err...page ...  ============   
            //betResultLabel.Text = "";
            displayRandomImages();
            playerBalanceLabel.Text = "100.00";
            /*
            if (!Page.IsPostBack)
            {
                ViewState.Add("")
            }
            */
            
        }




//  ============   setting primary variables   ============   
        double betAmount = 0.0;
        double betResult = 0.0;

        // other variables ... does this even need to be here??
        // double startingPlayerBalance = 0.0; // or should this be 100.00??


            

//  ============   Image array for random selection   ============  
        public void displayRandomImages()
        {   
            string [] slotImages = new string[12]  
            { "Images/Watermelon.png","Images/Strawberry.png", "Images/Seven.png",
              "Images/Plum.png", "Images/Orange.png", "Images/Lemon.png",
              "Images/HorseShoe.png", "Images/Diamond.png", "Images/Clover.png",
              "Images/Cherry.png", "Images/Bell.png", "Images/Bar.png" };

            // This isn't returning duplicates ... so left inside method
            Random getRandomSlotImage = new Random();
            leftImage.ImageUrl = slotImages[getRandomSlotImage.Next(0, 12)];
            middleImage.ImageUrl = slotImages[getRandomSlotImage.Next(0, 12)];
            rightImage.ImageUrl = slotImages[getRandomSlotImage.Next(0, 12)];
        }






//  ============   clear bet result label - makes sure an old result isn't still on screen   ============ 
        private void clearBetResultLabel()
        {       betResultLabel.Text = " "; }






//  ============   pull out bet amount, or kickout if no bet placed, or bad input   ============   
        public void getBetAmount()
        {
            // betAmount is a global var
            // is that why the default line below isn't working??
            if (amountBetTextBox.Text.Trim().Length == 0)
            {
                betResultLabel.Text = "Please place a bet amount.";
                return;
            }


            else if (!Double.TryParse(amountBetTextBox.Text, out betAmount))
            {
                checkForBars();
                return;
            }
              

            //else
                //betResultLabel.Text = "Please place a bet amount using numbers.";
                
        }






//  ============   start with checking for bar losses   ============   
        public void checkForBars()
        {  
            if (leftImage.ImageUrl == "Images/Bar.png" ||
                middleImage.ImageUrl == "Images/Bar.png" ||
                rightImage.ImageUrl == "Images/Bar.png")


            {
                betResult = betAmount;
                betResultLabel.Text = String.Format("Sorry Charlie, there's a bar." +
                    " You lost ${0:N2}", betAmount);
                betResult = betResult * (-1);
            }

            //else
              //  determineWinnings();  
        }






//   ============   determine winnings   ============   
        public void determineWinnings()
        {
            //  UGH.  WAY too big/long. NOT DRY either ...


            //Three(3) Cherries quadruples your bet!
            if (leftImage.ImageUrl == "Images/Cherry.png" &&
                middleImage.ImageUrl == "Images/Cherry.png" &&
                rightImage.ImageUrl == "Images/Cherry.png")
            {
                betResult = betAmount * 4;
                winnerLabelInfo();
                playerBalance();
            }

            //Two(2) Cherries and your bet is tripled!
            else if (leftImage.ImageUrl == "Images/Cherry.png" &&
                middleImage.ImageUrl == "Images/Cherry.png" ||
                leftImage.ImageUrl == "Images/Cherry.png" &&
                rightImage.ImageUrl == "Images/Cherry.png" ||
                middleImage.ImageUrl == "Images/Cherry.png" &&
                rightImage.ImageUrl == "Images/Cherry.png")
            {
                betResult = betAmount * 3;
                winnerLabelInfo();
                playerBalance();
            }

            //One (1) Cherry gets your bet doubled
            else if (leftImage.ImageUrl == "Images/Cherry.png" ||
                middleImage.ImageUrl == "Images/Cherry.png" ||
                rightImage.ImageUrl == "Images/Cherry.png")
            {
                betResult = betAmount * 2;
                winnerLabelInfo();
                playerBalance();
            }

            //Get three(3) "7's" in a row -and JACKPOT!You win 100 times the amount bet.
            else if (leftImage.ImageUrl == "Images/Seven.png" &&
                middleImage.ImageUrl == "Images/Seven.png" &&
                rightImage.ImageUrl == "Images/Seven.png")
            {
                betResult = betAmount * 100;
                winnerLabelInfo();
                playerBalance();
            }


            else
                determineLosses();                         
        }





        private void winnerLabelInfo()
        {
            betResultLabel.Text = String.Format("Way to go! You bet ${0:N2}," +
                  " and won {1:N2}!", betAmount, betResult);
        }





//  ============   copy for general losses   ============   
        public void determineLosses()
        {
            betResult = betAmount;
            betResultLabel.Text = String.Format("Nothing this time." +
                    " You lost ${0:N2}", betAmount);
            betResult = betResult * (-1);
            playerBalance();
        }






//  ============   set, update the amount of money the player has   ============   
        public void playerBalance()
        {
            // should this go higher on the page since it shows the starting balance?



            double currentPlayerBalance = 100.00;



  

            currentPlayerBalance = currentPlayerBalance + betResult;

            playerBalanceLabel.Text = string.Format("Your new balance is ${0:N2}", 
                currentPlayerBalance);

        }




//  ============   clears bet amount from screen to avoid accidental bets   ============ 
        private void clearBetAmount()
        {       amountBetTextBox.Text = ""; }





//  ============   Make Bet button that starts the process   ============   
        protected void makeBetButton_Click(object sender, EventArgs e)
        {
            clearBetResultLabel();
            displayRandomImages();
            getBetAmount();
            //clearBetAmount();

        }
    }
}