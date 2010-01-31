using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Builder_CS {

    //Director
    public class Shop {
        private ILaptopBuilder _builder;

        public Shop(ILaptopBuilder builder) {
            this._builder = builder;
        }

        public void BuildLaptop() {
            _builder.BuildScreen();
            _builder.BuildMainboard();
            _builder.BuildCPU();
        }
    }

    //Builder Interface
    public interface ILaptopBuilder {
        void BuildScreen();
        void BuildMainboard();
        void BuildCPU();

        Laptop GetLaptop();
    }

    // ConcretBuilder
    public class IBMLaptopBuilder : ILaptopBuilder {
        private Laptop _laptop = new Laptop();

        public void BuildScreen() {
            _laptop.Screen = "14'";
        }

        public void BuildMainboard() {
            _laptop.Mainboard = "Intel ...";
        }

        public void BuildCPU() {
            _laptop.CPU = "Intel Centrino ..."; 
        }

        public Laptop GetLaptop() {
            return _laptop;
        }
    }

    //ConcretBuilder
    public class MacLaptopBuilder : ILaptopBuilder {
        private Laptop _laptop = new Laptop();

        public void BuildScreen() {
            _laptop.Screen = "17' Crystal";
        }

        public void BuildMainboard() {
            _laptop.Mainboard = "Apple Mainboard";
        }

        public void BuildCPU() {
            _laptop.CPU = "Apple CPU";
        }

        public Laptop GetLaptop() {
            return _laptop;
        }
    }

    //Product
    public class Laptop {
        public string Screen { get; set; }
        public string Mainboard { get; set; }
        public string CPU { get; set; }
    }

    class Program {
        static void Main(string[] args) {
            var macBuilder = new MacLaptopBuilder();         
            var shop = new Shop(macBuilder);
            shop.BuildLaptop();
            var laptop = macBuilder.GetLaptop();
            Display(laptop);

            var ibmBuilder = new IBMLaptopBuilder();
            shop = new Shop(ibmBuilder);
            shop.BuildLaptop();
            laptop = ibmBuilder.GetLaptop();
            Display(laptop);

            Console.ReadKey();
        }

        static void Display(Laptop laptop) {
            Console.WriteLine("Laptop's Specification:");
            Console.WriteLine("Screen: " + laptop.Screen);
            Console.WriteLine("Mainboard: " + laptop.Mainboard);
            Console.WriteLine("CPU: " + laptop.CPU);
            Console.WriteLine("\n");
        }
    }
}
