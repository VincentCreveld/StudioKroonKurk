using System;

public enum ItemState { not, has, used }
[Serializable]
public class Item
{
	public string name;
	public int id;
	private ItemState state = ItemState.not;

    public Item(int i, string n)
	{
		id = i;
		name = n;
	}

	public ItemState GetItemState()
	{
		return state;
	}

	public void SetItemState(ItemState s)
	{
		state = s;
	}
}
