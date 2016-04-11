using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {
	public class ISEquipmentSlot : IISEquipmentSlot {

		[SerializeField]string _slotName;

		[SerializeField]Sprite _slotIcon;


		public Sprite SlotIcon {
			get {return _slotIcon;}
			set {_slotIcon = value;}
		}

		public string SlotName {
			get { return _slotName;}
			set {_slotName = value;}
		}




	}
}