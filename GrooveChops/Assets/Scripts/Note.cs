using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveNote();
    }

    void MoveNote()
    {
        Vector3 newPos = transform.position;
        newPos.z -= NoteManager.Instance.speed * Time.deltaTime;
        transform.position = newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitLine"))
        {
            AudioManager.Instance.timerOn = false;
            Destroy(gameObject);
        }
    }
}
