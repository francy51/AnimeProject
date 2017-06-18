using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Project.ItemSystem
{
    public class InGameWeaponDB : MonoBehaviour
    {


        string PATH;
        string jsonString;

        public WeaponData weaponDB;

        void Awake()
        {
            if (PATH == null)
                PATH = Application.streamingAssetsPath + "/Item System/JSON/weaponlist.json";

            LoadGameData();
        }

        void Start()
        {
            //GameObject.FindObjectOfType<RPGCharacterControllerFREE>().GetComponent<RPGCharacterControllerFREE>().test();
            //GameObject.FindObjectOfType<RPGCharacterControllerFREE>().GetComponent<RPGCharacterControllerFREE>().testInventory();
        }


        public Weapon getWeapon(string name)
        {

            foreach (Weapon wep in weaponDB.weapon)
            {
                if (wep.name == name)
                {
                    return wep;
                }
            }
            Debug.LogError("Didn't find weapon");
            return null;
        }

        private void LoadGameData()
        {
            string filePath = PATH;

            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                weaponDB = JsonUtility.FromJson<WeaponData>(dataAsJson);
            }
            else
            {
                Debug.Log(weaponDB.weapon);
            }
        }
    }
}