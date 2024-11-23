using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Data data;
    private Rigidbody rb;

    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
        rb.MovePosition(transform.position + movement * data.speed * Time.fixedDeltaTime);
    }

    private void Rotation()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.point.y < transform.position.y)
            {
                Vector3 hitPoint = hit.point;
                hitPoint.y = transform.position.y;
                transform.LookAt(hitPoint);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            data.HP -= 20;
            if(data.HP <= 0)
            {
                GameManager.Instance.Death();
            }
        }
    }
}
