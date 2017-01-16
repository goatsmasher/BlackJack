using System;
using System.Collections.Generic;
using PlayerManager;
using DeckManager;
using CardManager;
// BLACKJACK!
namespace BlackJack {
    public class Program {
        public static void Main(){
            BlackJack.Program.NumberOfPlayers();
        }


        public static void GameSetup(List<Player> gamePlayers, int players)
        {
            DeckManager.Deck gameDeck = new Deck ();
            gameDeck.Shuffle();
            //Create players based on the input of the readline
            for (int i = 1; i <= players; i++) {
                Console.WriteLine("Please Enter A Name For Player " + i + ":");
                PlayerManager.Player playerInstance = new Player();
                gamePlayers.Add(playerInstance);
            }
            GamePlay(gamePlayers, gameDeck);
        }
        public static void NumberOfPlayers(){
            List<Player> gamePlayers = new List<Player>();
            Console.WriteLine("How many players would like to play? [1-4]");
            string numOfPlayers = Console.ReadLine();
            if (numOfPlayers == "1" || numOfPlayers == "2" || numOfPlayers == "3" || numOfPlayers == "4"){
                int players = Convert.ToInt32(numOfPlayers);
                GameSetup(gamePlayers, players);
            }
            else {
                System.Console.WriteLine("\n\nPlease enter a valid number of players\n");
                NumberOfPlayers();
            }
        }
        public static void GamePlay(List<Player> gamePlayers, Deck gameDeck) {

            int[] turns =  {1,2,3,4};
            for (int i = 0; i < turns.Length; i++)
            {
                System.Threading.Thread.Sleep(2000);
                if (i == 0){
                    System.Console.WriteLine("\n*/*/*Welcome To BlackJack - Dojo Style*/*/*");
                }
                System.Console.WriteLine("\n~Round #{0} Started~\n", i+1); 
            
            foreach (Player gamePlayer in gamePlayers){
                int cardCount = gamePlayer.hand.Count;
                gamePlayer.hand.RemoveRange(0,cardCount);
                gamePlayer.Busted = false;
                gameDeck.Deal(gamePlayer);
                gameDeck.Deal(gamePlayer);
                }
            foreach (Player gamePlayer in gamePlayers)
            {
                gamePlayer.showHand();
                System.Console.WriteLine("Your current hand value is " + gamePlayer.evalHand().ToString());
                bool doneWithHand = false;
                while (doneWithHand == false && gamePlayer.Busted == false && gamePlayer.isBlackjack == false) {
                    doneWithHand = gamePlayer.playerChoice(gameDeck);
                }
            }
            WhoWon(gamePlayers);
            }
            NumberOfPlayers();
            }
        public static void WhoWon(List<Player> gamePlayers){
            int winningHand = 0;
            string currentWinner = "";
            foreach (Player gamePlayer in gamePlayers){
                if (gamePlayer.stay() > winningHand && gamePlayer.stay() < 22) {
                    winningHand = gamePlayer.stay();
                    currentWinner = gamePlayer.name.ToString();    
                }
            }
            System.Console.WriteLine("The winner of that hand was {0} with a hand total of {1}.", currentWinner, winningHand);

        }
    }
}