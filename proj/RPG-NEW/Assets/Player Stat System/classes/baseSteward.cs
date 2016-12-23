using UnityEngine;
using System.Collections;


namespace Project.StatSystem
{
    public class baseSteward : MonoBehaviour
    {

        public GameObject player;
        playerStats stats;

        float _charisma;

        float _martial;

        float _learning;

        float _intrigue;

        float _diplomacy;

        float _stewardship;

        int _prestige;

        void Start()
        {
            stats = FindObjectOfType<playerStats>().GetComponent<playerStats>();
            _martial = .05f;
            _learning = .3f;
            _stewardship = .5f;
            _charisma = .3f;
            _intrigue = .2f;
            _diplomacy = .2f;
            _prestige = 50;
        }

        public void onActivate()
        {
            stats.Martial = _martial;
            stats.Charisma = _charisma;
            stats.Learning = _learning;
            stats.Stewardship = _stewardship;
            stats.Diplomacy = _diplomacy;
            stats.Intrigue = _intrigue;
            stats.Prestige = _prestige;
        }


    }
}