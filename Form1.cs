using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Memory Card game.  Turn over at most two cards at a time.  
 If you turn over the same two cards, you get a match and the cards can stay face up.
 Win by matching all the cards. */
namespace Memory
{
    struct Card
    {
        public bool faceUp; //true if card is turned over but not matched
        public int secretPicture; //secret picture on the face of the card; corresponds to dessertImageList Index
        public bool matched; //true if card has been matched
        public PictureBox cardPictureBox; //image that the card displays
    }

    enum SecretPic {Back, Choco, CupCake, Donut, Nutella, Orange, Vanilla};
    public partial class Form1 : Form
    {
        //main array of cards
        Card[] cardArray = new Card[12];

        //timer
        GameTimerForm myTimerForm;

        public Form1()
        {
            InitializeComponent();
            InitializeCards();
            DisplayCards();
            StartTimer();
        }

        private void StartTimer()
        {
            myTimerForm = new GameTimerForm();
            myTimerForm.GameTimer.Start();
            myTimerForm.Show();

        }
        /*This method creates and deals all the cards for the beginning of the game.*/
        private void InitializeCards()
        {
            for (int i = 0; i < cardArray.Length; i++)
            {
                cardArray[i] = new Card(); //initialize card
                cardArray[i].faceUp = false; //face down
                cardArray[i].matched = false; //not matched 
            }

            //Associate cards with their component picture boxes on the form
            cardArray[0].cardPictureBox = card0;
            cardArray[1].cardPictureBox = card1;
            cardArray[2].cardPictureBox = card2;
            cardArray[3].cardPictureBox = card3;
            cardArray[4].cardPictureBox = card4;
            cardArray[5].cardPictureBox = card5;
            cardArray[6].cardPictureBox = card6;
            cardArray[7].cardPictureBox = card7;
            cardArray[8].cardPictureBox = card8;
            cardArray[9].cardPictureBox = card9;
            cardArray[10].cardPictureBox = card10;
            cardArray[11].cardPictureBox = card11;

            //Secret pictures are randomly assigned to the cards in two steps.
            /*Step One: Get the cards; Create a list of the possible card image index
             values using the enumerated types SecretPic.  The enumerated types could
             just be a list of integers but were used to improve readability.  */
            List<SecretPic> cardPicturesList = new List<SecretPic>();
            for (int i = 0; i < 2; i++)
            {
                cardPicturesList.Add(SecretPic.Choco);
                cardPicturesList.Add(SecretPic.CupCake);
                cardPicturesList.Add(SecretPic.Donut);
                cardPicturesList.Add(SecretPic.Nutella);
                cardPicturesList.Add(SecretPic.Orange);
                cardPicturesList.Add(SecretPic.Vanilla);
            }
            //Step Two: Deal; Randomly assign secretPictures to the cards.  
            Random myRand = new Random();
            int randomNum;
            for (int i = 0; i < cardArray.Length; i++)
            {
                randomNum = myRand.Next(cardPicturesList.Count);
                cardArray[i].secretPicture = (int) cardPicturesList[randomNum]; //cast to get int from enumerated type
                cardPicturesList.Remove(cardPicturesList[randomNum]); //remove card from further consideration
            }
        }

        /*This method displays all the cards.  It's important to distinguish between
         cards that are faceUp and cards that are matched.  Matched cards will always be
         displayed.  On the other hand, a maximum of two faceUp cards will be displayed 
         at a time.  Matched cards are not faceUp cards (even though we can see their faces).
        This method also checks if the game has been won.*/
        private void DisplayCards()
        {
            int secretPicture = 0;
            bool won = true;
            for (int i = 0; i < cardArray.Length; i++)
            {
                if (cardArray[i].matched || cardArray[i].faceUp)
                {
                    secretPicture = cardArray[i].secretPicture;
                    cardArray[i].cardPictureBox.Image = dessertImageList.Images[secretPicture];
                }
                else //show the back of the card
                {
                    cardArray[i].cardPictureBox.Image = dessertImageList.Images[0];
                    won = false; //the game is not won if some cards remain undisplayed
                }
            }
            if (won)
            {
                myTimerForm.GameTimer.Stop();
                PlayAgain();
            }
        }

        //This method asks the user if they want to play again and reintializes the game.
        private void PlayAgain()
        {
            
            DialogResult dr = MessageBox.Show("Play Again?", "YOU WON!!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                myTimerForm.Close();//close old timer
                InitializeCards();
                DisplayCards();
                StartTimer();
            }
            else
                this.Close();
        }

        /*This method checks how many unmatched cards the user is currently viewing.  
         Returns false if the user is already viewing two unmatched cards.
         Returns true if the user if viewing 0 or 1 unmatched cards.*/
        private bool PeeksRemaining()
        {
            int faceUp = 0;
            for (int i = 0; i < cardArray.Length; i++)
            {
                if (cardArray[i].faceUp)
                    faceUp++;
            }
            if (faceUp < 2)
                return true;
            else //there are already two faceUp cards, so no peaks remaining
            {
                for (int i = 0; i < cardArray.Length; i++)
                {
                    if (cardArray[i].faceUp)
                        cardArray[i].faceUp = false; //this is necessary to turn over the unmatched cards
                }
            }
                return false;
        }

        /*This method checks if the last two cards turned over by the user match.
         It distinguishes between faceUp cards (i.e. the last two cards turned over by the user)
         and matched cards (i.e. cards that the  user has previously matched).  If a match is found,
         the faceUp cards become matched cards.*/
        private void CheckMatches()
        {

            int firstCardIndex = 0;  
            int secondCardIndex = 0;
            bool firstCardUp = false;
            bool secondCardUp = false;

            /*This loop captures the main cardArray indices of the card 
            or cards that are currently face up.*/
            for (int i = 0; i < cardArray.Length; i++)
            {
                if (cardArray[i].faceUp)
                {
                    if (firstCardUp)
                    {
                        secondCardIndex = i;
                        secondCardUp = true;
                    }
                    else
                    {
                        firstCardIndex = i;
                        firstCardUp = true;
                    }
                }
            }
            /*If two cards are face up check if they match.
            It is important to compare the cardArray elements directly as copies will only
            be aliases and not have the same attribures.*/
            if (secondCardUp) 
            {
                if (cardArray[firstCardIndex].secretPicture == cardArray[secondCardIndex].secretPicture)
                {
                    cardArray[firstCardIndex].faceUp = false;
                    cardArray[secondCardIndex].faceUp = false;
                    cardArray[firstCardIndex].matched = true;
                    cardArray[secondCardIndex].matched = true;
                }
            }
        }

        

        /*This method is called when the user clicks a card.  Before revealing the secret picture
         this method checks to make sure that the user is not already viewing two unmatched cards.
         Once the secret picture is revealed, this method checks if a match has been found.
         Then cards are displayed.*/
        private void TurnOver(int cardIndex)
        {
            if (cardArray[cardIndex].faceUp)
                return; //ignore the click if the card is already face up
            if (PeeksRemaining())
            {
                cardArray[cardIndex].faceUp = true;
            }
            CheckMatches();
            DisplayCards();
        }


        private void card0_Click(object sender, EventArgs e)
        {
            TurnOver(0);
        }

        private void card1_Click(object sender, EventArgs e)
        {
            TurnOver(1);
        }

        private void card2_Click(object sender, EventArgs e)
        {
            TurnOver(2);
        }

        private void card3_Click(object sender, EventArgs e)
        {
            TurnOver(3);
        }

        private void card4_Click(object sender, EventArgs e)
        {
            TurnOver(4);
        }

        private void card5_Click(object sender, EventArgs e)
        {
            TurnOver(5);
        }

        private void card6_Click(object sender, EventArgs e)
        {
            TurnOver(6);
        }

        private void card7_Click(object sender, EventArgs e)
        {
            TurnOver(7);
        }

        private void card8_Click(object sender, EventArgs e)
        {
            TurnOver(8);
        }

        private void card9_Click(object sender, EventArgs e)
        {
            TurnOver(9);
        }

        private void card10_Click(object sender, EventArgs e)
        {
            TurnOver(10);
        }

        private void card11_Click(object sender, EventArgs e)
        {
            TurnOver(11);
        }

        //A print method for quick debugging only
        private void printCards()
        {
            string debugString = "";
            for (int i = 0; i < cardArray.Length; i++)
            {
                debugString += "Card: " + i + " FaceUp? " + cardArray[i].faceUp + " Matched? " +
                    cardArray[i].matched + "\n";
            }
            MessageBox.Show(debugString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
