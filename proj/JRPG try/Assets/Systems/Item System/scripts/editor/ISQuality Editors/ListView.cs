using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Project.ItemSystem.Editor {
	public partial class ISQualityDataEditor  {

		//list all stored qualities
		void ListView(){
			
			EditorGUILayout.BeginScrollView (_srollPos, GUILayout.ExpandHeight(true));
			DisplayQualities ();
			EditorGUILayout.EndScrollView ();

		
		}



		void DisplayQualities (){

			for (int cnt = 0; cnt < QualDB.Count; cnt++){
				GUILayout.Label(QualDB.Get(cnt).QName);
				GUILayout.Button ("x");
			}

		}

	}
}
