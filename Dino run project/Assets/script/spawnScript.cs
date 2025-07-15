using System.Linq;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
     [SerializeField] GameObject _rock1;
    [SerializeField] GameObject _rock2;
    [SerializeField] GameObject _tree1;
    [SerializeField] GameObject _tree2;

    public float SpawnRate = 1f;

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
       int index = Random.Range(0, obstacles.Length); // índice aleatório
        Vector3 pos = transform.position;

        if (index > 1)
        {
            pos.y = -2.19f; // objetos 2 e 3 (índices 2,3)
        }
        else if (index == 1)
        {
            pos.y = -2.19f; // objetos 0 e 1
        }
        else if (index == 0)
        {
            pos.y = -2.75f;
        }

        Instantiate(obstacles[index], pos, transform.rotation);
    }
}


