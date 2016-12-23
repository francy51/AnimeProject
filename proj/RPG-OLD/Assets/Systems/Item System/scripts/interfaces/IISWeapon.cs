using UnityEngine;
using System.Collections;


namespace Project.ItemSystem {
	public interface IISWeapon  {

		int MinDamage { get; set; }
		int Attack();



	}
}