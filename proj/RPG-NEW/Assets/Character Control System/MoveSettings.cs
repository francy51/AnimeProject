using UnityEngine;
using System.Collections;


namespace Project.CharacterControl
{
    [System.Serializable]
    public class MoveSettings
    {
        public static int MoveState = 1;
        public float ForwardVel = 12;
        public float JumpVel = 15;
        public float RotateVel = 100;
        public float DistToGround = 0.1f;
        public LayerMask Ground;
        public MoveSettings()
        {
            Ground.value = 1;
        }

    }
}