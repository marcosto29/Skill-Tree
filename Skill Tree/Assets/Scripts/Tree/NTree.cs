using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NTree<T>
{
    public NTree<T> father;//when serializing the variables have to be public
    public LinkedList<NTree<T>> children;
    public T info;

    public NTree(T data)
    {
        info = data;
        children = new LinkedList<NTree<T>>();
    }

    public void AddChild(NTree<T> data)
    {
        data.father = this;
        children.AddFirst(data);
    }

    public NTree<T> GetChild(int i)
    {
        foreach (NTree<T> n in children)
            if (--i == 0)
                return n;
        return null;
    }
    public NTree<T> GetFather()
    {
        return father;
    }
    public void Traverse(NTree<T> node)//template to traverse through a tree using recusion
    {
        foreach (NTree<T> kid in node.children)
            Traverse(kid);
    }
}
