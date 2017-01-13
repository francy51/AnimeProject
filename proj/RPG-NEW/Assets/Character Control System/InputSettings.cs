using UnityEngine;
using System.Collections;


namespace Project.CharacterControl
{
    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string TurnAxis = "Turn";
        public string HorizAxis = "Horizontal";
        public string VertAxis = "Vertical";
        public string JumpAxis = "Jump";
    }
}