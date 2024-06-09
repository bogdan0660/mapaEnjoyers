using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemName; // Dodaj to pole, aby przechowywać nazwę przedmiotu
    public Sprite itemSprite; // Grafika przedmiotu

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distanceToPlayer = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

            if (distanceToPlayer < 2.0f) // Zakładając, że 2.0f to maksymalna odległość, z której gracz może zebrać przedmiot
            {
                InventoryManager inventory = FindObjectOfType<InventoryManager>();
                if (inventory != null)
                {
                    inventory.AddItem(itemName, itemSprite); // Przekazujesz zarówno nazwę, jak i sprite przedmiotu
                    Destroy(gameObject); // Usuwa przedmiot ze świata gry
                }
            }
        }
    }
}
