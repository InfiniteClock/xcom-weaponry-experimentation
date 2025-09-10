using UnityEngine;

public class LookAtObj : MonoBehaviour
{
    [SerializeField]
    float distance = 1f;
    
    GameObject target;

    private void Start()
    {
        target = Camera.main.gameObject;
    }
    private void Update()
    {
        transform.localPosition = (target.transform.position - transform.position).normalized * distance;
        transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
    }
}
