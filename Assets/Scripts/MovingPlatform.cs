using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform _pointA, _pointB;
    [SerializeField] float _speed = 5;
    Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        _target = _pointB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, _pointB.position) < 0.01)
        {
            _target = _pointA;
        }
        else if (Vector3.Distance(this.transform.position, _pointA.position) < 0.01)
        {
            _target = _pointB;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
