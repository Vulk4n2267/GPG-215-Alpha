using UnityEngine;

[ExecuteAlways]
public class CopyPosValues : MonoBehaviour
{
    [SerializeField] private Transform spawnPointTransform;

    private void OnValidate()
    {
        SnapPos();
    }
    private void Update()
    {
        SnapPos();
    }

    public void SnapPos()
    {
        transform.position = new Vector3(spawnPointTransform.position.x, spawnPointTransform.position.y, transform.position.z);
        transform.rotation = spawnPointTransform.rotation;
    }
}
