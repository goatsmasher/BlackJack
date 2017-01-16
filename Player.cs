using System;
using System.Collections.Generic;
using CardManager;
using DeckManager;
using BlackJack;

namespace PlayerManager {

    public class Player {
        public string name { get; set;}
        public string aa = "a";
        public string an = "an";
        public int winCount = 0;
        public bool Busted = false;
        public bool isBlackjack = false;
        public List<Card> hand = new List<Card>();
        public Player() {
            name = Console.ReadLine();
        }
        public int evalHand()
       {
           int totalHand = 0;
           foreach (Card handCard in this.hand)
           {
               if(handCard.numerical_value == "King" || handCard.numerical_value == "Queen"|| handCard.numerical_value == "Jack")
               {
                   handCard.numValue = 10;
               }
               if(handCard.numerical_value == "Ace")
               {  
                   System.Console.WriteLine("Ace can be 1 / 11");
                string input = Console.ReadLine();
                if (input == "1" || input == "11"){
                    int ace =  Convert.ToInt32(input);
                    if (ace == 1){
                        handCard.numValue = 1;
                    }
                    if (ace == 11) {
                        handCard.numValue = 11;
                    }
                }
                else{
                    System.Console.WriteLine("YOU GOT AN ACE! WHAT VALUE DO YOU WANT?? 1 or 11??");
                    evalHand();
                }
                showHand();
               }
               totalHand += handCard.numValue;
           }
           return totalHand;
       }

        public void WinHand() {
            this.winCount += 1;
        }
            public bool playerChoice(Deck gameDeck){
                string answer = "";
                if (this.Busted == true) {
                    answer = "stay";
                }
                if (this.isBlackjack == true) {
                    answer = "stay";
                }
                System.Console.WriteLine("Dealer: 'Would you like to Hit or Stay, " + this.name + "?'");
                Console.Write(this.name + ":");
                answer = Console.ReadLine().ToLower();
                Console.WriteLine("");
                if(answer == "hit") {
                    hit(gameDeck);
                    return false;
                }
                if(answer == "stay") {
                    stay();
                    return true;
                }
                else {
                    Console.WriteLine("Please enter a valid choice :(");
                    playerChoice(gameDeck);
                    return false;
                }
            }
        public void hit(Deck gameDeck)
        {   
            System.Threading.Thread.Sleep(500);
            gameDeck.Deal(this);
            this.showHand();
            int handTotal = evalHand();
            if (handTotal < 21) {
                System.Console.WriteLine("Your current hand value is " + this.evalHand().ToString());
            } 
            if (handTotal > 21) {
                Console.WriteLine("\n############  !- " +this.name+ " Busted !- ############");
                Console.WriteLine("     ###### Next Players Turn! #####\n");
                System.Threading.Thread.Sleep(1000);
                this.Busted = true;
            }
            if (handTotal == 21) {
                Console.WriteLine("$~$~$~$~$~$~$~$~$~ You got BlackJack! ~$~$~$~$~$~$~$~$~$\n");
                this.isBlackjack = true;
            }
            else {
                if (this.Busted == true) {
                    stay();
                }
            }
        }
        public int stay(){
            int handTotal = 0;
            foreach (Card handCard in this.hand) {
                handTotal += handCard.numValue;
            }
            return handTotal;
        }
        public void Discard(Card card) {
            hand.Remove(card);
        }
        public void showHand(){
            foreach (Card handCard in this.hand)
            {
            string answer = (handCard.numerical_value == "Ace") ? an  : (handCard.numerical_value == "11") ? an : aa;
            System.Console.WriteLine(this.name + " has " + answer + " " + handCard.numerical_value + " of " + handCard.suit);            }
        }
        public void resetHand(){
            foreach(Card handCard in this.hand){
                Discard(handCard);
            }
        }
    }
}