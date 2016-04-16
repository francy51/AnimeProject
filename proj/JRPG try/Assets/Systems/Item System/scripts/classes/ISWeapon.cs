using UnityEditor;
using System;
using UnityEngine;
using System.Collections;

namespace Project.ItemSystem {
	[Serializable]
	public class ISWeapon : ISObject, IISWeapon, IISDestructable, IISEquipable, IISPrefab {
		

		#region IISWeapon implementation

		[SerializeField] int _minDamage;
		[SerializeField] int _durability;
		[SerializeField] int _maxDurability;
		[SerializeField] GameObject _prefab;
		[SerializeField] ISEquipmentSlot _equipmentslot;

		public ISWeapon(){
			_equipmentslot = new ISEquipmentSlot ();
				
		}


		public ISWeapon(int durability , int maxDurability , ISEquipmentSlot equipmentSlot, GameObject prefab){
			_durability = durability;
			_maxDurability = maxDurability;
			_equipmentslot = equipmentSlot;
			_prefab = prefab;
		}


		public int Attack ()
		{
			throw new System.NotImplementedException ();
		}

		public int MinDamage {
			get { return _minDamage;}
			set { _minDamage = value;}
		}

		#endregion

		#region IISDestructable implementation

		public void DurabilityDamage (int amount)
		{
			_durability -= amount;

			if (_durability < 0)
				_durability = 0;

			if (_durability == 0)
				Break();
		}

		public void Break ()
		{
			_durability = 0;
		}

		public void Repair ()
		{
			_maxDurability--;
			if (_maxDurability > 0)
				_durability = _maxDurability;
		}

		public int Durability {
			get { 	return _durability; }
		}

		public int MaxDurability {
			get { return _maxDurability; }
		}

		#endregion

		#region IISEquipable implementation

		public bool Equip ()
		{
			throw new NotImplementedException ();
		}

		public ISEquipmentSlot EquipmentSlot {
			get { return _equipmentslot; }
		}

		#endregion

		#region IISPrefab implementation

		public GameObject Prefab {
			get {	return _prefab;	}
		}

		#endregion

		public override void OnGUI(){

			EditorGUILayout.BeginVertical ();
			base.OnGUI ();
			_minDamage = EditorGUILayout.IntField ("Min Damage -", _minDamage);
			_durability = EditorGUILayout.IntField ("Durability -", _durability);
			_maxDurability = EditorGUILayout.IntField ("Max Durabilty -", _maxDurability);
			DisplayEquipmentSlot ();
			DisplayPrefab ();
			EditorGUILayout.EndVertical ();
		
		
		}


		public void DisplayEquipmentSlot(){
		
			GUILayout.Label("Equipment Slot");

		}


		public void DisplayPrefab(){
		
			GUILayout.Label ("Prefab");
		
		}

	}
}