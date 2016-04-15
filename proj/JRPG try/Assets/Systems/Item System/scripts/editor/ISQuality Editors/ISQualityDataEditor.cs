using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Project.ItemSystem.Editor {
	public partial class ISQualityDataEditor : EditorWindow {

		ISQualityDatabase QualDB;
		ISQuality selectedItem;
		Texture2D selectedTexture;
		int selectedIndex = -1;
		Vector2 _scrollPos;


		const int SPRITE_BTN_SIZE = 92;
		const string DATABASE_FULL_PATH = @"Assets/Systems/Item System/scripts/database/Actual Database/ISQUALITYDATABASE.asset";
		const string DATABASE_PATH = @"Systems/Item System/scripts/database/Actual Database";
		const string DATABASE_NAME = @"ISQUALITYDATABASE.asset";

		[MenuItem("Editors/databases/quality editor")]
		public static void init(){

			ISQualityDataEditor window = EditorWindow.GetWindow<ISQualityDataEditor> ();
			window.minSize = new Vector2 (400, 300);
			window.titleContent.text = "Quality Database";
			window.Show ();
		
		}

		void OnEnable(){
			if(QualDB == null)
			QualDB = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_PATH, DATABASE_NAME);
	//		selectedItem = new ISQuality();
		}

		void OnGUI(){
			DatabaseInfo ();
			ListView ();
			AddItem ();
		}

		void AddItem(){
		
			if (GUILayout.Button ("ADD"))
				QualDB.Add (new ISQuality ());
		
		}

	}
}