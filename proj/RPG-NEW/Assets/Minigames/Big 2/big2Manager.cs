using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Project.MiniGames.Big2
{

    public class big2Manager : MonoBehaviour
    {

        string[] cardNames;
        [SerializeField]
        cards[] _deck;
        List<cards> deck;
        List<cards> playerHands;
       
        cards tempcards;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                setupDeck();
            }
        }

        void setupDeck()
        {
            _deck = new cards[52];
            cardNames = new string[52]
                                {
                                "3 of Diamonds","3 of Clubs","3 of Hearts", "3 of Spades",
                                "4 of Diamonds","4 of Clubs","4 of Hearts", "4 of Spades",
                                "5 of Diamonds",  "5 of Clubs", "5 of Hearts", "5 of Spades",
                                "6 of Diamonds", "6 of Clubs","6 of Hearts", "6 of Spades",
                                "7 of Diamonds","7 of Clubs","7 of Hearts", "7 of Spades",
                                "8 of Diamonds", "8 of Clubs",   "8 of Hearts","8 of Spades",
                                "9 of Diamonds", "9 of Clubs","9 of Hearts", "9 of Spades",
                                "10 of Diamonds",  "10 of Clubs", "10 of Hearts", "10 of Spades",
                                "Jack of Diamonds",  "Jack of Clubs", "Jack of Hearts", "Jack of Spades",
                                "Queen of Diamonds","Queen of Clubs","Queen of Hearts","Queen of Spades",
                                "King of Diamonds",  "King of Clubs", "King of Hearts", "King of Spades",
                                "Ace of Diamonds", "Ace of Clubs",  " Ace of Hearts", "Ace of Spades",
                                "2 of Diamonds" ,"2 of Clubs","2 of Hearts" ,   "2 of Spades"
                                };
            setupCards();
        }

        void setupCards()
        {
            tempcards = new cards();
            int i = 0;

            int value = 0;
            for (int x = 0; x < _deck.Length; x++)
            {
                _deck[x] = new cards();
            }
            foreach (cards item in _deck)
            {
                if (i > cardNames.Length - 1)
                {
                    item.name = cardNames[0];
                    i = 0;
                }
                else
                {
                    item.name = cardNames[i];
                }
                item.value = value;


                i++;
                value++;
            }
        }

        void HandOutDeck()
        {
          
            while (_deck.Length != 0)
            {

            }
        }

    }

    [System.Serializable]
    public class cards
    {
        [SerializeField]
        float _value;
        [SerializeField]
        string _name;
        [SerializeField]
        GameObject _prefabBack;
        [SerializeField]
        GameObject _prefabFace;

        public float value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public GameObject PrefabBack
        {
            get { return _prefabBack; }
            set { _prefabBack = value; }
        }
        public GameObject PrefabFace
        {
            get { return _prefabFace; }
            set { _prefabFace = value; }
        }
    }



}