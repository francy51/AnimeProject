
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
        float[,] tiles;

        TerrainData terrainData;

        [SerializeField]
        SplatClass[] splats;

        GameObject world;

        [SerializeField]
        GameObject playerPrefab;
        [SerializeField]
        GameObject cameraPrefab;

        public World(int height, int width, int smooth)
        {
            Height = height;
            Width = width;
            smoothAmount = smooth;
        }

        private void Start()
        {
            MakeDungeon();
        }

        public void MakeDungeon()
        {
            createNoise();
            createTerrain();
            colorWorld();
            spawnplayer();
        }

        private void colorWorld()
        {
            SplatPrototype[] splatPrototypes = new SplatPrototype[splats.Length];

            for (int i = 0; i < splats.Length; i++)
            {
                splatPrototypes[i] = new SplatPrototype();
                splatPrototypes[i].texture = splats[i].Texture;
                splatPrototypes[i].tileSize = new Vector2(splats[i].SplatSize, splats[i].SplatSize);
            }

            terrainData.splatPrototypes = splatPrototypes;
        }

        private void spawnplayer()
        {
            bool spawning = true;
            while (spawning)
            {
                int x = Random.Range(2, Width - 2);
                int y = Random.Range(2, Height - 2);
                if (tiles[x, y] == 0)
                {
                    Instantiate(playerPrefab, new Vector3(x, 0, y), Quaternion.identity);
                    Instantiate(cameraPrefab, new Vector3(x, 0, y), Quaternion.identity);
                    spawning = false;
                }
            }
        }


        private void createTerrain()
        {

            terrainData = new TerrainData();

           

            terrainData.size = new Vector3(Width, 20, Height);
            // "Base Texture Resolution": "Resolution of the composite texture used on the terrain when viewed from a distance greater than the Basemap Distance"
            // AFAIK, this doesn't affect the terrain mesh -- only how the terrain texture (i.e. Splats) are rendered
            terrainData.baseMapResolution = 128;

            // "Detail Resolution" and "Detail Resolution Per Patch"
            // (used for Details -- i.e. grass/flowers/etc...)
            terrainData.SetDetailResolution(1024, 32);
            // Handles height map resulation
            // AFAIK defines the size of teh 2 dimensional array holding height data
            terrainData.heightmapResolution = 129;
            terrainData.SetHeights(0, 0, tiles);
        

            if (world == null)
            {
                world = new GameObject();
                world = Terrain.CreateTerrainGameObject(terrainData);
                TerrainCollider collider = world.GetComponent<TerrainCollider>();
                collider.terrainData = terrainData;
            }

        }

        private void CreateHeightMap(int[,] tiles, TerrainData terData)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {

                }
            }
        }

        private void createNoise()
        {
            tiles = new float[Width, Height];
            createWalls();
            for (int x = 1; x < Width - 1; x++)
            {
                for (int y = 1; y < Height - 1; y++)
                {
                    if (Random.Range(0, 100) > AliveChance)
                    {
                        tiles[x, y] = 1;
                    }
                    else
                        tiles[x, y] = 0;
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

        private void createWalls()
        {
            for (int x = 0; x < Width; x++)
            {
                tiles[x, 0] = 1;
                tiles[x, Height - 1] = 1;

            }

            for (int y = 0; y < Height; y++)
            {
                tiles[0, y] = 1;
                tiles[Width - 1, y] = 1;
            }
        }

        private void smoothNoise()
        {
            for (int x = 1; x < Width - 1; x++)
            {
                for (int y = 1; y < Height - 1; y++)
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

        //Might not need tot create a texture for height map
        //private Texture2D CreateHeightMap(int[,] tileMap)
        //{
        //    Texture2D heightMap = new Texture2D(Width, Height);
        //    for (int x = 0; x < Width; x++)
        //    {
        //        for (int y = 0; y < Height; y++)
        //        {
        //            if (tileMap[x, y] == 1)
        //            {
        //                heightMap.SetPixel(x, y, Color.black);
        //            }
        //            else
        //                heightMap.SetPixel(x, y, Color.white);
        //        }
        //    }
        //    return heightMap;
        //}

    }
}