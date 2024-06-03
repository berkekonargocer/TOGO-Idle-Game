using System;
using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO
{
    public enum StackDirection
    {
        X, Y, Z
    }

    [Serializable]
    public class ItemStack
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] Transform itemStackPosTransform;

        [SerializeField] float itemStackOffset = 0.1f;

        [SerializeField] StackDirection stackDirection;

        [SerializeField] bool rotate = false;

        [SerializeField] Vector3 rotation;

        Stack<GameObject> _items = new Stack<GameObject>();
        public int GetItemCount { get { return _items.Count; } }
        public bool IsStackFull { get { return _items.Count >= MAX_ITEM_COUNT; } }
        public bool IsStackEmpty { get { return _items.Count <= 0; } }

        const int MAX_ITEM_COUNT = 5;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void AddItem(GameObject item) {
            item.transform.SetParent(itemStackPosTransform);

            if (IsStackEmpty)
            {
                item.transform.localPosition = Vector3.zero;
            }
            else
            {
                item.transform.localPosition = stackDirection switch
                {
                    StackDirection.X => new Vector3(_items.Peek().transform.localPosition.x + itemStackOffset, 0, 0),
                    StackDirection.Y => new Vector3(0, _items.Peek().transform.localPosition.y + itemStackOffset, 0),
                    StackDirection.Z => new Vector3(0, 0, _items.Peek().transform.localPosition.z + itemStackOffset),
                    _ => new Vector3(0, _items.Peek().transform.localPosition.y + itemStackOffset, 0)
                };
            }

            if (rotate)
            {
                item.transform.localRotation = Quaternion.Euler(rotation);
            }

            _items.Push(item);
        }

        public GameObject TakeItem() {
            GameObject item = _items.Pop();
            return item;
        }

        public void RemoveItem() {
            GameObject item = _items.Pop();
            GameObject.Destroy(item);
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}