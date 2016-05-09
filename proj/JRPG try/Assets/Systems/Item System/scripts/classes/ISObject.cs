using UnityEditor;
using System;
using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {
	[Serializable]
	public class ISObject : IISObject {
		[SerializeField]Sprite _icon;
		[SerializeField]string _name;
		[SerializeField]int _goldValue;
		[SerializeField]int _powerValue;
		[SerializeField]int _weight;
		[SerializeField]ISQuality _quality;



		#region IISObject implementation

		public string ISName {
			get { return _name; }
			set { _name = value;}
		}
		public int ISGoldValue {
			get { return _goldValue; }
			set { _goldValue = value;}
		}

		public int ISPowerValue {
			get { return _powerValue; }
			set { _powerValue = value;}
		}

		public Sprite ISIcon {
			get { return _icon; }
			set { _icon = value;}
		}

		public int ISWeight {
			get { return _weight; }
			set { _weight = value;}
		}

		public ISQuality ISQuality {
			get { return _quality; }
			set { _quality = value;}
		}

		#endregion


		//ONGUI Place in other class further ON
		ISQualityDatabase QDB;
		int qualitySelectedIndex = 0;
		public int qualitySelectedID {
			get{ return qualitySelectedIndex;}
		}	
		string[] Option;	
	

		public virtual void OnGUI(){

			_name = EditorGUILayout.TextField ("Name - ", _name);
			_goldValue = EditorGUILayout.IntField ("Gold Value - " , _goldValue );
			_powerValue = EditorGUILayout.IntField ("Power Value - " , _powerValue );
			_weight = EditorGUILayout.IntField ("Weight - " , _weight );
			DisplayIcon ();
			DisplayQuality ();


		}

		public void DisplayIcon(){

			GUILayout.Label("Icon");

		}


		public ISObject(){

			 string DATABASE_PATH = @"Systems/Item System/scripts/database/Actual Database";
			 string DATABASE_NAME = @"ISQUALITYDATABASE.asset";
			if(QDB == null)
				QDB = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_PATH, DATABASE_NAME);

			Option = new string[QDB.Count];
			for(int cnt = 0; cnt < QDB.Count; cnt++){
				Option [cnt] = QDB.Get (cnt).QName;
			}


		}



		public void DisplayQuality(){
			
			GUILayout.Label ("Quality");
			qualitySelectedIndex = EditorGUILayout.Popup("Quality", qualitySelectedIndex,Option);

		}




	}
}