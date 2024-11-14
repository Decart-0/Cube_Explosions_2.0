using UnityEngine;

public class CreatorCube : MonoBehaviour
{
    public Cube CreateCube(Vector3 spawnPoint, Cube prefab)
    {
        return Instantiate(prefab, spawnPoint, Quaternion.identity);
    }
}