using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class WallContainer : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            print("pulse");
            var normal = col.GetContact(0).normal;
            print(normal);
            col.rigidbody.AddForce(normal * 1f, ForceMode2D.Impulse);
        }
    }
}