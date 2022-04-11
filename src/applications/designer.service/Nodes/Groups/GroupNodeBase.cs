using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Nodes.Groups
{
    public abstract class GroupNodeBase : NodeBase, IEnumerable<NodeBase>
    {
        public IEnumerator<NodeBase> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
