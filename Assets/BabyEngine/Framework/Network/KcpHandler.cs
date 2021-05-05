using System;
using kcp4sharp;
using BabyEngine;
public class KcpHandler : KcpClient {
    INetwork network;
    public KcpHandler(INetwork network) {
        this.network = network;
    }
    protected override void HandleReceive(ByteBuffer bb) {
        network.OnData(bb);
    }

    /// <summary>
    /// 异常
    /// </summary>
    /// <param name="ex"></param>
    protected override void HandleException(Exception ex) {
        base.HandleException(ex);
        network.OnException(ex);
    }

    /// <summary>
    /// 超时
    /// </summary>
    protected override void HandleTimeout() {
        base.HandleTimeout();
        network.OnTimeout();
    }
}