using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] public GameObject[] Cube_PreFabs;
    [SerializeField] Score score;
    public int cube_Random_Index;
    private Vector3 startPosition;
    private CubeMove cube;
    private bool isSpawn;
    private float delay = 0.3f;
    private void Awake()
    {
        startPosition = transform.position;
        Spawn_CubePrefab();
    }
    private void Update()
    {
        if (isSpawn)
        {
            return;
        }
        if (!cube.enabled)
        {
            Spawn_CubePrefab();
        }
    }
    public async void Spawn_CubePrefab()
    {
        isSpawn = true;
        cube_Random_Index = Random.Range(0, 10);
        await Task.Delay(System.TimeSpan.FromSeconds(delay));
        cube = Instantiate(Cube_PreFabs[cube_Random_Index], startPosition, Quaternion.identity).GetComponent<CubeMove>();
        cube.SetCubeManager(this);
        cube.SetScore(score);
        cube.gameObject.SetActive(true);
        isSpawn = false;
    }
    //public void Combine_Cubes()
    //{
    //    cube = Instantiate(Cube_PreFabs[cube_Random_Index + 1], cube.transform.position, Quaternion.identity).GetComponent<CubeMove>();
    //    cube.gameObject.SetActive(true);
    //}
}
