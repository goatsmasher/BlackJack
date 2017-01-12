using System;
using System.Collections.Generic;
using PlayerManager;
using DeckManager;
using CardManager;
using GameManager;

namespace BlackJack {
class Program
{
    static void Main(string[] args)
    {

        List<Player> gamePlayers = new List<Player>();
        string numOfPlayers = Console.ReadLine();
        int players = Convert.ToInt32(numOfPlayers);
        Console.WriteLine(players.GetType());
        DeckManager.Deck gameDeck = new Deck ();
        gameDeck.Shuffle();
        //Create players based on the input of the readline
        for (int i = 1; i <= players; i++) {
            PlayerManager.Player playerInstance = new Player();
            gamePlayers.Add(playerInstance);
            
        }
        //For each player in our new game, let's deal them 2 cards
        foreach (Player gamePlayer in gamePlayers)
        {
            gameDeck.Deal(gamePlayer); 
            gameDeck.Deal(gamePlayer);
            //Now let's show players what cards they have...?
            foreach (Card handCard in gamePlayer.hand)
            {
                System.Console.WriteLine(gamePlayer.name + " has a(n) " + handCard.numerical_value + " of " + handCard.suit);
            }
        }
        int[] turns =  {1,2,3,4};
        for (int i = 0; i < turns.Length; i++)
        {
           foreach (Player gamePlayer in gamePlayers)
        {
            
           
            }
        }

        }

     

        



    // DeckManager.Deck myDeck = new Deck();
    // PlayerManager.Player Josh = new Player();
    // PlayerManager.Player Luca = new Player();
    // Console.WriteLine("Welcome {0}", Josh.name);
    }
}
}


