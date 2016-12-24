using UnityEngine;
using System.Collections;

namespace Project.StatSystem
{
    public interface IPSplayerAvatar
    {

        string Name { get; set; }
        GameObject Prefab { get; set; }

    }
}
