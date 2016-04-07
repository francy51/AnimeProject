using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {
	public interface IISObject {


		//name
		string ISName {get; set;}
		//value-money
		int ISGoldValue { get; set;}
		//value-power
		int ISPowerValue { get; set;}
		//icon
		Sprite ISIcon {get; set;}
		//weight
		int ISWeight {get; set;}
		//quality
		ISQuality ISQuality {get;set;}




		//Other interfaces
		//equipable

		//Quest Item Flag

		//durability

		//durability damage

		//prefab(model)
	}
}