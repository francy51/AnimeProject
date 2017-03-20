using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Project.ItemSystem
{
    public class InGameWeaponDB : MonoBehaviour
    {

        WeaponList weaponDB;
        string PATH;
        string jsonString;

        void Start()
        {
            if (PATH == null)
                PATH = Application.streamingAssetsPath + "/Item System/JSON/weaponlist.json";

            jsonString = File.ReadAllText(PATH);

            weaponDB = JsonUtility.FromJson<WeaponList>(jsonString);
        }



        public Weapon getWeapon(string name)
        {

            foreach (Weapon wep in weaponDB.weaponList)
            {
                if (wep.name == name)
                {
                    return wep;
                }
            }
            Debug.LogError("Didn't find wepon");
            return null;
        }

    }
}