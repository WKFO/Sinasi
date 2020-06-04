using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveandStuff : MonoBehaviour
{

    public float speed;

    public float xMin, xMax, zMin, zMax, yMin, yMax;
    public float tilt;

    public float groundLevel;

    public float shiftRate;

    public float jumpSpeed;

    public float primaryFireRate;
    private float nextFire;

    public GameObject shot;
    public Transform shotSpawn;

    void Update()
    {
        //Primary fire - requires no mana
        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)
        {
            nextFire = Time.time + primaryFireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && (transform.position.y < -0.6))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
        }

        Vector3 correctpos = new Vector3(transform.position.x, yMin, 0.0f);

        if (transform.position.y < yMin)
        {
            transform.position = correctpos;
            GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveHorizontal = moveHorizontal * shiftRate;
        }
        //transform.Translate(moveHorizontal * speed, 0.0f, 0.0f, Space.World); -- DON'T USE THIS

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + moveHorizontal * speed, xMin, xMax);
        pos.y = Mathf.Clamp(pos.y, yMin, yMax);
        pos.z = Mathf.Clamp(pos.z, zMin, zMax);
        transform.position = pos;

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, moveHorizontal * -tilt);
    }
}
