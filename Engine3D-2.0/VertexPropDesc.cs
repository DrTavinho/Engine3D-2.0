using System;
using System.ComponentModel;

namespace Engine3D_2._0
{
    internal class VertexPropertyDescriptor : PropertyDescriptor
    {
        private readonly int index;
        public int Index => index;
        private readonly Polyhedron owner;
        public Polyhedron Owner => owner;

        public VertexPropertyDescriptor(Polyhedron owner, int index)
            : base($"Vértice[{index:D3}]", new Attribute[] { new CategoryAttribute("Vértices") })
        {
            this.owner = owner;
            this.index = index;
        }

        public override Type ComponentType => typeof(Polyhedron);
        public override bool IsReadOnly => false;
        public override Type PropertyType => typeof(Vector3);

        public override bool CanResetValue(object component) => false;
        public override object GetValue(object component) => owner.Vertices[index];
        public override void ResetValue(object component) { }
        public override void SetValue(object component, object value) => owner.Vertices[index] = (Vector3)value;
        public override bool ShouldSerializeValue(object component) => true;
    }
}
