using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseEntity : MonoBehaviour
{
    protected Rigidbody2D rb;

    [field:SerializeField] public string name { get; protected set; }
    [field: SerializeField] protected BaseEntitySC baseEntity;
    [Header("Movement")]
    [SerializeField] protected bool canMove = false;
    [SerializeField] protected bool canJump = false;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
}
