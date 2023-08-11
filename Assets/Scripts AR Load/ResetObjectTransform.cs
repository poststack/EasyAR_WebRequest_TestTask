using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjectTransform : MonoBehaviour
{
	public void Reset()
    {
	    transform.localPosition = Vector3.zero;
	    transform.localRotation = Quaternion.identity;
	    transform.localScale = Vector3.one;
    }

}
