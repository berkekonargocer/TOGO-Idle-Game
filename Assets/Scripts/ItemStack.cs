using System;
using System.Collections.Generic;
using TMPro;
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

        [SerializeField] StackDirection stackDirection;

        [SerializeField] int maxItemCount = 5;

        [SerializeField] float itemStackOffset = 0.1f;

        [SerializeField] bool rotate = false;

        [SerializeField] Vector3 rotation;

        [SerializeField] TextMeshPro itemAmountFractionText;

        [SerializeField] bool textInvisIfNoItems;

        [SerializeField] AudioClip itemAddSFX;

        [SerializeField] bool playItemAddSFX;

        Stack<GameObject> _items = new Stack<GameObject>();
        public int GetItemCount { get { return _items.Count; } }
        public bool IsStackFull { get { return _items.Count >= maxItemCount; } }
        public bool IsStackEmpty { get { return _items.Count <= 0; } }

        AudioSource _audioSource;
        

        public ItemStack(GameObject gameObject) {
            if (itemAddSFX != null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }

            if (itemAmountFractionText != null)
            {
                itemAmountFractionText.SetText($"{GetItemCount}/{maxItemCount}");

                if (textInvisIfNoItems && GetItemCount < 1)
                {
                    itemAmountFractionText.alpha = 0;
                }
            }
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void Initialize(GameObject gameObject) {
            if (itemAddSFX != null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }

            if (itemAmountFractionText != null)
            {
                itemAmountFractionText.SetText($"{GetItemCount}/{maxItemCount}");

                if (textInvisIfNoItems && GetItemCount < 1)
                {
                    itemAmountFractionText.alpha = 0;
                }
            }
        }

        public void AddItem(GameObject item) {
            if (IsStackFull)
                return;

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

            if (playItemAddSFX)
            {
                _audioSource.PlayOneShot(itemAddSFX);
            }

            if (itemAmountFractionText == null)
                return;

            itemAmountFractionText.SetText($"{GetItemCount}/{maxItemCount}");

            if (!textInvisIfNoItems)
                return;

            itemAmountFractionText.alpha = 1;
        }

        public GameObject TakeItem() {
            GameObject item = _items.Pop();

            if (itemAmountFractionText == null)
                return item;

            itemAmountFractionText.SetText($"{GetItemCount}/{maxItemCount}");

            if (!textInvisIfNoItems)
                return item;

            if (GetItemCount < 1)
            {
                itemAmountFractionText.alpha = 0;
            }

            return item;
        }

        public void RemoveItem() {
            GameObject item = _items.Pop();
            GameObject.Destroy(item);

            if (itemAmountFractionText == null)
                return;

            itemAmountFractionText.SetText($"{GetItemCount}/{maxItemCount}");

            if (!textInvisIfNoItems)
                return;

            if (GetItemCount < 1)
            {
                itemAmountFractionText.alpha = 0;
            }
        }
    }
}