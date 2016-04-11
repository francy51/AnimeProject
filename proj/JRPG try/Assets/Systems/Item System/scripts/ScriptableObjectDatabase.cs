using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Project {
	public class ScriptableObjectDatabase<T> : ScriptableObject where T: class {

		[SerializeField] List<T> database = new List<T>();	

		public void Add(T item){

			database.Add (item);
			EditorUtility.SetDirty (this);
		}

		public void Insert(int index, T item){

			database.Insert (index, item);
			EditorUtility.SetDirty (this);

		}

		public void Remove(T item){

			database.Remove (item);
			EditorUtility.SetDirty (this);

		}

		public void RemoveAt(int index){

			database.RemoveAt (index);
			EditorUtility.SetDirty (this);

		}

		public int Count{

			get {return database.Count;}

		}

		public T Get(int index){

			return database.ElementAt (index);

		}

		public void Replace(int index, T item){

			database[index] = item;
			EditorUtility.SetDirty (this);

		}


		public U GetDatabase<U>(string dbPath,string dbName) where U:ScriptableObject{

			string dbFullPath = @"Assets"

			

			database = AssetDatabase.LoadAssetAtPath (DATABASE_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;
			if(database == null){
				database = ScriptableObject.CreateInstance<T> ();
				AssetDatabase.CreateAsset (database,DATABASE_PATH);
				AssetDatabase.SaveAssets ();
				AssetDatabase.Refresh ();
			}
			
		}

	}
}