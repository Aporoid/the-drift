using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
	#region serializedfields
	[SerializeField]
	private Image ChurchIndicator;

	[SerializeField]
	private Image DockIndicator;

	[SerializeField]
	private Image ParkIndicator;

	[SerializeField]
	private Image BarnIndicator;

	[SerializeField]
	private Image AuctionhouseIndicator;

	[SerializeField]
	private Image GraveyardIndicator;

	[SerializeField]
	private Image CityhallIndicator;
	#endregion

	public bool isChurch;
	public bool isDock;
	public bool isPark;
	public bool isBarnyard;
	public bool isAuctionhouse;
	public bool isGraveyard;
	public bool isCityhall;

	private void Start()
	{
		ChurchIndicator.enabled = false;
		DockIndicator.enabled = false;
		ParkIndicator.enabled = false;
		BarnIndicator.enabled = false;
		AuctionhouseIndicator.enabled = false;
		GraveyardIndicator.enabled = false;
		CityhallIndicator.enabled = false;
	}

	private void OnTriggerStay(Collider other)
	{
		if (isChurch == true)
		{
			ChurchIndicator.enabled = true;
		}
		else if (isDock == true)
		{
			DockIndicator.enabled = true;
		}
		else if (isPark == true)
		{
			ParkIndicator.enabled = true;
		}
		else if (isBarnyard == true)
		{
			BarnIndicator.enabled = true;
		}
		else if (isAuctionhouse == true)
		{
			AuctionhouseIndicator.enabled = true;
		}
		else if (isGraveyard == true)
		{
			GraveyardIndicator.enabled = true;
		}
		else if(isCityhall == true)
		{
			CityhallIndicator.enabled = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		isChurch = false;
		isDock = false;
		isPark = false;
		isBarnyard = false;
		isAuctionhouse = false;
		isGraveyard = false;
		isCityhall = false;
		CheckWorldStatus();
	}

	private void CheckWorldStatus()
	{
		if (isChurch == false)
		{
			ChurchIndicator.enabled = false;
		}
		else if (isDock == false)
		{
			DockIndicator.enabled = false;
		}
		else if (isPark == false)
		{
			ParkIndicator.enabled = false;
		}
		else if (isBarnyard == false)
		{
			BarnIndicator.enabled = false;
		}
		else if (isAuctionhouse == false)
		{
			AuctionhouseIndicator.enabled = false;
		}
		else if (isGraveyard == false)
		{
			GraveyardIndicator.enabled = false;
		}
		else if (isCityhall == false)
		{
			CityhallIndicator.enabled = false;
		}
	}
}
