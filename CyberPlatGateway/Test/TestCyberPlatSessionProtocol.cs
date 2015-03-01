using System.Text;

namespace CyberPlatGateway.Test
{
    public class TestCyberPlatSessionProtocol:CyberPlatSessionProtocolBase
    {
        public TestCyberPlatSessionProtocol():base(@"ht­tps://service.cyberplat.ru/cgi-bin/es/es_pay_check.cgi", "", "",@"C:\Users\vigelfortz\Documents\CyberPlatGateway\CyberPlatGateway\secret.key",Encoding.ASCII)
        {
            
        }
    }
}