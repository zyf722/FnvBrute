namespace FnvBrute
{
    static class Utilities
    {
        // returns: whether the specified byte has completed a loop
        public static bool Increment(this byte[] array, int i)
        {
            var result = (byte)(array[i] + 1);
            if (result == 0x3a)
            {
                // digits out of bound, continue to alphabet
                array[i] = 0x41;
                return false;
            }
            else if (result == 0x5b)
            {
                // uppercase out of bound, continue to lowercase
                array[i] = 0x61;
                return false;
            }
            else if (result == 0x7b)
            {
                // lowercase out of bound
                if (i > 0)
                {
                    // not the first bytes, all done
                    array[i] = 0x30;
                }
                else
                {
                    // is the first byte, all done
                    array[i] = 0x41;
                }
                return true;
            }

            // keep incrementing
            array[i] = result;
            return false;
        }

        public static bool Increment(this byte from, out byte result)
        {
            result = (byte)(from + 1);
            if (result == 0x3a)
            {
                // digits out of bound, continue to alphabet
                result = 0x41;
                return false;
            }
            else if (result == 0x5b)
            {
                // alphabet out of bound, continue to lowercase
                result = 0x61;
                return false;
            }
            else if (result == 0x7b)
            {
                // alphabet out of bound, all done
                result = 0x30;
                return true;
            }

            // keep incrementing
            return false;
        }

        public static void ZeroFrom(this uint[] array, int i)
        {
            while (i < array.Length)
            {
                array[i] = 0;
                i++;
            }
        }
    }
}
