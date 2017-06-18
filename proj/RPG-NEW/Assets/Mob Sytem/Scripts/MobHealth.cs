using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : MonoBehaviour {

    public int maxHealth;
    public int curHealth;

    public void TakeDamage(int Damge)
    {
        curHealth -= Damge;
    }

}
