using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class NodeConnector : MonoBehaviour
{
    public float connectionRadius = 2f;
    public int maxConnections = 6;

    public bool isConnect = true;

    private void Start()
    {
        if (isConnect)
        {
            ConnectAll();
        }
    }

    void ConnectAll()
    {
        Node[] allNodes = FindObjectsOfType<Node>();

        foreach (Node node in allNodes)
        {
            node.connections.Clear();

            List<Node> nearby = new List<Node>();

            foreach (Node other in allNodes)
            {
                if (other == node) continue;

                float distance = Vector2.Distance(node.transform.position, other.transform.position);
                if (distance <= connectionRadius)
                {
                    nearby.Add(other);
                }
            }

            nearby.Sort((a, b) =>
                Vector2.Distance(node.transform.position, a.transform.position)
                .CompareTo(Vector2.Distance(node.transform.position, b.transform.position)));

            for (int i = 0; i < Mathf.Min(maxConnections, nearby.Count); i++)
            {
                node.connections.Add(nearby[i]);
            }
        }

        Debug.Log("Node bağlantıları oyun başlayanda quruldu.");
    }
}

