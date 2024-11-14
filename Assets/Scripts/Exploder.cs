using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _maxForce;
    [SerializeField] private float _minForce;
    [SerializeField] private float _radius;

    public void ExplodeCube(Vector3 position, List<Rigidbody> cubes, float sizeCube)
    {
        if (cubes.Count == 0)
            cubes = GetExplodableCubes(position, sizeCube);

        foreach (Rigidbody explodableObject in cubes)
        {
            float distance = Vector3.Distance(position, explodableObject.position);
            Vector3 direction = (explodableObject.position - position).normalized;
            float explosionForce = Mathf.Clamp(_maxForce / (distance + 1), _minForce, _maxForce) * (1 / sizeCube);
            explodableObject.AddForce(direction * explosionForce, ForceMode.Impulse);
        }
    }

    private List<Rigidbody> GetExplodableCubes(Vector3 position, float sizeCube) 
    {
        Collider[] hits = Physics.OverlapSphere(position, _radius * (1 / sizeCube));
        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits) 
        {
            if (hit.attachedRigidbody != null) 
            { 
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}