using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Project.ItemSystem.Editor {
	public partial class ISQualityDataEditor : EditorWindow {

		ISQualityDatabase QualDB;
		ISQuality selectedItem;
		Texture2D selectedTexture;
		Vector2 _srollPos;

		const int SPRITE_BTN_SIZE = 92;
		const string DATABASE_PATH = @"Assets/Systems/Item System/scripts/database/Actual Database/ISQUALITYDATABASE";

		[MenuItem("Editors/databases/quality editor")]
		public static void init(){

			ISQualityDataEditor window = EditorWindow.GetWindow<ISQualityDataEditor> ();
			window.minSize = new Vector2 (400, 300);
			window.title = "Quality Database";
			window.Show ();
		
		}

		void OnEnable(){
			QualDB = AssetDatabase.LoadAssetAtPath (DATABASE_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;
			if(QualDB == null){
				QualDB = ScriptableObject.CreateInstance<ISQualityDatabase> ();
				AssetDatabase.CreateAsset (QualDB,DATABASE_PATH);
				AssetDatabase.SaveAssets ();
				AssetDatabase.Refresh ();
			}
			selectedItem = new ISQuality();
		}

		void OnGUI(){
			AddQualityToDatabase ();
		}


		void AddQualityToDatabase(){

			//name
			selectedItem.QName = EditorGUILayout.TextField(selectedItem.QName);
			//icon
			if (selectedItem.QIcon)
				selectedTexture = selectedItem.QIcon.texture;
			else
				selectedTexture = null;

			if(GUILayout.Button (selectedTexture,GUILayout.Width(SPRITE_BTN_SIZE),GUILayout.Height(SPRITE_BTN_SIZE))){

				int controlerID = EditorGUIUtility.GetControlID (FocusType.Passive);
				EditorGUIUtility.ShowObjectPicker<Sprite> (null, true, null, controlerID);
			}

			string commanName = Event.current.commandName;
			if (commanName == "ObjectSelectorUpdated") {
				selectedItem.QIcon = (Sprite)EditorGUIUtility.GetObjectPickerObject ();
				Repaint ();
			}
				
			if (GUILayout.Button ("Save")) {
				if (selectedItem == null)
					return;

				if (selectedItem.QName == "")
					return;

				QualDB.Database.Add (selectedItem);

				selectedItem = new ISQuality();
			}

		}
	}
}