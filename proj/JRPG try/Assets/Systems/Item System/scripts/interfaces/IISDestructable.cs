using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {
	public interface IISDestructable   {

	 	// durability 
		int Durability {get;}

		int MaxDurability{ get; }

		//taking damage
		void DurabilityDamage (int amount);

		void Brake();

		//repairing
		void Repair();

	}
}