﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public class EAN13BarcodeVerifier : IBarcodeVerifier
    {
        public bool Verify(string barcode)
        {
            //EAN 13 bar codes are a set of 13 numbers where the 13th number is a check digit
            if (!Regex.IsMatch(barcode, "[0-9]{13}"))
            {
                throw new FormatException("Barcode format was not valid!");
            }
            // Verification method https://boxshot.com/barcode/barcodes/ean-13/check-digit-calculator/

            int checksum = int.Parse(barcode[12].ToString());
            int checkDigit = CalculateCheckDigit(barcode);
            if (checksum == checkDigit)
            {
                return true;
            }
            else
            {
                throw new FormatException("Check digit was invalid!");
            }
        }

        /// <summary>
        /// Calculate the check digit from the current barcode
        /// </summary>
        /// <param name="barcode">Barcode to Check</param>
        /// <returns>the check digit number for barcode</returns>
        int CalculateCheckDigit(string barcode)
        {
            char[] characters = barcode.ToCharArray();

            int evenNumbersSum = 0;
            int unevenNumbersSum = 0;

            for (int i = 0; i < 12; i++)
            {
                int number = int.Parse(characters[i].ToString());
                //Uneven are located on index 0,2,4,6
                if (i % 2 == 0)
                {
                    unevenNumbersSum += number;
                }
                else
                {
                    evenNumbersSum += number;
                }

            }
            int fullSum = evenNumbersSum * 3 + unevenNumbersSum;

            int reminder = fullSum % 10;

            int checkDigit = reminder;
            if (reminder != 0)
            {
                checkDigit = 10 - reminder;
            }
            return checkDigit;
        }
    }
}
