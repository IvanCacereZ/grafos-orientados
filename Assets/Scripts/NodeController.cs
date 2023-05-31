using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    Listas<NodeController> AdjacentNodes;
    Listas<float> Values;
    private float positionX;
    private float positionY;
    public string NodeTag;
    float cost = 0f;
    public NodeController SelectNextNode()
    {
        int nodeSelected = Random.Range(0, AdjacentNodes.GetCount());
        cost = Values.GetNodeAtPosition(nodeSelected);
        return AdjacentNodes.GetNodeAtPosition(nodeSelected);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MoveObject")
        {
            NodeController selected = SelectNextNode();
            collision.GetComponent<MoveController>().UpdateEnergy(cost);
            collision.GetComponent<MoveController>().ChangeMovePosition(selected.gameObject.transform.position);
        }
    }
    public void SetInitialValues(float posX, float posY,string tag)
    {
        positionX = posX;
        positionY = posY;
        NodeTag = tag;
        transform.position = new Vector2(positionX, positionY);
    }
    public void AddAdjacentNode(NodeController node)
    {
        AdjacentNodes.AddNodeToEnd(node);
    }
}
