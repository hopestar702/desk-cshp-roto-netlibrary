using Network;
using Network.Enums;
using System;
using TestServerClientPackets;

namespace NetworkTestClient
{
    /// <summary>
    /// Simple example>
    /// 1. Establish a connection
    /// 2. Subscribe connectionEstablished event
    /// 3. Register what happens if we receive a packet of type "CalculationResponse"
    /// 4. Send a calculation request.
    /// 5. CalculationResponse received.
    /// </summary>
    public class DelegateExample
    {
        private ClientConnectionContainer container;

        public void Demo()
        {
            //1. Establish a connection to the server.
            container = ConnectionFactory.CreateClientConnectionContainer("127.0.0.1", 1234);
            //2. Register what happens if we get a connection
            container.ConnectionEstablished += connectionEstablished;
        }

        private void connectionEstablished(Connection connection, ConnectionType type)
        {
            Console.WriteLine($"{type.ToString()} Connection established");
            //3. Register what happens if we receive a packet of type "CalculationResponse"
            container.RegisterPacketHandler<CalculationResponse>(calculationResponseReceived, this);
            //4. Send a calculation request.
            connection.Send(new CalculationRequest(10, 10), this);
        }

        private void calculationResponseReceived(CalculationResponse response, Connection connection)
        {
            //5. CalculationResponse received.
            Console.WriteLine($"Answer received {response.Result}");
        }
    }
}