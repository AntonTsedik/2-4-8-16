using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private float leftSide = -1.9f;
    private float rightSide = 1.9f;
    private float moveSpeed = 700f;
    private Touch touch;
    private float speedModifier;
    [SerializeField] private Rigidbody rb;
    private CubeManager cubeManager;
    public int Number;
    public int Index;
    private Score score;
    private bool collide;
    private void Start()
    {
        speedModifier = 0.01f;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                rb.AddForce(moveSpeed * Vector3.forward);
                this.enabled = false;
            }
        }

        if (gameObject.transform.position.x < leftSide)
        {
            transform.position = new Vector3(leftSide, transform.position.y, transform.position.z);
        }
        if (gameObject.transform.position.x > rightSide)
        {
            transform.position = new Vector3(rightSide, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == this.gameObject.tag)
        {
            var cm = collision.gameObject.GetComponent<CubeMove>();
            if (cm.collide)
            {
                return;
            }
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            var cubeMove = Instantiate(cubeManager.Cube_PreFabs[Index + 1], collision.contacts[0].point, Quaternion.identity).GetComponent<CubeMove>();
            cubeMove.SetCubeManager(cubeManager);
            cubeMove.gameObject.SetActive(true);
            cubeMove.rb.AddForce(moveSpeed / 5 * Vector3.up);
            cubeMove.enabled = false;
            collide = true;
            cubeMove.SetScore(score);
            score.addScore(Number);
        }
    }
    public void SetScore(Score _score)
    {
        this.score = _score;
    }
    public void SetCubeManager(CubeManager cube_Manager)
    {
        cubeManager = cube_Manager;
    }
}

