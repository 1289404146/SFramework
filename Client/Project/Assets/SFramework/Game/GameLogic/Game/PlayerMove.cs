﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMove:BaseMono
{
    //public float forward = 0;

    //private float speed = 3;
    //private Animator anim;
    //// Use this for initialization
    //void Start()
    //{
    //    anim = GetComponentInChildren<Animator>();
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0)
    //    {
    //        transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime, Space.World);

    //        transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));

    //        float res = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
    //        forward = res;
    //        anim.SetFloat("Forward", res);
    //    }
    //}
}
