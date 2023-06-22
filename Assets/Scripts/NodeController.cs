using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    Listas<NodeController> AdjacentNodes;
    Listas<float> Values;
    private float positionX;
    private float positionY;
    private float positionZ;
    public string NodeTag;
    float cost = 0f;
    private void Awake()
    {
        AdjacentNodes = new Listas<NodeController>();
        Values = new Listas<float>();
    }
    public NodeController SelectNextNode()
    {
        int nodeSelected = Random.Range(0, AdjacentNodes.GetCount());
        cost = Values.GetNodeAtPosition(nodeSelected);
        return AdjacentNodes.GetNodeAtPosition(nodeSelected);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MoveObject")
        {
            NodeController selected = SelectNextNode();
            other.GetComponent<MoveController>().UpdateEnergy(cost);
            other.GetComponent<MoveController>().ChangeMovePosition(selected.GetComponent<Transform>().position);
        }
    }
    public void SetInitialValues(float posX, float posY, float posZ, string tag)
    {
        positionX = posX;
        positionY = posY;
        positionZ = posZ;
        NodeTag = tag;
        transform.position = new Vector3(positionX, positionY, positionZ);
    }
    public void AddAdjacentNode(NodeController node,float value)
    {
        AdjacentNodes.AddNodeToEnd(node);
        Values.AddNodeToEnd(value);
    }
}
