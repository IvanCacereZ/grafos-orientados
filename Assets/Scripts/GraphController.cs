using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    Listas<NodeController> ListNodes;
    public GameObject prefabNode;
    private GameObject currentNode;
    private void Start()
    {
        AddNode(6, 2, "1");
        AddNode(-6, 2, "2");
        AddNode(-6, -2, "3");
        AddNode(6, -2, "4");

        AddAdjacentNodes("1", new string[] { "2" });
        AddAdjacentNodes("2", new string[] { "3" });
        AddAdjacentNodes("3", new string[] { "4" });
        AddAdjacentNodes("4", new string[] { "1" });
    }
    void AddNode(float posX,float posY, string Nodetag)
    {
        currentNode = Instantiate(prefabNode, transform.position, transform.rotation);
        currentNode.GetComponent<NodeController>().SetInitialValues(posX, posY, Nodetag);
        ListNodes.AddNodeToEnd(currentNode.GetComponent<NodeController>()); //intente con las listas de unity pero igual
    }
    void AddAdjacentNodes(string nodeTag, string[] allAdjacentTags)
    {
        NodeController selectedNode = SearchNode(nodeTag);
        for (int i = 0; i < allAdjacentTags.Length; i++)
        {
            selectedNode.AddAdjacentNode(SearchNode(allAdjacentTags[i]));
        }
    }
    NodeController SearchNode(string nodeTag)
    {
        int position = 0;
        for (int i = 0;i < ListNodes.GetCount();i++)
        {
            if (ListNodes.GetNodeAtPosition(i).NodeTag == nodeTag)
            {
                position = i;
                break;
            }
        }
        return ListNodes.GetNodeAtPosition(position);
    }
}
