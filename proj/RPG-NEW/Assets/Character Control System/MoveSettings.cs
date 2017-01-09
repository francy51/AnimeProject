using UnityEngine;
using System.Collections;


namespace Project.CharacterControl
{
    [System.Serializable]
    public class MoveSettings
    {
        public int MoveState = 0;
        public float ForwardVel = 12;
        public float JumpVel = .75f;
        public float RotateVel = 100;
        public float DistToGround = 1f;
        public LayerMask Ground;

    }
}