using UnityEditor;
using UnityEngine;
using System.Linq; //use for elementAT
using System.Collections;
using System.Collections.Generic;

namespace Project.ItemSystem {
	public class ISQualityDatabase : ScriptableObject {

		 List<ISQuality> Database = new List<ISQuality> ();


		public void Add(ISQuality item){
		
			Database.Add (item);
			EditorUtility.SetDirty (this);
		}

		public void Insert(int index, ISQuality item){
		
			Database.Insert (index, item);
			EditorUtility.SetDirty (this);

		}

		public void Remove(ISQuality item){

			Database.Remove (item);
			EditorUtility.SetDirty (this);

		}

		public void RemoveAt(int index){

			Database.RemoveAt (index);
			EditorUtility.SetDirty (this);

		}

		public int Count{

			get {return Database.Count;}
		
		}

		public ISQuality Get(int index){
		
			return Database.ElementAt (index);

		}

		public void Replace(int index, ISQuality item){
		
			Database[index] = item;
			EditorUtility.SetDirty (this);
		
		}


	}
}