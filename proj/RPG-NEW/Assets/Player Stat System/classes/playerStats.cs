using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace Project.StatSystem
{
    public class playerStats : MonoBehaviour, IPSplayerActiveStats, IPSplayerPassiveStats, IPSplayerAvatar
    {

        #region implementing interfaces + variables
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
        float _walkSpeed;

        public float WalkSpeed
        {
            get
            {
                return _walkSpeed;
            }

            set
            {
                _walkSpeed = value;
            }
        }
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
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

        [SerializeField]
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
        [SerializeField]
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
        [SerializeField]
        GameObject _prefab;

        public GameObject Prefab
        {
            get
            {
                return _prefab;
            }

            set
            {
                _prefab = value;
            }
        }
        [SerializeField]
        string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }

        }
        [SerializeField]
        float _jumpHeight;

        public float JumpHeight
        {
            get
            {
                return _jumpHeight;
            }

            set
            {
                _jumpHeight = value;
            }
        }
        #endregion



    }
}
