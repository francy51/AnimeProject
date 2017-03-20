using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System;

namespace Project.ItemSystem
{
    public class QualityEditor : EditorWindow
    {

        QualityList QualityDB;
        string jsonString;
        string PATH;
        bool viewDetail;
        Quality tempQuality;

        // Use this for initialization
        [MenuItem("Item System/Quality Editor")]
        public static void Init()
        {
            QualityEditor window = EditorWindow.GetWindow<QualityEditor>();
            window.minSize = new Vector2(400, 300);
            window.titleContent.text = "Quality Editor";
            window.Show();
        }

        void OnGUI()
        {
            if (PATH == null)
                PATH = Application.streamingAssetsPath + "/Item System/JSON/qualitylist.json";


            if (!File.Exists(PATH))
            {
                createJson();
            }

            if (jsonString == null || jsonString == "")
            {
                getJson();
            }

            present();

        }

        private void present()
        {
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            if (QualityDB.Length() > 0 && viewDetail == false)
            {
                foreach (Quality q in QualityDB.qualityList)
                {
                    if (GUILayout.Button(q.name))
                    {
                        tempQuality = q;
                        viewDetail = true;
                    }
                }
            }
            else if (viewDetail)
            {
                tempQuality.name = GUILayout.TextField("Name - ", tempQuality.name);
                tempQuality.border = (Sprite)EditorGUILayout.ObjectField("Sprite - ", tempQuality.border, Type.GetType("Sprite"), true);

            }
            else
            {
                if (GUILayout.Button("No Qualities Add one"))
                {
                    tempQuality = new Quality();
                    viewDetail = true;
                }
            }
            GUILayout.BeginHorizontal();
            GUILayout.EndVertical();
        }

        void createJson()
        {
            QualityDB = new QualityList();
            jsonString = JsonUtility.ToJson(QualityDB, true);
            Debug.Log(jsonString);
            File.WriteAllText(PATH, jsonString);

            //get the json again and set the QualityDB just to make sure
            QualityDB = JsonUtility.FromJson<QualityList>(jsonString);
        }

        void getJson()
        {
            PATH = Application.streamingAssetsPath + "/Item System/JSON/weaponlist.json";

            jsonString = File.ReadAllText(PATH);

            QualityDB = JsonUtility.FromJson<QualityList>(jsonString);
        }

        void updateJson()
        {
            jsonString = JsonUtility.ToJson(QualityDB, true);
            File.WriteAllText(PATH, jsonString);
            QualityDB = JsonUtility.FromJson<QualityList>(jsonString);
        }
    }
}