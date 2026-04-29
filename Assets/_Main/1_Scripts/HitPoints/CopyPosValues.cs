using UnityEngine;

[ExecuteAlways]
public class CopyPosValues : MonoBehaviour
{
    [SerializeField] private Transform spawnPointTransform;

    private void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.SetPosition(0, transform.position + new Vector3(0,0,-100));
        line.SetPosition(1, spawnPointTransform.position + new Vector3(0,0,1000));
    }
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
