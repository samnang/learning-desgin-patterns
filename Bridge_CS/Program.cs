/* 
 Bridge Pattern:
    - Decouple an abstraction from its implementation so that the two can vary independently.
 */

using System;

namespace Bridge_CS {
    class Program {
        static void Main(string[] args) {
            ConcreteRemote remote = new ConcreteRemote();

            // Set implementation and call
            remote.TV = new Sony();
            remote.On();
            remote.SetChannel(1);
            remote.NextChannel();
            remote.Off();

            // Change implemention and call
            remote.TV = new JVC();
            remote.On();
            remote.SetChannel(1);
            remote.NextChannel();
            remote.Off();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public abstract class Remote
    {
        //Implementor
        public TV TV{ get; set;}

        //Operations
        public abstract void On();
        public abstract void Off();
        public abstract void SetChannel(int channel);
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class ConcreteRemote:Remote
    {
        private int _currentChannel;

        public override void On()
        {
            TV.On();
        }

        public override void Off()
        {
            TV.Off();
        }

        public override void SetChannel(int channel)
        {
            TV.TurnChanel(channel);
            _currentChannel = channel;
        }

        public void NextChannel()
        {
            SetChannel(_currentChannel + 1);
        }
    }

    /// <summary>
    /// The 'Implementor' interface
    /// </summary>
    public interface TV
    {
        void On();
        void Off();
        void TurnChanel(int channel);
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class Sony : TV
    {
        public void On()
        {
            Console.WriteLine("Sony On");
        }

        public void Off()
        {
            Console.WriteLine("Sony Off");
        }

        public void TurnChanel(int channel)
        {
            Console.WriteLine("Sony TurnChannel: " + channel);
        }
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class JVC: TV
    {
        public void On() {
            Console.WriteLine("JVC On");
        }

        public void Off() {
            Console.WriteLine("JVC Off");
        }

        public void TurnChanel(int channel) {
            Console.WriteLine("JVC TurnChannel: " + channel);
        }
    }
}
