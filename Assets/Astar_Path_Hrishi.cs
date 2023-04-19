using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar_Path_Hrishi : MonoBehaviour
{
    public class Node : IComparable<Node> {
        public Vector3 Position;
        public Node Parent;
        public float G, H, F;

        public Node(Vector3 position, Node parent = null) {
            Position = position;
            Parent = parent;
        }

        public int CompareTo(Node other) {
            return F.CompareTo(other.F);
        }
    }
    private static float Heuristic(Node a, Node b) {
        return Vector3.Distance(a.Position, b.Position);
    }

    public static List<Node> FindPath(Vector3 start, Vector3 goal, Func<Vector3, bool> isWalkable) {
        Node startNode = new Node(start);
        Node goalNode = new Node(goal);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openList.Add(startNode);

        while (openList.Count > 0) {
            openList.Sort();
            Node currentNode = openList[0];

            if (currentNode.Position == goalNode.Position) {
                List<Node> path = new List<Node>();
                while (currentNode != null) {
                    path.Add(currentNode);
                    currentNode = currentNode.Parent;
                }
                path.Reverse();
                return path;
            }

            openList.Remove(currentNode);
            closedSet.Add(currentNode);

            // Define the possible movement directions
            Vector3[] directions = {
                new Vector3(-1, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(0, 0, -1),
                new Vector3(0, 0, 1)
            };

            foreach (Vector3 direction in directions) {
                Vector3 newPosition = currentNode.Position + direction;

                if (!isWalkable(newPosition)) continue;

                Node neighbor = new Node(newPosition, currentNode);

                if (closedSet.Contains(neighbor)) continue;

                float tentativeG = currentNode.G + Vector3.Distance(currentNode.Position, newPosition);

                if (!openList.Contains(neighbor)) {
                    openList.Add(neighbor);
                } else if (tentativeG >= neighbor.G) {
                    continue;
                }

                neighbor.Parent = currentNode;
                neighbor.G = tentativeG;
                neighbor.H = Heuristic(neighbor, goalNode);
                neighbor.F = neighbor.G + neighbor.H;
            }
        }

        return null;
    }
}
