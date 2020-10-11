using SimioAPI;

namespace Practica3.Factory
{
    abstract class SimioElement
    {
        protected IFixedObject @object;

        public SimioElement()
        {               
        }

        public void UpdateName(string newName)
        {
            @object.ObjectName = newName;
        }

        public string GetName()
        {
            return @object.ObjectName;
        }
    }
}
