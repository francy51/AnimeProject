using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace Project.StatSystem
{
    public class playerStats : MonoBehaviour, IPSplayerActiveStats, IPSplayerPassiveStats
    {

        public Text[] texts;

        #region implementing interfaces + variables

        int _armor;

        public int Armor
        {
            get
            {
                return _armor;
            }

            set
            {
                _armor = value;
            }
        }

        float _attackSpeed;

        public float AttackSpeed
        {
            get
            {
                return _attackSpeed;
            }

            set
            {
                _attackSpeed = value;
            }
        }

        int _curDodges;

        public int curDodges
        {
            get
            {
                return _curDodges;
            }

            set
            {
                _curDodges = value;
            }
        }

        int _curHealth;

        public int curHealth
        {
            get
            {
                return _curHealth;
            }

            set
            {
                _curHealth = value;
            }
        }

        float _dodgeRegen;

        public float DodgeRegen
        {
            get
            {
                return _dodgeRegen;
            }

            set
            {
                _dodgeRegen = value;
            }
        }

        float _healthRegen;

        public float HealthRegen
        {
            get
            {
                return _healthRegen;
            }

            set
            {
                _healthRegen = value;
            }
        }

        int _intelligence;

        public int Intelligence
        {
            get
            {
                return _intelligence;
            }

            set
            {
                _intelligence = value;
            }
        }

        int _maxDodges;

        public int maxDodges
        {
            get
            {
                return _maxDodges;
            }

            set
            {
                _maxDodges = value;
            }
        }

        int _maxHealth;

        public int maxHealth
        {
            get
            {
                return _maxHealth;
            }

            set
            {
                _maxHealth = value;
            }
        }

        int _shield;

        public int Shield
        {
            get
            {
                return _shield;
            }

            set
            {
                _shield = value;
            }
        }

        float _speed;

        public float Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

        int _strength;

        public int Strength
        {
            get
            {
                return _strength;
            }

            set
            {
                _strength = value;
            }
        }

        float _charisma;

        public float Charisma
        {
            get
            {
                return _charisma;
            }

            set
            {
                _charisma = value;
            }
        }

        float _martial;

        public float Martial
        {
            get
            {
                return _martial;
            }

            set
            {
                _martial = value;
            }
        }

        float _learning;

        public float Learning
        {
            get
            {
                return _learning;
            }

            set
            {
                _learning = value;
            }
        }

        float _intrigue;

        public float Intrigue
        {
            get
            {
                return _intrigue;
            }

            set
            {
                _intrigue = value;
            }
        }

        float _diplomacy;

        public float Diplomacy
        {
            get
            {
                return _diplomacy;
            }

            set
            {
                _diplomacy = value;
            }
        }

        float _stewardship;

        public float Stewardship
        {
            get
            {
                return _stewardship;
            }

            set
            {
                _stewardship = value;
            }
        }

        int _prestige;

        public int Prestige
        {
            get
            {
                return _prestige;
            }

            set
            {
                _prestige = value;
            }
        }
        #endregion

        void Update()
        {
            texts[0].text = "martial - " + _martial;
            texts[1].text = "learning - " + _learning;
            texts[2].text = "intrigue - " + _intrigue;
            texts[3].text = "charisma - " + _charisma;
            texts[4].text = "stewardship - " + _stewardship;
            texts[5].text = "diplomacy - " + _diplomacy;
            texts[6].text = "prestige - " + _prestige;
            texts[7].text = "strength - " + _strength;
            texts[8].text = "intelligence - " + _intelligence;
            texts[9].text = "dodges - " + _maxDodges;
            texts[10].text = "health - " + _maxHealth;
            texts[11].text = "speed - " + _speed;
            texts[12].text = "attack speed - " + _attackSpeed;
            texts[13].text = "health regen - " + _healthRegen;
            texts[14].text = "dodge regen - " + _dodgeRegen;
            texts[15].text = "armor - " + _armor;
            texts[16].text = "shield - " + _shield;

        }





    }
}
