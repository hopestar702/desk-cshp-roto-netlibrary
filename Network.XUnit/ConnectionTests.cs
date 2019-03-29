using System.Diagnostics;
using System;
using Xunit;
using Network;
using Network.Enums;
using Network.XUnit.Fixtures;
using System.Threading.Tasks;

namespace Network.XUnit
{
    public class ConnectionTests : IClassFixture<UnSecureServerFixture>
    {
        private UnSecureServerFixture serverFixture;

        public ConnectionTests(UnSecureServerFixture ServerFixture) => serverFixture = ServerFixture;

        [Fact]
        public void TcpConnectionTest()
        {
            TcpConnection tcpConnection = ConnectionFactory.CreateTcpConnection(serverFixture.Address, serverFixture.Port, out ConnectionResult connectionResult);
            
            Assert.Equal(connectionResult, ConnectionResult.Connected);

            tcpConnection.Close(CloseReason.ClientClosed);
        }

        [Fact]
        public void UdpConnectionTest()
        {
            TcpConnection tcpConnection = ConnectionFactory.CreateTcpConnection(serverFixture.Address, serverFixture.Port, out ConnectionResult tcpConnectionResult);
            UdpConnection udpConnectionh = ConnectionFactory.CreateUdpConnection(tcpConnection, out ConnectionResult udpConnectionResult);

            Assert.Equal(tcpConnectionResult, ConnectionResult.Connected);
            Assert.Equal(udpConnectionResult, ConnectionResult.Connected);

            tcpConnection.Close(CloseReason.ClientClosed);
            udpConnectionh.Close(CloseReason.ClientClosed);
        }

        [Fact]
        public async Task TcpConnectionAsyncTest()
        {
            var connectionResult = await ConnectionFactory.CreateTcpConnectionAsync(serverFixture.Address, serverFixture.Port);
            
            Assert.Equal(connectionResult.Item2, ConnectionResult.Connected);

            connectionResult.Item1.Close(CloseReason.ClientClosed);
        }

        [Fact]
        public async Task UdpConnectionAsyncTest()
        {
            var tcpConnectionResult = await ConnectionFactory.CreateTcpConnectionAsync(serverFixture.Address, serverFixture.Port);
            var udpConnectionResult = await ConnectionFactory.CreateUdpConnectionAsync(tcpConnectionResult.Item1);

            Assert.Equal(tcpConnectionResult.Item2, ConnectionResult.Connected);
            Assert.Equal(udpConnectionResult.Item2, ConnectionResult.Connected);

            tcpConnectionResult.Item1.Close(CloseReason.ClientClosed);
            udpConnectionResult.Item1.Close(CloseReason.ClientClosed);
        }
    }
}
