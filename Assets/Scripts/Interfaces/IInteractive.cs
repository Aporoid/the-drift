using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Interface for elements the player interacts with via the interact key.
/// </summary>
public interface IInteractive
{
	string DisplayText { get; }
	void InteractWith();
}
