using UnityEngine;
using System.Collections;

public class ClippingDestroy : MonoBehaviour
{
    [SerializeField]
    Collider ColliderBox;
    [SerializeField]
    GameObject Cube;

	void OnCollisionEnter(Collision ColliderBox)
    {
        Destroy(Cube);
    }
}
