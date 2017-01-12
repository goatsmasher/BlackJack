using System;
using System.Collections.Generic;
using CardManager;
using DeckManager;
using GameManager;

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
        public void hitOrStay(string answer)
        {   
            System.Console.WriteLine("Dealer: Hit or Stay" + this.name);
            answer = Console.ReadLine();
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
    }
}