using UnityEngine;
using System.Collections;


namespace Project.ItemSystem {
		public interface IISEquipable  {

			ISEquipmentSlot EquipmentSlot { get;}
			bool Equip();
		}
}
