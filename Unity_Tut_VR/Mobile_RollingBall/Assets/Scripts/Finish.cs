using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Finish : MonoBehaviour
{
    [HideInInspector]
    private Vector3 startPos = new Vector3(0, 0, 0);
    [HideInInspector]
    private GameObject player = null;

    // Use this for initialization
    void Start()
    {
        player   = GameObject.Find("Player");
        if (player == null)
        {
            Debug.Log("Player not found!");
        }
        else
        {
            startPos = player.transform.position;
            Debug.Log(startPos);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject == player)
        {
            Debug.Log("You Win!");
            player.transform.position = startPos;
        }
    }
}
