using UnityEngine;

using System.Collections;


namespace Project.StatSystem
{
    public class baseSteward : MonoBehaviour
    {


        float _charisma;

        float _martial;

        float _learning;

        float _intrigue;

        float _diplomacy;

        float _stewardship;

        int _prestige;

        void Start()
        {
            _martial = .05f;
            _learning = .3f;
            _stewardship = .5f;
            _charisma = .3f;
            _intrigue = .2f;
            _diplomacy = .2f;
            _prestige = 50;
        }

        //public void onActivate()
        //{
        //    TempStats.Martial = _martial;
        //    TempStats.Charisma = _charisma;
        //    TempStats.Learning = _learning;
        //    TempStats.Stewardship = _stewardship;
        //    TempStats.Diplomacy = _diplomacy;
        //    TempStats.Intrigue = _intrigue;
        //    TempStats.Prestige = _prestige;
        //}


    }
}