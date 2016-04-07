using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {

		public class ISQuality : IISQuality {
		//	_ = private variables
		[SerializeField]string _name;
		[SerializeField]Sprite _icon;

		#region IISQuality implementation

		public string QName {

			get {return _name; }
			set {_name = value;}
		}

		public Sprite QIcon {
			get {return _icon; }
			set {_icon = value;}
		}

		public ISQuality(){
			_name = "common";
			_icon = new Sprite ();
		}
		#endregion



	}
}