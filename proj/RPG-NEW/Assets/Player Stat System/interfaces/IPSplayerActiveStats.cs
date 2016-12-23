using UnityEngine;
using System.Collections;

namespace Project.StatSystem
{
    public interface IPSplayerActiveStats
    {
        float Speed { get; set; }
        int Strength { get; set; }
        int Intelligence { get; set; }
        int Armor { get; set; }
        int Shield { get; set; }
        int maxHealth { get; set; }
        int curHealth { get; set; }
        int maxDodges { get; set; }
        int curDodges { get; set; }
        float DodgeRegen { get; set; }
        float HealthRegen { get; set; }
        float AttackSpeed { get; set; }


    }
}

