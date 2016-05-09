using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {
	public partial class ISObjectEditor : EditorWindow { 


		ISWeaponDatabase WeaponDB;
		ISQuality selectedItem;
		Texture2D selectedTexture;
		int selectedIndex = -1;

		const int SPRITE_BTN_SIZE = 92;
		const string DATABASE_FULL_PATH = (@"Assets/" + DATABASE_PATH + DATABASE_NAME);
		const string DATABASE_PATH = @"Systems/Item System/scripts/database/Actual Database";
		const string DATABASE_NAME = @"ISWEAPONDATABASE.asset";


		[MenuItem("Editors/databases/object editor")]
		public static void Init() {

			ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor> ();
			window.minSize = new Vector2 (400, 300);
			window.titleContent.text = "Object Database";
			window.Show ();
		
		}

		void OnEnable(){
			if(WeaponDB == null)
				WeaponDB = ISWeaponDatabase.GetDatabase<ISWeaponDatabase> (DATABASE_PATH, DATABASE_NAME);
		}


		void OnGUI(){
			TopBar ();
			GUILayout.BeginHorizontal ();
			ListView ();
			ObjectDetails ();
			GUILayout.EndHorizontal ();
			BotBar ();
		}	


	}
}