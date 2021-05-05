using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kcp4sharp {
    public abstract class Output {
        abstract public void output(ByteBuffer msg, Kcp kcp, Object user);
    }
}
