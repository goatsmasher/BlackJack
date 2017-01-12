using System;
using System.Collections.Generic;
using PlayerManager;
using DeckManager;
using CardManager;
using GameManager;

namespace BlackJack {
public class Program
{
//    public DeckManager.Deck gameDeck = new Deck ();
      public string playerChoice(){
            string answer = Console.ReadLine();
            return answer;
        }
        public void hit(Player player)
        {   
            gameDeck.Deal(player);
        }
        public bool stay = true;
    
    public static void Main(string[] args)
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
        // foreach (Player gamePlayer in gamePlayers)
        // {
        //     gameDeck.Deal(gamePlayer); 
        //     gameDeck.Deal(gamePlayer);
            //Now let's show players what cards they have...?
            // gamePlayer.showHand();
        // }
        int[] turns =  {1,2,3,4};
        for (int i = 0; i < turns.Length; i++)
        {
           System.Console.WriteLine("New Round Started"); 
           foreach (Player gamePlayer in gamePlayers){
            gamePlayer.resetHand();
            gameDeck.Deal(gamePlayer);
            gameDeck.Deal(gamePlayer);
            }
           foreach (Player gamePlayer in gamePlayers)
        {
            System.Console.WriteLine(gamePlayer.showHand());
           string answer = gamePlayer.().ToLower();
           if(answer == "hit"){
               gameDeck.Deal(gamePlayer);
               //Fix christmas
               int playerHandValue = gamePlayer.showHand();
               if(playerHandValue > 21){
                   System.Console.WriteLine("BUST!");
                   continue;
               }else if(playerHandValue == 21){
                   System.Console.WriteLine("WOOO HOOO! BLACKJACK! Congrats!");
               }else{
                   gamePlayer.().ToLower();

               }
               
            }else if(answer == "stay"){
                continue;
            }else{
                gamePlayer.().ToLower();
            }
        
        }
        }
        }

     

        



    // DeckManager.Deck myDeck = new Deck();
    // PlayerManager.Player Josh = new Player();
    // PlayerManager.Player Luca = new Player();
    // Console.WriteLine("Welcome {0}", Josh.name);
    }
}



