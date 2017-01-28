
using UnityEngine;

namespace Project.DungeonGeneration
{
    [System.Serializable]
    public class SplatClass : MonoBehaviour {

        [SerializeField]
        Texture2D texture;
        [SerializeField]
        int splatSize;

        public Texture2D Texture
        {
            get
            {
                return texture;
            }

            set
            {
                texture = value;
            }
        }

        public int SplatSize
        {
            get
            {
                return splatSize;
            }

            set
            {
                splatSize = value;
            }
        }
    }
}