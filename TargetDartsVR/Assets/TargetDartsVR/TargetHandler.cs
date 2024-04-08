using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetHandler : MonoBehaviour
{
    public GameObject scoreboard;
    private ScoreboardHandler sbh;

    public bool should_move = false;
    private float move_timer = 0f;

    private float inner_bull_radius = 0.02f;
    private float outer_bull_radius = 0.046f;
    private float inner_ring_start_radius = 0.193f;
    private float inner_ring_end_radius = 0.22f;
    private float outer_ring_start_radius = 0.335f;
    private float outer_ring_end_radius = 0.36f;

    private int[] mapping = {20, 5, 12, 9, 14, 11, 8, 16, 7, 19, 3, 17, 2, 15, 10, 6, 13, 4, 18, 1};
    public Vector3 default_target_position;

    void Start()
    {
        default_target_position = transform.position;
        sbh = scoreboard.GetComponent<ScoreboardHandler>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit");
        if (other.gameObject.CompareTag("DartPoint"))
        {

            Rigidbody drb =  other.transform.parent.GetComponent<Rigidbody>();
            drb.isKinematic = true;
            drb.useGravity = false;
            other.enabled = false;
            other.transform.parent.transform.SetParent(transform, true);;
            drb.velocity = Vector3.zero;
            //other.transform.position += new Vector3(0f, 0f, -1f);

            Vector3 pos_dart = other.transform.position;
            Vector3 pos_target = gameObject.transform.position;

            pos_dart -= pos_target; //gets relative position of dart to target
            float distance_to_center = (float) Math.Sqrt(Math.Pow(pos_dart.x, 2) + Math.Pow(pos_dart.y, 2));
            float argument = ((float) Math.Atan2(pos_dart.y, pos_dart.x) + 2f * (float)Math.PI) % (2f * (float)Math.PI);// - (4*(float)Math.PI/10f);
            argument = (argument - (9f/20f*(float)Math.PI) + 2f * (float)Math.PI)  % (2f * (float)Math.PI);

            int zone_nb = (int) (argument / ((float)Math.PI/10f));
            int zone = mapping[zone_nb];

            if (distance_to_center < inner_bull_radius) 
            { 
                Debug.Log("Bullseye inner"); 
                sbh.AddScore(50);
            }
            else if (distance_to_center < outer_bull_radius) 
            { 
                Debug.Log("Bullseye outer"); 
                sbh.AddScore(25);
            }
            else if (distance_to_center >= inner_ring_start_radius && distance_to_center <= inner_ring_end_radius) 
            { 
                Debug.Log("Inner ring"); 
                sbh.AddScore(3 * zone);
            }
            else if (distance_to_center >= outer_ring_start_radius && distance_to_center <= outer_ring_end_radius) 
            { 
                Debug.Log("Outer ring"); 
                sbh.AddScore(2 * zone);
            }
            else if (distance_to_center <= outer_ring_end_radius) 
            { 
                Debug.Log("Zone"); 
                sbh.AddScore(1 * zone);
            }
            else { Debug.Log("Miss"); }

            //Debug.Log(argument * 180f / (float) Math.PI);
            Debug.Log(zone);
            
            //sbh.AddScore(1);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DartPoint"))
        {
            Rigidbody drb =  other.transform.parent.GetComponent<Rigidbody>();
            other.enabled = true;
            drb.isKinematic = false;
            drb.useGravity = true;
        }
        //Debug.Log("End collision");
    }

    void Update()
    {
        if (should_move) 
        {
            move_timer += Time.deltaTime;
            transform.position = (float)Math.Sin(move_timer) * Vector3.left + default_target_position;
        }
    }

    // public void RegisterHitOn(string collider_name) 
    // {
    //     if (collider_name.StartsWith("Long") || collider_name.StartsWith("Thick")) 
    //     {
    //         sbh.AddScore(1 * Convert.ToInt32(collider_name.Substring(collider_name.Length - 2)));
    //     }
    //     else if (collider_name.StartsWith("Outer")) 
    //     {
    //         sbh.AddScore(2 * Convert.ToInt32(collider_name.Substring(collider_name.Length - 2)));
    //     }
    //     else if (collider_name.StartsWith("Inner")) 
    //     {
    //         sbh.AddScore(3 * Convert.ToInt32(collider_name.Substring(collider_name.Length - 2)));
    //     }
    //     else if (collider_name == "BullseyeOuter") { sbh.AddScore(25); }
    //     else if (collider_name == "Bullseye") { sbh.AddScore(50); }
    // }
}
