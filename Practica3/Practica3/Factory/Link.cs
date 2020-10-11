using SimioAPI;

namespace Practica3.Factory
{
    abstract class Link : SimioElement
    {
        public Link(IIntelligentObjects intelligentObjects, INodeObject node1, INodeObject node2, string type)
        {
            @object = intelligentObjects.CreateLink(type, node1, node2, null) as IFixedObject;
        }
    }
}
