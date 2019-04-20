using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used to keep players in a set area until they find the next clue.
/// </summary>
public class ClueBoundaryController : MonoBehaviour
{
	public Text blockerText;
	public Collider firstBlocker;
}
