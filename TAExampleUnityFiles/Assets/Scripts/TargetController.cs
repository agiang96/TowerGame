using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetController : MonoBehaviour {

    [SerializeField]
    private Text _hitCounterUI;
    private int _hitCounter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cannonball")
            _hitCounter++;
        _hitCounterUI.text = _hitCounter + "";

    }
}
