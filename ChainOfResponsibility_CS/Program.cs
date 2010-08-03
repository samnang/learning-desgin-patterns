using System;

namespace ChainOfResponsibility_CS
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var hundredCashHandler = new HundredCashHandler();
            var fiftyCashHandler = new FiftyCashHandler();
            var twentyCashHandler = new TwentyCashHandler();
            var tenCashHandler = new TenCashHandler();

            hundredCashHandler.AppendHandler(fiftyCashHandler);
            hundredCashHandler.AppendHandler(twentyCashHandler);
            hundredCashHandler.AppendHandler(tenCashHandler);

            hundredCashHandler.Process(230);

            Console.ReadKey();
        }
    }

    public abstract class ATMCassetteHandler
    {
        public ATMCassetteHandler NextHandler { get; private set; }

        public bool CanHandle(double amount)
        {
            return amount >= AmountCanHandle;
        }

        public void Process(double amount)
        {
            if (CanHandle(amount))
                Console.WriteLine("{0} money: {1}", AmountCanHandle, Math.Floor(amount/AmountCanHandle));

            ProcessRemaindingAmount(amount);
        }

        private void ProcessRemaindingAmount(double amount)
        {
            double remainingAmount = amount%AmountCanHandle;
            if (remainingAmount > 0)
            {
                if (NextHandler != null)
                {
                    NextHandler.Process(remainingAmount);
                }
                else
                {
                    Console.WriteLine("With small money: {0}", remainingAmount);
                }
            }
        }

        public void AppendHandler(ATMCassetteHandler handler)
        {
            if (NextHandler == null)
            {
                NextHandler = handler;
            }
            else
            {
                NextHandler.AppendHandler(handler);
            }
        }

        public abstract double AmountCanHandle { get; }
    }

    public class HundredCashHandler : ATMCassetteHandler
    {
        public override double AmountCanHandle
        {
            get { return 100; }
        }
    }

    public class FiftyCashHandler : ATMCassetteHandler
    {
        public override double AmountCanHandle
        {
            get { return 50; }
        }
    }

    public class TwentyCashHandler : ATMCassetteHandler
    {
        public override double AmountCanHandle
        {
            get { return 20; }
        }
    }

    public class TenCashHandler : ATMCassetteHandler
    {
        public override double AmountCanHandle
        {
            get { return 10; }
        }
    }
}