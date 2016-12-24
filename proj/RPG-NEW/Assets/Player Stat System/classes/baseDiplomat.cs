using UnityEngine;
using Project.CharacterCreation;
using System.Collections;

namespace Project.StatSystem
{
    public class baseDiplomat : MonoBehaviour
    {
       
        CharacterCreationManager TempStats;

        float _charisma;

        float _martial;

        float _learning;

        float _intrigue;

        float _diplomacy;

        float _stewardship;

        int _prestige;

        void Start()
        {
            TempStats = FindObjectOfType<CharacterCreationManager>().GetComponent<CharacterCreationManager>();
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
                TempStats.Martial = _martial;
                TempStats.Charisma = _charisma;
                TempStats.Learning = _learning;
                TempStats.Stewardship = _stewardship;
                TempStats.Diplomacy = _diplomacy;
                TempStats.Intrigue = _intrigue;
                TempStats.Prestige = _prestige;
        }
    }
}