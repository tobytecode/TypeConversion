using System;
using System.Text;

namespace TypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Explicit conversion
            int Number = 987654;
            long bigNumber = Number;
            Console.WriteLine(bigNumber);

            //Implicit conversion
            double x = 9876.55;
            int intValue;
            intValue = (int)x; // Cast double to int.
            Console.WriteLine(intValue);

            //01
            //ToBoolean: Converts a type to a Boolean value, where possible.
            string myString = "true";
            Boolean resultBoolean = Convert.ToBoolean(myString);
            Console.WriteLine(resultBoolean);

            //02
            //ToByte: base set to 16 (hexadecimal) : Converts a type to a byte.
            string text = "d7";
            byte resultByte = Convert.ToByte(text, 16);
            Console.WriteLine(resultByte);

            //03
            //ToChar: Converts a type to a single Unicode character, where possible.
            int i = 65;
            char resultChar = Convert.ToChar(i);
            Console.WriteLine(resultChar);
            
            //04
            //ToDateTime: Converts a type (integer or string type) to date-time structures.
            string date = "01/08/2017";
            DateTime resultDate = Convert.ToDateTime(date);
            Console.WriteLine("Year: {0}, Month: {1}, Day: {2}", resultDate.Year, resultDate.Month, resultDate.Day);


            //05
            //ToDecimal: Converts a floating point or integer type to a decimal type.
            string strDecimal = "11.10";
            decimal resultDecimal = Convert.ToDecimal(strDecimal);
            Console.WriteLine(resultDecimal);

            //06
            //ToDouble: Converts a type to a double type.
            string strDouble = "101.55";
            double resultDouble = Convert.ToDouble(strDouble);
            Console.WriteLine(strDouble);

            //07
            //ToInt16: Converts a type to a 16-bit integer.
            string strInt16 = "101.16";
            double resultInt16 = Convert.ToDouble(strInt16);
            Console.WriteLine(resultInt16);

            //08
            //ToInt32: Converts a type to a 32-bit integer.
            string strInt32 = "101.32";
            double resultInt32 = Convert.ToDouble(strInt32);
            Console.WriteLine(strInt32);

            //09
            //ToInt64: Converts a type to a 64-bit integer.
            string strInt64 = "101.64";
            double resultInt64 = Convert.ToDouble(strInt64);
            Console.WriteLine(strInt64);

            //10
            //ToSbyte :Converts a type to a signed byte type.
            string strSbyte = "101.64";
            double resulSbyte = Convert.ToDouble(strSbyte);

            //11
            //get the byte array
            Console.WriteLine("SByte Started:");
            byte[] bytes = Encoding.ASCII.GetBytes("Some string");
            sbyte[] sbytes = new sbyte[bytes.Length]; //convert it to sbyte array
            for (i = 0; i < bytes.Length; i++)
            {
                sbytes[i] = (sbyte)bytes[i];
                Console.WriteLine(sbytes[1]);
            }
            Console.WriteLine("End SByte");

            //12
            //ToSingle: Converts a type to a small floating point number.
            string strSingle = "-1,035.77219";
            float resulSingle = Convert.ToSingle(strSingle);
            Console.WriteLine(resulSingle);

            //13
            //ToString: Converts a type to a string.
            int intString1 = 501;
            int intString2 = 502;
            string strString1 = intString1.ToString();
            string strString2 = Convert.ToString(intString2);

            Console.WriteLine(strString1);
            Console.WriteLine(intString2);

            Person person = new Person { Name = "John", Age = 12 };
            Console.WriteLine(person);


            //14
            //ToType: Converts a type to a specified type.
            Type type = Type.GetType("TypeConversion.Program, TypeConversion");
            Console.WriteLine(type.Assembly.ImageRuntimeVersion);

            //ToUInt16: Converts a type to an unsigned int type.
            double[] valuesUInt16 = { 25.10, 25.15 };
            foreach (double a in valuesUInt16)
            {
                UInt16 c = Value_To_BatteryVoltage(a);
                Console.WriteLine("{0} = {1}", a, c);
            }


            //15
            //ToUInt32: Converts a type to an unsigned long type.          
            string value = Convert.ToString(Int32.MinValue, 16); // Create a hexadecimal value out of range of the UInt32 type.
            // Convert it back to a number.
            try
            {
                UInt32 number = Convert.ToUInt32(value, 16);
                Console.WriteLine("0x{0} converts to {1}.", value, number);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Unable to convert '0x{0}' to an unsigned integer.", value);
            }

            //16
            //ToUInt64: Converts a type to an unsigned big integer.
            string[] valuesUInt64 = { "One", "1.34e28", "-26.87", "-18", "-6.00", " 0", "137", "1601.9", Int32.MaxValue.ToString() };
            ulong result;

            foreach (string item in valuesUInt64)
            {
                try
                {
                    result = Convert.ToUInt64(value);
                    Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",value.GetType().Name, value, result.GetType().Name, result);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("{0} is outside the range of the UInt64 type.", value);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The {0} value '{1}' is not in a recognizable format.",value.GetType().Name, value);
                }
            }

            Console.ReadLine();

        }




        //ToSingle: Converts a type to a small floating point number.
        static void ToSingleConvertionEx()
        {
            string[] values = { "-1,035.77219", "1AFF", "1e-35", "1.63f",
                   "1,635,592,999,999,999,999,999,999", "-17.455", 
                   "190.34001", "1.29e325"};
            float result;

            foreach (string value in values)
            {
                try
                {
                    result = Convert.ToSingle(value);
                    Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                                      value.GetType().Name, value,
                                      result.GetType().Name, result);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to convert '{0}' to a Single.", value);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("'{0}' is outside the range of a Single.", value);
                }
            }
        }


        //ToString: Converts a type to a string. 
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return "Person: " + Name + " " + Age;
            }
        }


        //ToUInt16: Converts a type to an unsigned int type.
        public static UInt16 Value_To_BatteryVoltage(double value)
        {
            string[] number = value.ToString().Split('.');
            UInt16 c = (UInt16)(UInt16.Parse(number[0]) << 8);
            UInt16 m = UInt16.Parse(number[1]);
            return (UInt16)(c + m);
        }

    }
}
