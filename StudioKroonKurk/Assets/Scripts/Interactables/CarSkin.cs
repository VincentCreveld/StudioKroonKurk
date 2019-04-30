using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSkin : MonoBehaviour
{
	public GameObject skin0, skin1;
	private int nextOption;

	private void Start()
	{
		GameManager.instance.itemList.Add(66500, new Item(66500, "car"));
		GameManager.instance.dSFuncDict.Add(666660, () => { skin0.SetActive(false); skin1.SetActive(true); });
		GameManager.instance.dSFuncDict.Add(666666, () => { GameManager.instance.player.speed = 18f; GameManager.instance.player.angularSpeed = 50000f; GameManager.instance.camManager.smoothing = 0.5f; });
		GameManager.instance.dSFuncDict.Add(6666660, () => { skin0.SetActive(true); skin1.SetActive(false); });
		GameManager.instance.dSFuncDict.Add(6666666, () => { GameManager.instance.player.speed = 5f; GameManager.instance.player.angularSpeed = 15000f; GameManager.instance.camManager.smoothing = 0.05f; });
		GameManager.instance.dSFuncDict.Add(5555555, () => { GameManager.instance.PickupItem(66500); });
		GameManager.instance.dSFuncDict.Add(5555556, () => { GameManager.instance.UseItem(66500); });
		GameManager.instance.allOptions.Add(new Choice(666669, 8666661, 66660, "Want to become a car m8?", "SKRRT SKRRT", "Hell no"));
		GameManager.instance.allOptions.Add(new DialogText(66666, 767676, "Hey there, bucko."));
		GameManager.instance.allOptions.Add(new ItemGate(767676, 666666, 666669, 66500));

		GameManager.instance.allOptions.Add(new DialogText(66661, 404, "Swiggity swooty,\n You are now a car."));
		GameManager.instance.allOptions.Add(new Function(8666661, 8666663, 666660));
		GameManager.instance.allOptions.Add(new Function(8666663, 8666662, 5555555));
		GameManager.instance.allOptions.Add(new Function(8666662, 66661, 666666));

		GameManager.instance.allOptions.Add(new Choice(666666, 86666664, 66660, "Want to become a human m8?", "-happy noises-", "Hell no"));
		GameManager.instance.allOptions.Add(new DialogText(666661, 404, "Skidaddle skadoodle,\n You are now human again."));
		GameManager.instance.allOptions.Add(new Function(86666664, 86666666, 6666660));
		GameManager.instance.allOptions.Add(new Function(86666666, 86666665, 5555556));
		GameManager.instance.allOptions.Add(new Function(86666665, 666661, 6666666));

		GameManager.instance.allOptions.Add(new DialogText(66660, 404, "Piss off then m8."));
		GameManager.instance.allOptions.Add(new DialogText(44404, 404, "You are already in that form. \nPiss off m8."));
	}
}
