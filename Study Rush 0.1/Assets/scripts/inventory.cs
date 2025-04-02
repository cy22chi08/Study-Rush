using UnityEngine;
using UnityEngine.UI;

public class Inventory: MonoBehaviour
{
    public GameObject[] itemSlots = new GameObject[2]; // Holds the items
    private int selectedSlot = 0; // 0 for first slot, 1 for second slot

    public Image slot1Highlight;
    public Image slot2Highlight;

    private GameObject itemInRange; // Stores the item in range for pickup

    void Update()
    {
        // Switch Inventory Slots
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSlot = 0;
            UpdateHighlight();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSlot = 1;
            UpdateHighlight();
        }

        // Pick Up Item
        if (Input.GetKeyDown(KeyCode.E) && itemInRange != null)
        {
            PickupItem(itemInRange);
        }

        // Use Item
        if (Input.GetKeyDown(KeyCode.E) && itemSlots[selectedSlot] != null)
        {
            UseItem();
        }
    }

    void UpdateHighlight()
    {
        slot1Highlight.enabled = (selectedSlot == 0);
        slot2Highlight.enabled = (selectedSlot == 1);
    }

    void PickupItem(GameObject item)
    {
        if (itemSlots[0] == null)
        {
            itemSlots[0] = item;
        }
        else if (itemSlots[1] == null)
        {
            itemSlots[1] = item;
        }
        else
        {
            Debug.Log("Inventory Full!");
            return;
        }

        item.SetActive(false); // Hide item
        Debug.Log("Picked up: " + item.name);
    }

    void UseItem()
    {
        Debug.Log("Using item: " + itemSlots[selectedSlot].name);
        itemSlots[selectedSlot] = null; // Remove item after use
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = null;
        }
    }
}