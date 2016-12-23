using UnityEngine;
using System.Collections;

namespace Project.StatSystem
{
    public interface IPSplayerPassiveStats
    {

        float Charisma { get; set; }
        float Martial { get; set; }
        float Learning { get; set; }
        float Intrigue { get; set; }
        float Diplomacy { get; set; }
        float Stewardship { get; set; }
        int Prestige { get; set; }



    }
}
