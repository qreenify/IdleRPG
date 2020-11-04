using UnityEditor;
using UnityEngine;
public class Enemy : MonoBehaviour {
	public Item item;
	void Start() {
		this.item = (Item)ObjectFactory.CreateInstance(typeof(Item));
		var newItem = Instantiate(this.item);
		// This would usually be enough to make sure,
		// that an object gets cleaned up by the GC:
		newItem = null;
		newItem = Instantiate(this.item);
		// For UnityEngine.Objects, you have to use
		// the destroy method, though!
		Destroy(newItem);
		// Now, newItem still points to a C# class
		// Even though the newItem-Object was destroyed.
		// No NullReference-Exception here!
		Debug.Log(newItem.price);
		// Unity has overloaded the == operator though
		// To return true, when comparing a destroyed
		// Object to null:
		Debug.Log(newItem == null);
		// Unfortunately, though, it does not work for
		// C#'s modern null-coalescing operators :(
		// So here, it will not skip the function call
		// in case the Object was destroyed:
		newItem?.ToString();
		Debug.Log(newItem ?? Instantiate(this.item));
	}

	void Update() {
		
	}
}