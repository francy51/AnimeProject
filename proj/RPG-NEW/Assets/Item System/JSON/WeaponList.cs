using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
namespace Project.ItemSystem
{
    [Serializable]
    public class WeaponList
    {
        [SerializeField]
        public List<Weapon> weaponList;

        public void Add(Weapon Weapon)
        {
            weaponList.Add(Weapon);
        }

        public void Remove(Weapon weapon)
        {
            weaponList.Remove(weapon);
        }

        public void Remove(int index)
        {
            weaponList.RemoveAt(index);
        }

        public void Insert(Weapon weapon,int index)
        {
            weaponList.Insert(index, weapon);
        }

        public void Replace(Weapon weapon,int index)
        {
            weaponList[index] = weapon;
        }

        public int Length()
        {
            return weaponList.Count;
        }

    }
}