using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace Project.ItemSystem
{
    public partial class WeaponEditor
    {

        void ListView()
        {
            Vector2 scrollpos = new Vector2();
            GUILayout.BeginVertical();
            scrollpos = GUILayout.BeginScrollView(scrollpos);
            foreach (Weapon wep in weaponDB.weaponList)
            {
                if (GUILayout.Button("X"))
                {
                    weaponDB.Remove(wep);
                    jsonString = JsonUtility.ToJson(weaponDB, true);
                    File.WriteAllText(PATH, jsonString);
                    weaponDB = JsonUtility.FromJson<WeaponList>(jsonString);
                }
                if (GUILayout.Button(wep.name))
                {
                    showingdetails = true;
                    tempweapon = wep;
                }

               
            }
            GUILayout.EndScrollView();
            GUILayout.EndVertical();
        }

    }
}
