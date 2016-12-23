﻿using UnityEngine;
using System.Collections;

namespace Project.StatSystem
{
    public class baseDiplomat : MonoBehaviour
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
            _learning = .4f;
            _stewardship = .2f;
            _charisma = .4f;
            _intrigue = .3f;
            _diplomacy = .5f;
            _prestige = 100;
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