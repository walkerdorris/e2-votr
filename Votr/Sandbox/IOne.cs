using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votr.Sandbox
{
    /// <summary>
    /// Skeleton/Rules
    /// </summary>
    public interface IOne 
    {
        int MyProp { get; set; }
        int printInt();  
    }

    public interface ISomethingElse
    {
        int printNumberTwo();
    }

    public class One : IOne, ISomethingElse {
        public int MyProp { get; set; }
        // How to implement an interface
        // Must implement all Interface method signatures.
        public int printInt() // Can't be implemented unless it is public.
        {
            return 1;
        }

        public int printNumberTwo()
        {
            return 2;
        }

        public void doNothing()
        {
            
        }
    }

    public class Number
    {
        IOne my_prop { get; set; }
        // How do you interact with an interface
        public Number()
        {
            IOne my_var;
            One my_first = new One();
            my_first.printInt();

            // BUT you can NOT create instances of an interface!!!
            //IOne my_interface = new IOne();

            // Casting
            my_var = my_first as IOne;

            my_first.doNothing(); // Throws an exception

            // my_var.doNothing() is not available!
            // my_var.printNumberTwo() from the ISomethingElse interface is not available either!
           
        }
    }

}
