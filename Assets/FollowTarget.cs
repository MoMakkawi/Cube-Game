using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Target.position + Offset;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
