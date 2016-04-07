using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Project.ItemSystem.Editor {
	public partial class ISQualityDataEditor  {

		//list all stored qualities
		void ListView(){
			
			EditorGUILayout.BeginScrollView (_srollPos, GUILayout.ExpandHeight(true));
			EditorGUILayout.EndScrollView ();

		
		}



		void DisplayQualities (){

			for (int cnt = 0; cnt < QualDB.Database.Count; cnt++){
//				GUILayout.Label(QualDB.Database.);
			}

		}

	}
}
