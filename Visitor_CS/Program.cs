using System;

namespace Visitor_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            var modemConfigurator = new UnixModemConfigurator();
            var hayesModem = new HayesModem();
            var zoomModem = new ZoomModem();
            var ernieModem = new ErnieModem();

            hayesModem.Accept(modemConfigurator);
            Console.WriteLine("Hayes Modem Configuration: " + hayesModem.InternalConfiguration);

            zoomModem.Accept(modemConfigurator);
            Console.WriteLine("Zoom Modem Configuration: " + zoomModem.ConfigurationValue);

            ernieModem.Accept(modemConfigurator);
            Console.WriteLine("Ernie Modem Configuration: " + ernieModem.ConfigurationString);

            Console.ReadKey();
        }
    }

    public interface IModem
    {
        void Dial(string number);
        void Hangup();
        void Send(char charecter);
        char Receive();
        void Accept(IModemVisitor visitor);
    }

    public class ErnieModem : IModem
    {
        public void Dial(string number) { }
        public void Hangup() { }
        public void Send(char charecter) { }
        public char Receive() { return '0'; }

        public void Accept(IModemVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string ConfigurationString { get; set; }
    }

    public class ZoomModem:IModem
    {
        public void Dial(string number) { }
        public void Hangup() { }
        public void Send(char charecter) { }
        public char Receive() { return '0'; }

        public void Accept(IModemVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int ConfigurationValue { get; set; }
    }

    public class HayesModem:IModem
    {
        public void Dial(string number) { }
        public void Hangup() { }
        public void Send(char charecter) { }
        public char Receive() { return '0'; }

        public void Accept(IModemVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string InternalConfiguration { get; set; }
    }

    public interface IModemVisitor
    {
        void Visit(HayesModem modem);
        void Visit(ZoomModem modem);
        void Visit(ErnieModem modem);
    }

    public class UnixModemConfigurator : IModemVisitor
    {
        public void Visit(ErnieModem modem)
        {
            modem.ConfigurationString = "C is too slow";
        }

        public void Visit(ZoomModem modem)
        {
            modem.ConfigurationValue = 42;
        }

        public void Visit(HayesModem modem)
        {
            modem.InternalConfiguration = "&s1=4&D=3";
        }
    }
}
