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
    }
    void AddNode(float posX,float posY, string tag)
    {
        currentNode = Instantiate(prefabNode, transform.position, transform.rotation);
        currentNode.GetComponent<NodeController>().SetInitialValues(posX, posY, tag);
        ListNodes.AddNodeToEnd(currentNode.GetComponent<NodeController>());
    }
}
