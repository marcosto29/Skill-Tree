using System.Collections.Generic;
using Newtonsoft.Json;

public class NTree<T>
{

    public LinkedList<NTree<T>> children; //when serializing the variables have to be public
    public T info;

    [JsonIgnore]
    public NTree<T> father;//ignore the father to prevent cyclics problem when transgorming to JSON
    
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
