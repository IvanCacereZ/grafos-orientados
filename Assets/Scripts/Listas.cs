using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listas<T> : MonoBehaviour 
{
    class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
    Node Head { get; set; }
    int count = 0;

    public void AddNodeToStart(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            count = count + 1;
        }
        else if (Head != null)
        {
            Node tmp = Head;
            Head = newNode;
            Head.Next = tmp;
            count = count + 1;
        }
    }
    public void AddNodeToEnd(T value)
    {
        if (Head == null)
        {
            AddNodeToStart(value);
        }
        else if (Head != null)
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            Node newNode = new Node(value);
            tmp.Next = newNode;
            count = count + 1;
        }
    }

    public void AddNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            AddNodeToStart(value);
        }
        else if (position == count)
        {
            AddNodeToEnd(value);
        }
        else if (position > count)
        {
            throw new Exception("Eso no se puede hacer, BRO");
        }
        else
        {
            int currentPosition = 0;
            Node tmp = Head;
            while (currentPosition < position - 1)
            {
                tmp = tmp.Next;
                currentPosition = currentPosition + 1;
            }
            Node NodeAtPosition = tmp.Next;
            Node newNode = new Node(value);

            tmp.Next = newNode;
            newNode.Next = NodeAtPosition;

            count = count + 1;
        }
    }

    public void ModifyAtStart(T value)
    {
        if (Head == null)
        {
            throw new InsufficientMemoryException("No existe es nodo, CREALO");
        }
        else
        {
            Head.Value = value;
        }
    }

    public void ModifyAtEnd(T value)
    {
        Node tmp = Head;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        tmp.Value = value;
    }

    public void ModifyAtPosition(T value, int position)
    {
        if (position == 0)
        {
            ModifyAtStart(value);
        }
        else if (position == count - 1)
        {
            ModifyAtEnd(value);
        }
        else if (position > count)
        {
            throw new ArgumentOutOfRangeException("Posicion muy grande, lo siento");
        }
        else
        {
            int iterator = 0;
            Node tmp = Head;
            while (iterator < position)
            {
                iterator = iterator + 1;
                tmp = tmp.Next;
            }
            tmp.Value = value;
        }
    }

    public T GetNodeAtStart()
    {
        if (Head == null)
        {
            throw new MissingFieldException("No se encontro ningun");
        }
        else
        {
            return Head.Value;
        }
    }

    public T GetNodeAtEnd()
    {
        if (Head == null)
        {
            throw new MissingMemberException("No existe cabeza para recorrer");
        }
        else
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            return tmp.Value;
        }
    }

    public T GetNodeAtPosition(int position)
    {
        if (position == 0)
        {
            return GetNodeAtStart();
        }
        else if (position == count - 1)
        {
            return GetNodeAtEnd();
        }
        else if (position > count)
        {
            throw new ArgumentOutOfRangeException("Posicion muy elevada");
        }
        else
        {
            int iterator = 0;
            Node tmp = Head;
            while (iterator < position)
            {
                tmp = tmp.Next;
                iterator = iterator + 1;
            }
            return tmp.Value;
        }
    }

    public void RemoveAtStart()
    {
        if (Head == null)
        {
            throw new MissingMemberException("Ya se ha eliminado o no se ha creado.");
        }
        else
        {
            Node newHead = Head.Next;
            Head.Next = null;
            Head = null;
            Head = newHead;
            count = count - 1;
        }
    }

    public void RemoveAtEnd()
    {
        Node tmp = Head;
        while (tmp.Next.Next != null)
        {
            tmp = tmp.Next;
        }
        Node finalNode = tmp.Next;
        finalNode = null;
        tmp.Next = null;
        count = count - 1;
    }

    public void RemoveNodeAtPosition(int position)
    {
        if (position == 0)
        {
            RemoveAtStart();
        }
        else if (position == count - 1)
        {
            RemoveAtEnd();
        }
        else if (position > count)
        {
            throw new ArgumentOutOfRangeException("No se puede hacer");
        }
        else
        {
            int iterator = 0;
            Node previusNode = Head;
            while (iterator < position - 1)
            {
                previusNode = previusNode.Next;
                iterator = iterator + 1;
            }
            Node currentNode = previusNode.Next;
            Node nextNode = currentNode.Next;

            currentNode.Next = null;
            currentNode = null;

            previusNode.Next = null;

            previusNode.Next = nextNode;

            count = count - 1;
        }
    }

    public int GetCount() //Ejercicio 1
    {
        return count;
    }
}
