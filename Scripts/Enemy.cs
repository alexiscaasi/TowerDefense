using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
  public Path route;
  private Waypoint[] myPathThroughLife;
  public int coinWorth;
  public float health;
  public float speed = .25f;
  private int index = 0;
  private Vector3 nextWaypoint;
  private bool stop = false;

  public float rayLength;
  public LayerMask layermask;

  void Awake()
  {
    myPathThroughLife = route.path;
    transform.position = myPathThroughLife[index].transform.position;
    Recalculate();
  }

  void Update()
  {

    if (!stop)
    {
      if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < .1f)
      {
        index = index + 1;
        Recalculate();
      }


      Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
      transform.Translate(moveThisFrame);
    }

    // Raycast Implementation
    // if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
    //   RaycastHit hit;
    //   Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //   if(Physics.Raycast(ray, out hit, rayLength, layermask)) {
    //     Debug.Log(hit.collider.name);
    //     health -= 10;
    //     Debug.Log(health);
    //     if(health <= 0) {
    //       Destroy(gameObject);
    //     }
    //   }
    // }

    if(health <= 0) {
      Purse.coins += 10;
      Destroy(gameObject);
    }
  }

  void Recalculate()
  {
    if (index < myPathThroughLife.Length -1)
    {
      nextWaypoint = (myPathThroughLife[index + 1].transform.position - myPathThroughLife[index].transform.position).normalized;

    }
    else
    {
      stop = true;
    }
  }

  void OnMouseDown(){
    health -= 10;
  }
}
