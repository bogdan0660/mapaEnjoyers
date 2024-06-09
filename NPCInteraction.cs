using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public InventoryManager inventoryManager; // Referencja do InventoryManager
    public string requiredItemName; // Nazwa wymaganego przedmiotu, który gracz musi oddać
    public GameObject objectToActivate; // Pierwszy obiekt, który ma zostać aktywowany po oddaniu przedmiotu
    public GameObject secondObjectToActivate; // Drugi obiekt, który ma zostać aktywowany po oddaniu przedmiotu

    private void Start()
    {
        // Opcjonalnie, możesz chcieć, aby obiekty były niewidoczne na początku
        if (objectToActivate != null)
            objectToActivate.SetActive(false);
        
        if (secondObjectToActivate != null)
            secondObjectToActivate.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distanceToPlayer = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

            if (distanceToPlayer < 2.0f) // Zakładając, że 2.0f to maksymalna odległość, z której gracz może wchodzić w interakcję z NPC
            {
                if (inventoryManager != null && inventoryManager.RemoveItem(requiredItemName)) // Użyj nazwy przedmiotu jako argumentu
                {
                    // Aktywuj pierwszy obiekt po oddaniu przedmiotu
                    if (objectToActivate != null)
                        objectToActivate.SetActive(true);
                    
                    // Aktywuj drugi obiekt po oddaniu przedmiotu
                    if (secondObjectToActivate != null)
                        secondObjectToActivate.SetActive(true);
                }
            }
        }
    }
}
