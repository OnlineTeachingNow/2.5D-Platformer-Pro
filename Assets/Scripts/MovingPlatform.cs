using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform _pointA, _pointB;
    [SerializeField] float _speed = 5;
    Transform _target;
    void Start()
    {
        _target = _pointB;
    }
    void FixedUpdate() //Fixed update is the only way to guarantee the smooth movement of the player when on the moving platform.
        //Update by itself results in a lot of jittering that eventually knocks the player off of the platform completely. 
    {
        if (Vector3.Distance(this.transform.position, _pointB.position) < 0.01) //If the platform reaches within a certain distance to the waypoint, 
            //the target destination changes to the other waypoint.
        {
            _target = _pointA; 
        }
        else if (Vector3.Distance(this.transform.position, _pointA.position) < 0.01) //Same logic to toggle to the other waypoint.
        {
            _target = _pointB;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, _target.position, _speed * Time.deltaTime); //moves the platform towards the destination. 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform; //When the player collides with the second box collider of the platform, the player is childed to the moving platform and moves with the platform.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null; //When the player leaves the box collider of the moving platform, it is unchilded and free to move independently of the platform.
        }
    }
}
