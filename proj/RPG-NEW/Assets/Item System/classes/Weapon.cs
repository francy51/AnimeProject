using UnityEngine;
using System.Collections;
using System;

namespace Project.ItemSystem
{
    [Serializable]
    public class Weapon : IISWeapon
    {

        public Weapon()
        {

            _damage = 0;

            _name = "";

            _weight = 0;

            _prefab = new GameObject();

            _quality = new Quality();

            _penetration = 0;

            _type = "";

            _icon = new Sprite();
        }

        [SerializeField]
        int _damage;
        [SerializeField]
        string _name;
        [SerializeField]
        int _weight;
        [SerializeField]
        GameObject _prefab;
        [SerializeField]
        Quality _quality;
        [SerializeField]
        float _penetration;
        [SerializeField]
        string _type;
        [SerializeField]
        Sprite _icon;

        public int damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
            }
        }

        public string name
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

        public float penetration
        {
            get
            {
                return _penetration;
            }

            set
            {
                _penetration = value;
            }
        }

        public GameObject prefab
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

        public Quality quality
        {
            get
            {
                return _quality;
            }

            set
            {
                _quality = value;
            }
        }

        public string type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public int weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
            }
        }

        public Sprite icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
            }
        }
    }
}
