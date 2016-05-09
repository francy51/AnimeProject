using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {
	public partial class ISObjectEditor {

		void TopBar(){

			GUILayout.BeginHorizontal ("Box",GUILayout.ExpandWidth(true));
			WeaponTab ();
			ArmorTab ();
			GUILayout.Button ("Potions");
			AboutTab ();
			GUILayout.EndHorizontal();
					
		}

		void WeaponTab(){
			GUILayout.Button ("Weapons");
		}

		void ArmorTab(){
			GUILayout.Button ("Armor");
		}

		void AboutTab(){
			GUILayout.Button ("About");
		}

	}
}