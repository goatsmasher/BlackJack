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
        for (int i = 1; i < players; i++) {
            PlayerManager.Player playerInstance = new Player();
        }


    // DeckManager.Deck myDeck = new Deck();
    // PlayerManager.Player Josh = new Player();
    // PlayerManager.Player Luca = new Player();
    // Console.WriteLine("Welcome {0}", Josh.name);
    }
}
}


