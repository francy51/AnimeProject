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


	}
}