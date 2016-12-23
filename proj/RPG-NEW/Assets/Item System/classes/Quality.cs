using UnityEngine;
using System.Collections;
using System;

namespace Project.ItemSystem
{
    [Serializable]
    public class Quality : IISQuality
    {
        [SerializeField]
        Sprite _border;
        [SerializeField]
        string _name;
        public Sprite border
        {
            get
            {
                return _border;
            }

            set
            {
                _border = value;
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
    }
}