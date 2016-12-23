using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;
namespace Project.ItemSystem
{

    public partial class WeaponEditor : EditorWindow
    {

        Weapon tempweapon;
        WeaponList weaponDB;
        string PATH;
        string jsonString;

        [MenuItem("Item System/Weapon Editor")]
        public static void Init()
        {
            WeaponEditor window = EditorWindow.GetWindow<WeaponEditor>();
            window.minSize = new Vector2(400, 300);
            window.titleContent.text = "Weapon Editor";
            window.Show();
        }


        private void OnEnable()
        {
            if (PATH == null)
                PATH = Application.streamingAssetsPath + "/Item System/JSON/weaponlist.json";
            
            jsonString = File.ReadAllText(PATH);

            weaponDB = JsonUtility.FromJson<WeaponList>(jsonString);



        }

        private void OnGUI()
        {
            if (jsonString == null || jsonString == "")
            {
                PATH = Application.streamingAssetsPath + "/Item System/JSON/weaponlist.json";

                jsonString = File.ReadAllText(PATH);

                weaponDB = JsonUtility.FromJson<WeaponList>(jsonString);
            }
            GUILayout.BeginHorizontal();
            ListView();
            if (showingdetails)
            {
                showDetails();
            }
            else
            {
                showButtons();
            }
            GUILayout.EndVertical();
        }

        private void Update()
        {
   
        }


    }
}