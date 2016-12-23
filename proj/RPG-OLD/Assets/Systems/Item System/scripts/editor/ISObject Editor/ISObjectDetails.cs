
using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {
		public partial class ISObjectEditor {

		ISWeapon TempWeapon;
		bool showWeaponDetails  = false;


		void ObjectDetails(){
		
			GUILayout.BeginVertical ("Box",GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true));
			GUILayout.BeginHorizontal ("Box",GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true));

				
			if (showWeaponDetails)
				DisplayNewWeapon ();
		

			GUILayout.EndHorizontal ();

			GUILayout.BeginHorizontal ("Box",GUILayout.ExpandWidth(true));
	
			DisplayButtons ();
			GUILayout.EndHorizontal ();	
			GUILayout.EndVertical ();
		
		}

		void DisplayNewWeapon(){
		
			TempWeapon.OnGUI ();

		

		
		}


		void DisplayButtons () {

			if (!showWeaponDetails) {
				if (GUILayout.Button ("Create Weapon")) {	
					TempWeapon = new ISWeapon ();

				
					showWeaponDetails = true;
				}
			} else {

				if (GUILayout.Button ("Save")) {
					Debug.Log ("weapon saved");
					ISQualityDatabase QDB;
					string DATABASE_PATH = @"Systems/Item System/scripts/database/Actual Database";
					string DATABASE_NAME = @"ISQUALITYDATABASE.asset";
						QDB = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_PATH, DATABASE_NAME);
					TempWeapon.ISQuality = QDB.Get (TempWeapon.qualitySelectedID);
					WeaponDB.Add (TempWeapon);
					showWeaponDetails = false;
					TempWeapon = null;
				}

				if (GUILayout.Button ("Cancel")) {
					Debug.Log ("weapon canceled");
					showWeaponDetails = false;
					TempWeapon = null;
				}

			}
		
		}
		
	}
}