using System;
using System.Collections.Generic;
using CardManager;
using DeckManager;
using GameManager;
using BlackJack;

namespace PlayerManager {
    public class Player {
        public string name { get; set;}
        public int winCount = 0;
        public List<Card> hand = new List<Card>();
        public Player() {
            name = Console.ReadLine();
        }

        public void WinHand() {
            this.winCount += 1;
        }
        public void playerChoice(){
            string answer = Console.ReadLine().ToLower();
            if(answer == "hit"){
                this.hit();
            }
        }
        public void hit()
        {   
            
            // System.Console.WriteLine("Dealer: Hit or Stay " + this.name);
            // return Console.ReadLine();
        }
        public void stay(){

        }
        public void roundEval(){

        }
        public Card Discard2(int CardIdx) {
            if (hand[CardIdx] != null) {
                Card toReturn = hand[CardIdx];
                hand.RemoveAt(CardIdx);
                return toReturn;
            }
            return null;
        }
        public bool Discard(Card card) {
            return hand.Remove(card);
        }
        public int showHand(){
            int totalHand = 0;
            foreach (Card handCard in this.hand)
            {
                System.Console.WriteLine(this.name + " has a(n) " + handCard.numerical_value + " of " + handCard.suit);
                totalHand += handCard.numValue;
            }
            return totalHand;
        }
        public void resetHand(){
            foreach(Card handCard in this.hand){
                Discard(handCard);
            }
        }
    }
}