public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        bool wasPickUp = Inventory.Instance.Add(item);
        if (wasPickUp)
        {

            Destroy(gameObject);
        }
    }

}
