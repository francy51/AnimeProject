
using UnityEngine;
using System.Collections;

namespace Project.ItemSystem.Editor {
		public partial class ISObjectEditor {

		ISWeapon TempWeapon;
		bool showWeaponDetails  = false;


		void ObjectDetails(){
		
			GUILayout.BeginVertical ("Box",GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true));
			GUILayout.BeginHorizontal ("Box",GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true));

			GUILayout.Label ("Detail View");
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
					Debug.Log ("created a weapon");
					TempWeapon = new ISWeapon ();
					showWeaponDetails = true;
				}
			} else {

				if (GUILayout.Button ("Save")) {
					Debug.Log ("weapon saved");
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