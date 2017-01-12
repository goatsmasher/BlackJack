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
    //   public string playerChoice(){
    //         string answer = Console.ReadLine().ToLower();
    //         return answer;
    //     }
        // public void hit(Player player)
        // {   
        //     gameDeck.Deal(player);
        // }
        // public bool stay = true;

    public static void Main(string[] args)
    {
        
        List<Player> gamePlayers = new List<Player>();
        Console.WriteLine("How many players would like to play? [1-4]");
        string numOfPlayers = Console.ReadLine();
        int players = Convert.ToInt32(numOfPlayers);
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
            string answer = Console.ReadLine();
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
                    gamePlayer.playerChoice();
                }
                }else if(answer == "stay"){
                    continue;
                }else{
                    gamePlayer.playerChoice();
                }
        
        }
        }
    }
    }
}



