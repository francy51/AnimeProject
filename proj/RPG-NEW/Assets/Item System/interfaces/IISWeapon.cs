using UnityEngine;
using System.Collections;

namespace Project.ItemSystem
{
    public interface IISWeapon :IISObject,IISPrefab
    {
        
        int damage { get; set; }
        float penetration { get; set; }
        string type { get; set; }
        void Attack();
        bool isRange { get; set; }
        float range { get; set; }


    }
}
