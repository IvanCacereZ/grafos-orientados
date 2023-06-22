using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    Listas<NodeController> ListNodes;
    public GameObject prefabNode;
    public GameObject currentNode;
    [SerializeField] MoveController mvCtrl;
    private void Start()
    {
        ListNodes = new Listas<NodeController>();

        AddNode(6, 2, 3, "1" );
        AddNode(-6, 2, 4, "2");
        AddNode(-6, -2, 5, "3");
        AddNode(6, -2, 7, "4");

        AddAdjacentNodes("1", new string[] { "2" }, new float[] { 20f});
        AddAdjacentNodes("2", new string[] { "3" }, new float[] { 25f });
        AddAdjacentNodes("3", new string[] { "4" }, new float[] { 30f });
        AddAdjacentNodes("4", new string[] { "1" }, new float[] { 35f });

        mvCtrl.ChangeMovePosition(currentNode.GetComponent<Transform>().position);
    }
    void AddNode(float posX,float posY,float posZ, string Nodetag)
    {
        currentNode = Instantiate(prefabNode, transform.position, transform.rotation);
        currentNode.GetComponent<NodeController>().SetInitialValues(posX, posY, posZ, Nodetag);
        ListNodes.AddNodeToEnd(currentNode.GetComponent<NodeController>()); 
    }
    void AddAdjacentNodes(string nodeTag, string[] allAdjacentTags, float[] allAdjacentValues)
    {
        NodeController selectedNode = SearchNode(nodeTag);
        for (int i = 0; i < allAdjacentTags.Length; i++)
        {
            selectedNode.AddAdjacentNode(SearchNode(allAdjacentTags[i]), allAdjacentValues[i]);
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
