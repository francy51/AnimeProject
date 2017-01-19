using UnityEngine;


namespace Project.DungeonGeneration
{
    public class World : MonoBehaviour
    {

        /* Almost finished with dungeon tiles placement generator
         * TODO: 
         *      Balance the dead and alive values (Maybe let them be changed based on Dungeon type) 
         *      Work on setting boarder to dungeon(Making sure that the player is congined to within the baord
         *      After the technical stuff is all done choose how to render the dungeon into a proper model
         *          eg. Use tiles and at each position load in a corresponding tile 
         *              Or create a mesh base on the values given (Watch sebastian Lagues) cave generation tutorial to see example 
         */
        public bool drawGizmos;
        public int Height;
        public int Width;
        public int smoothAmount;
        public int AliveChance = 70;
        public int TurnAlive;
        public int TurnDead;
        [SerializeField]
        int[,] tiles;


        public World(int height, int width, int smooth)
        {
            Height = height;
            Width = width;
            smoothAmount = smooth;
        }

        private void Start()
        {

            createNoise();

        }

        private void createNoise()
        {
            tiles = new int[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (x <= Width * 0.01f || x >= Width * 0.99f)
                    {
                        tiles[x, y] = 1;
                    }
                    else if (y <= Height * 0.01f || y >= Height * 0.99f)
                        tiles[x, y] = 1;
                    else
                    {
                        if (Random.Range(0, 100) > AliveChance)
                        {
                            tiles[x, y] = 1;
                        }
                        else
                            tiles[x, y] = 0;
                    }

                }
            }

            for (int i = 0; i < smoothAmount; i++)
            {
                smoothNoise();
            }
        }

        int NumberOfNeighbours(int posx, int posy)
        {
            int neighbours = 0;

            if (tiles[posx - 1, posy] == 1)
                neighbours++;
            if (tiles[posx + 1, posy] == 1)
                neighbours++;
            if (tiles[posx, posy - 1] == 1)
                neighbours++;
            if (tiles[posx, posy + 1] == 1)
                neighbours++;

            return neighbours;
        }

        private void smoothNoise()
        {
            for (int x = 1; x < Width - 1; x++)
            {
                for (int y = 1; y < Height - 1; y++)
                {
                    if (!(x < Width * 0.01f) || !(y < Height * 0.01f) || !(x > Width * 0.99f) || !(y > Height * 0.99f))
                    {

                        if (NumberOfNeighbours(x, y) >= TurnAlive)
                        {
                            tiles[x, y] = 1;
                        }
                        else if (NumberOfNeighbours(x, y) < TurnDead)
                        {
                            tiles[x, y] = 0;
                        }

                    }

                }
            }
        }

        private void OnDrawGizmos()
        {
            if (drawGizmos)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        if (tiles[x, y] == 1)
                        {
                            Gizmos.color = Color.black;
                        }
                        else if (tiles[x, y] == 0)
                            Gizmos.color = Color.white;
                        else
                            Gizmos.color = Color.red;

                        Gizmos.DrawCube(new Vector3(x, 0, y), new Vector3(1, 0, 1));
                    }

                }
            }

        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                smoothNoise();
            }
        }
    }
}