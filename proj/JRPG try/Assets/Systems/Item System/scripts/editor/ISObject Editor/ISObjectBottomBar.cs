using UnityEngine;
using System.Collections;

namespace Project.ItemSystem.Editor {
	public partial class ISObjectEditor  {

		void BotBar(){
			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth (true));
			GUILayout.Label ("TEST");
			GUILayout.EndHorizontal ();
		}
	}
}