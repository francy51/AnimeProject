using UnityEngine;
using System.Collections;

namespace Project.DialogueSystem
{
    public interface IDSdialogue
    {
        GameObject objectTrigger { get; set; }
        string[] Dialogue { get; set; }


    }
}
