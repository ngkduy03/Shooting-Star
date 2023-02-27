using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class SerializableDictionary<TKey, TValue> :
    ISerializationCallbackReceiver where TKey : System.Enum
{

    [Serializable] public class Node
    {
        public TKey key;
        public TValue value;
    }

    public List<Node> NodeList;
    public Dictionary<TKey, TValue> _myDictionary = new Dictionary<TKey, TValue>();

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        _myDictionary.Clear();

        foreach (Node n in NodeList)
        {
            if (_myDictionary.ContainsKey(n.key))
            {
                if (_myDictionary[n.key] == null)
                {
                    _myDictionary[n.key] = n.value;
                }
                else
                {
                    var Tkeys = (TKey[])Enum.GetValues(typeof(TKey));
                    int index = (Array.IndexOf(Tkeys, n.key) + 1) % Tkeys.Length;
                    _myDictionary.Add(Tkeys[index], n.value);
                }
            }
            else
            {
                _myDictionary.Add(n.key, n.value);
            }
        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        NodeList.Clear();
        foreach (var pair in _myDictionary)
        {
            Node n = new Node();
            n.key = pair.Key;
            n.value = pair.Value;
            NodeList.Add(n);
        }
    }
}