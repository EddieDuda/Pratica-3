using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] Text fromDisplay;
    [SerializeField] Text toDisplay;
    [SerializeField] Text infoDisplay;

    Pathfinder<Node> map;
    Node to, from;
    Vector3[] linePath;

    void Start()
    {
        Node.OnClicked += HandleNodeClicked;

        var nodes = GameObject.FindObjectsOfType<Node>();
        var connections = new Dictionary<Node, HashSet<Node>>();
        foreach (var node in nodes)
        {
            connections.Add(node, new HashSet<Node>(node.Neighbors));
        }
        map = new Pathfinder<Node>(connections);
    }

    void HandleNodeClicked(Node node)
    {
        switch (from, to)
        {
            case (null, null):
                from = node;
                fromDisplay.text = from.name;
                break;
            case ({ }, null):
                if (from == node) break;
                to = node;
                toDisplay.text = to.name;
                var path = map.FindPath(from, to);
                if (path == null)
                {
                    infoDisplay.text = "Path not possible";
                    break;
                }
                linePath = path.Select(n => n.Position).ToArray();
                line.positionCount = linePath.Length;
                line.SetPositions(linePath);
                infoDisplay.text = $"Path found with {linePath.Length} nodes";
                break;
            case ({ }, { }):
                from = node;
                fromDisplay.text = from.name;
                to = null;
                toDisplay.text = string.Empty;
                linePath = null;
                line.positionCount = 0;
                infoDisplay.text = string.Empty;
                break;
        }
        line.enabled = from != null && to != null && linePath != null;
    }
}
