using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Project.ItemSystem.Editor {
	public partial class ISQualityDataEditor  {

		//list all stored qualities
		void ListView(){
			
			_scrollPos = EditorGUILayout.BeginScrollView (_scrollPos, GUILayout.ExpandHeight(true));
			DisplayQualities ();
			EditorGUILayout.EndScrollView ();

		
		}



		void DisplayQualities (){
			
		
			for (int cnt = 0; cnt < QualDB.Count; cnt++) {


				//display enty number
				GUILayout.Label ("Entry number " + cnt);



				//display Name in list
				GUILayout.Label ("Quality Name: ");

				QualDB.Get (cnt).QName = GUILayout.TextArea (QualDB.Get (cnt).QName);




				//Display icons in list


				GUILayout.Label ("Quality Icon: ");

				if (QualDB.Get (cnt).QIcon)
					selectedTexture = QualDB.Get(cnt).QIcon.texture;
				else
					selectedTexture = null;

				if (GUILayout.Button (selectedTexture, GUILayout.Width (SPRITE_BTN_SIZE), GUILayout.Height (SPRITE_BTN_SIZE))) {
						
					int controlerID = EditorGUIUtility.GetControlID (FocusType.Passive);
					EditorGUIUtility.ShowObjectPicker<Sprite> (null, true, null, controlerID);
					selectedIndex = cnt;
				}
			

				string commanName = Event.current.commandName;
				if (commanName == "ObjectSelectorUpdated") {

					if (selectedIndex == -1)
						return;

					QualDB.Get(selectedIndex).QIcon = (Sprite)EditorGUIUtility.GetObjectPickerObject ();
					selectedIndex = -1;
					Repaint ();

				}
					
				//Delete Button
				if (GUILayout.Button ("DELETE")) {
					QualDB.RemoveAt (cnt);
				}	
			}
		}

		public void DatabaseInfo(){
			GUILayout.Label ("The Database has " + QualDB.Count +  " entries");
		}
	}
}