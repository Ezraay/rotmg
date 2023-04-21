using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Entity player;
    private Camera camera;
    
    void Awake()
    {
        this.camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = this.camera.ScreenToWorldPoint(Input.mousePosition) - this.player.transform.position;
            float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg - 90; 
            this.player.Attack(angle);
        }
    }
}
