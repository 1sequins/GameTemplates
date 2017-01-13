using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    private bool isPressed = false;
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public GameObject nextBall;

    private float waitingTime = 0.15f;

    float maxDragDistance = 2.0f;

    void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            }
            else
            {
                rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(waitingTime);
        GetComponent<SpringJoint2D>().enabled = false;

        this.enabled = false;

        yield return new WaitForSeconds(2f);
        if (nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
            EnemyScript.enemiesAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
