using UnityEngine;
using UnityEngine.UI;
using Project.StatSystem;
using UnityEngine.SceneManagement;

using System.Collections;
using Project.Misc;

namespace Project.CharacterCreation
{
    public class CharacterCreationManager : MonoBehaviour
    {

        public bool choosingCharacter;
        public bool choosingName;
        animationController controller;
        GameObject chosenCharacter;
        public GameObject chooseStat;
        public GameObject chooseName;
        public InputField nameInput;
        playerStats stats;


        float _charisma;

        float _martial;

        float _learning;

        float _intrigue;

        float _diplomacy;

        float _stewardship;

        int _prestige;

        int _strength;
        int _intelligence;
        int _maxDodges;
        int _maxHealth;
        float _speed;
        int _attackSpeed;
        int _healthRegen;
        int _dodgeRegen;
        int _armor;
        int _shield;

        public Text[] texts;

        #region Public geters and setters
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

        public int MaxDodges
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

        public int MaxHealth
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

        public int AttackSpeed
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

        public int HealthRegen
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

        public int DodgeRegen
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
        #endregion
        // Use this for initialization
        void Start()
        {
            controller = GetComponent<animationController>();
            stats = FindObjectOfType<GlobalManagerReplication>().GetComponent<playerStats>();
            choosingName = false;
            chooseStat.SetActive(false);
            chooseName.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {

            texts[0].text = "martial - " + Martial;
            texts[1].text = "learning - " + Learning;
            texts[2].text = "intrigue - " + Intrigue;
            texts[3].text = "charisma - " + Charisma;
            texts[4].text = "stewardship - " + Stewardship;
            texts[5].text = "diplomacy - " + Diplomacy;
            texts[6].text = "prestige - " + Prestige;
            texts[7].text = "strength - " + Strength;
            texts[8].text = "intelligence - " + Intelligence;
            texts[9].text = "dodges - " + MaxDodges;
            texts[10].text = "health - " + MaxHealth;
            texts[11].text = "speed - " + Speed;
            texts[12].text = "attack speed - " + AttackSpeed;
            texts[13].text = "health regen - " + HealthRegen;
            texts[14].text = "dodge regen - " + DodgeRegen;
            texts[15].text = "armor - " + Armor;
            texts[16].text = "shield - " + Shield;

            if (chosenCharacter == null)
            {
                choosingCharacter = true;
            }
            else
                choosingCharacter = false;

            if (!choosingCharacter && !choosingName)
            {
                //then choosing class and ect.
                chooseStat.SetActive(true);
                chooseName.SetActive(false);
            }
            else if (choosingName)
            {
                chooseName.SetActive(true);
                chooseStat.SetActive(false);
            }
        }

        public void pressedBack()
        {
            if (!choosingCharacter && !choosingName)
            {
                chosenCharacter = null;
                chooseStat.SetActive(false);
                controller.ResetCharacters();
            }
            else if (choosingName)
            {
                choosingName = false;
            }
        }

        public void pressedContinue()
        {
            if (!choosingCharacter && !choosingName)
            {
                choosingName = true;
                return;
            }
            else if (choosingName)
            {
                //Confirm Everything in the player stats

                if (nameInput.text == null)
                {
                    Debug.Log("Need Name");
                    return;
                }
                else
                {
                    stats.Name = nameInput.text;
                    stats.Charisma = Charisma;
                    stats.Martial = Martial;
                    stats.Learning = Learning;
                    stats.Intrigue = Intrigue;
                    stats.Diplomacy = Diplomacy;
                    stats.Stewardship = Stewardship;
                    stats.Prestige = Prestige;
                    stats.Strength = Strength;
                    stats.Intelligence = Intelligence;
                    stats.maxDodges = MaxDodges;
                    stats.maxHealth = MaxHealth;
                    stats.Speed = Speed;
                    stats.AttackSpeed = AttackSpeed;
                    stats.HealthRegen = HealthRegen;
                    stats.DodgeRegen = DodgeRegen;
                    stats.Armor = Armor;
                    stats.Shield = Shield;
                    DontDestroyOnLoad(chosenCharacter);
                    stats.Prefab = chosenCharacter;
                    Debug.Log("Saved player stats");
                    Debug.Log("Load Play World Here Now");
                    SceneManager.LoadScene(1);
                    //load play World
                }
            }
        }



        public void checkClickTarget(GameObject trigger)
        {
            chosenCharacter = controller.characterSelected(trigger);
        }
    }
}