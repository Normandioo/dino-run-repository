using System.Linq;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
     [SerializeField] GameObject _rock1;
    [SerializeField] GameObject _rock2;
    [SerializeField] GameObject _tree1;
    [SerializeField] GameObject _tree2;

    public float SpawnRate = 2f;

    public GameObject[] obstacles;

    void Awake()
    {
        obstacles = new GameObject[] { _rock1, _rock2, _tree1, _tree2 };
    }
    
    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), SpawnRate, SpawnRate);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        int index = Random.Range(0, obstacles.Length);
    
        Instantiate(obstacles[index], transform.position, transform.rotation);
    }
}


