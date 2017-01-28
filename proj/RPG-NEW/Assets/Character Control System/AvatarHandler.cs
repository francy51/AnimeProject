using UnityEngine;
using Project.StatSystem;
using System.Collections;

namespace Project.CharacterControl
{
    public class AvatarHandler : MonoBehaviour
    {


        playerStats stats;

        // Use this for initialization
        void Start()
        {
            GameObject MAN = GameObject.Find("GlobalManagers");
            stats = MAN.GetComponent<playerStats>();

            HandlePrefab();


        }


        void HandlePrefab()
        {
            Instantiate(stats.Prefab, this.transform.position, Quaternion.identity, this.transform);
            CharacterControllerCustom CharacterControllerCust = GetComponent<CharacterControllerCustom>();            
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = CharacterControllerCust.Locomotion;
            Destroy(stats.Prefab);
            stats.Prefab = this.gameObject;
        }
    }
}