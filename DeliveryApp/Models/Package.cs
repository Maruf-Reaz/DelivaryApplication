using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class Package
    {
        public int Id { get; set; }

        public int PickUpRequestId { get; set; }
        public PickUpRequest PickUpRequest { get; set; }

        public int PackageCatagoryId { get; set; }
        public PackageCatagory PackageCatagory { get; set; }

        public string TrackingNumber { get; set; }
        public int LocationToId { get; set; }
        public Location LocationTo { get; set; }
        public double? Weight { get; set; }
        public double? ProductPrice { get; set; }
        public double? Price { get; set; }

        public string PhoneNumber { get; set; }
        public string Dimension { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }

        public DateTime DeliveryDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime AssignDate { get; set; }

        public int? DeliveryManId { get; set; }
        public DeliveryMan DeliveryMan { get; set; }


        public string Remarks { get; set; }

        public byte Status { get; set; }

        public string NumberToWords(double doubleNumber)
        {
            var beforeFloatingPoint = (int)Math.Floor(doubleNumber);
            var beforeFloatingPointWord = $"{NumberToWords(beforeFloatingPoint)} Taka";
            var afterFloatingPointWord = $"{SmallNumberToWord((int)Math.Round((doubleNumber - beforeFloatingPoint) * 100), "")} Paisa";
            if (afterFloatingPointWord == " Paisa")
            {
                return $"{beforeFloatingPointWord}";
            }
            else
            {
                return $"{beforeFloatingPointWord} and {afterFloatingPointWord}";
            }
            //return $"{beforeFloatingPointWord}";
        }
        private string NumberToWords(int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            var words = "";

            if (number / 10000000 > 0)
            {
                words += NumberToWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if (number / 100000 > 0)
            {
                words += NumberToWords(number / 100000) + " Lac ";
                number %= 100000;
            }

            if (number / 1000 > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            words = SmallNumberToWord(number, words);

            return words;
        }
        private string SmallNumberToWord(int number, string words)
        {
            if (number <= 0)
            {
                return words;
            }

            if (words != "")
                words += " ";

            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
            {
                words += unitsMap[number];
            }
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                {
                    words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
        //status 0 = created
    }
}
