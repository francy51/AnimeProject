using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

namespace Project.ItemSystem
{
    public partial class WeaponEditor
    {

        bool showingdetails;

        void showDetails()
        {
            GUILayout.BeginVertical();

            Debug.Log(tempweapon.name);
            Debug.Log(tempweapon);

            tempweapon.name = GUILayout.TextField(tempweapon.name);

            if (GUILayout.Button("Save"))
            {
                bool alreadyExists = CheckForExistance(tempweapon);
                if (!alreadyExists)
                    weaponDB.Add(tempweapon);
                jsonString = JsonUtility.ToJson(weaponDB, true);
                File.WriteAllText(PATH, jsonString);
                weaponDB = JsonUtility.FromJson<WeaponList>(jsonString);
                showingdetails = false;
                tempweapon = new Weapon();
            }

            if (GUILayout.Button("Cancel"))
            {
                showingdetails = false;

            }

            GUILayout.EndVertical();

        }

        private bool CheckForExistance(Weapon wep)
        {
            for (int i = 0; i < weaponDB.Length(); i++)
            {
                if (weaponDB.weaponList[i].name == wep.name)
                {
                    Debug.Log("Weapon Alreayd exists");
                    weaponDB.Replace(wep, i);
                    return true;
                }
            }
            return false;
        }

        void showButtons()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add"))
            {
                tempweapon = new Weapon();
                showingdetails = true;
            }
            GUILayout.EndHorizontal();
        }

    }
}
