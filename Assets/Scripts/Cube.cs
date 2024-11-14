using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]
public class Cube : MonoBehaviour
{
    [SerializeField] private SpawnerCube _spawn;
    [SerializeField] private Exploder _explosionCube;

    private Renderer _renderer;
    private Collider _collider;

    [field: SerializeField] public float ChanceSeparation { get; private set; }

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();
    }

    private void OnMouseDown()
    {
        List<Rigidbody> cubes = new List<Rigidbody>();

        if (ChanceSeparation > Random.value)
        {
            cubes = _spawn.SpawnCubes(this);
        }

        _explosionCube.ExplodeCube(transform.position, cubes, GetScale());
        Destroy(gameObject);
    }

    public void Init(float factorReductionSpawne, float factorReductionScale) 
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
        transform.localScale /= factorReductionScale;
        ChanceSeparation /= factorReductionSpawne;
    }

    public float GetScale() 
    {
       return _collider.bounds.size.magnitude;
    }
}