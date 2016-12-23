using UnityEngine;
using System.Collections;

namespace Project.ItemSystem
{
    public interface IISObject
    {
        string name { get; set; }
        int weight { get; set; }
        Sprite icon { get; set; }
        Quality quality { get; set; }

    }

}