using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {
	public interface IISStackable  {

		int MaxStack {get;}
		int Stack (int amount);


	}
}