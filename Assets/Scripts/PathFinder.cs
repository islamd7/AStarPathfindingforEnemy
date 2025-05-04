using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public Transform target;
    private List<Node> currentPath;
    private int pathIndex = 0;
    public float speed = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Node start = GetClosestNode(transform.position);
            Node end = GetClosestNode(target.position);
            currentPath = AStarManager.instance.GeneratePath(start, end);
            pathIndex = 0;
        }

        FollowPath();
    }

    void FollowPath()
    {
        if (currentPath == null || pathIndex >= currentPath.Count) return;

        Vector3 targetPos = currentPath[pathIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 1f)
            pathIndex++;
    }

    Node GetClosestNode(Vector2 position)
    {
        Node[] nodes = FindObjectsOfType<Node>();
        Node closest = null;
        float minDist = Mathf.Infinity;

        foreach (Node node in nodes)
        {
            float dist = Vector2.Distance(position, node.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = node;
            }
        }

        return closest;
    }
}
