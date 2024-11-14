using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CreatorCube))]
public class SpawnerCube : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _factorReductionSpawne;
    [SerializeField] private float _factorReductionScale;

    private CreatorCube _creatorCube;

    private void Awake()
    {
        _creatorCube = GetComponent<CreatorCube>();
    }

    public List<Rigidbody> SpawnCubes(Cube prefab)
    {
        int minCubes = 2;
        int maxCubes = 6;
        int numeCubes = Random.Range(minCubes, maxCubes + 1);

        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        for (int i = 0; i < numeCubes; i++)
        {
            Cube cube = _creatorCube.CreateCube(GetRandomSpawnPoint(prefab.transform.position), prefab);

            cube.Init(_factorReductionSpawne, _factorReductionScale);
            rigidbodies.Add(cube.Rigidbody);
        }

        return rigidbodies;
    }

    private Vector3 GetRandomSpawnPoint(Vector3 transform)
    {
        float randomAngle = Random.Range(0f, 2 * Mathf.PI);
        float randomDistance = Random.Range(0f, _spawnRadius);
        float x = transform.x + Mathf.Cos(randomAngle) * randomDistance;
        float z = transform.z + Mathf.Sin(randomAngle) * randomDistance;

        return new Vector3(x, transform.y, z);
    }
}