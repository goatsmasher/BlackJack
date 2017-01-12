using System;
using System.Collections.Generic;
using PlayerManager;
using DeckManager;
using CardManager;
using GameManager;

namespace BlackJack {
public class Program
{
    public static void Main(){
        BlackJack.Program.GameSetup();
    }


    public static void GameSetup()
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
        GamePlay(gamePlayers, gameDeck);
    }
    public static void GamePlay(List<Player> gamePlayers, Deck gameDeck) {

        int[] turns =  {1,2,3,4};
        for (int i = 0; i < turns.Length; i++)
        {
           System.Console.WriteLine("New Round Started"); 
           
           foreach (Player gamePlayer in gamePlayers){
            int cardCount = gamePlayer.hand.Count;
            gamePlayer.hand.RemoveRange(0,cardCount);
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
        GameSetup();
        }
    }
}



