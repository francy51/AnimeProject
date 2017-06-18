using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Project.ItemSystem;

public class WeaponEditor : EditorWindow {

    private string PATH;

    [SerializeField]
    WeaponData weaponData;

    [MenuItem("Item System/Weapon Editor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        WeaponEditor window = (WeaponEditor)EditorWindow.GetWindow(typeof(WeaponEditor));
        window.Show();
    }

    void OnEnable()
    {
        PATH = Application.streamingAssetsPath + "/Item System/JSON/weaponlist.json";
    }

    void OnGUI()
    {
        if (weaponData != null)
        {

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("weaponData");
            EditorGUILayout.PropertyField(serializedProperty, true);

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Save data"))
            {
                SaveGameData();
            }
        }

        if (GUILayout.Button("Load data"))
        {
            LoadGameData();
        }
    }

    private void LoadGameData()
    {
        string filePath = PATH;

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            weaponData = JsonUtility.FromJson<WeaponData>(dataAsJson);
        }
        else
        {
            weaponData = new WeaponData();
            Debug.Log(weaponData.weapon);
        }
    }

    private void SaveGameData()
    {

        string dataAsJson = JsonUtility.ToJson(weaponData);

        string filePath = PATH;
        File.WriteAllText(filePath, dataAsJson);

    }

}
