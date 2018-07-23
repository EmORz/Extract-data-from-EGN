using System;
using System.Globalization;

namespace IdentificateData
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var year = "";
            var month = "";
            var day = "";
            var valid1 = "";
            var valid2 = "";
            var sex = "";
            var total = 0;
       
            var last = input[input.Length-1];
            int[] numChec = {2, 4, 8, 5, 10, 9, 7, 3, 6 };
            for (int r = 0; r < input.Length-1; r++)
            {
                var temp = int.Parse(input[r].ToString())*numChec[r];
                total += temp;
            }
            var rem = total % 11;

            if (rem.ToString() == last.ToString())
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (i < 2)
                    {
                        year += input[i];
                    }
                    else if (i >= 2 && i <= 3)
                    {
                        month += input[i];
                    }
                    else if (i >= 4 && i <= 5)
                    {
                        day += input[i];
                    }
                    else if (i >= 6 && i <= 7)
                    {
                        valid1 += input[i];
                    }
                    else if (i >= 8 && i <= 9)
                    {
                        valid2 += input[i];
                    }
                }

                for (int j = 0; j < valid2.Length; j++)
                {
                    if (j == 0)
                    {
                        var temp = int.Parse(valid2[j].ToString());
                        sex = (temp % 2 == 0 ? "Man" : "Woman");
                    }
                }

                //add 40  or add 20
                var monthNum = int.Parse(month);
                var currentYear = "";

                if (monthNum > 20 && monthNum < 33)
                {
                    monthNum -= 20;
                    currentYear = "18" + year;
                }
                else if (monthNum > 40 && monthNum < 53)
                {
                    monthNum -= 40;
                    currentYear = "20" + year;
                }
                else
                {
                    currentYear = "19" + year;
                }
                //
                string[] monthsArr = { "Jan", "Feb", "March", "April", "May", "June", "Jyli", "August", "Sept", "October", "November", "December" };
                var currentMonth = "";
                for (int k = 0; k < monthsArr.Length; k++)
                {
                    if (k == monthNum - 1)
                    {
                        currentMonth = (monthsArr[k]);
                        break;

                    }
                }
                var reminder = int.Parse(day) % 10;
                var suffix = "";
                switch (reminder)
                {
                    case 1: suffix = "st"; break;
                    case 2: suffix = "nd"; break;
                    case 3: suffix = "rd"; break;
                    default:
                        suffix = "th";
                        break;
                }

                var dateStr = $"{day}.{monthNum:d2}.{currentYear}";
                var dateT = DateTime.ParseExact(dateStr, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                var dateNow = DateTime.Now;
                var currentAgeInYear = dateNow.Year - dateT.Year;
                Console.WriteLine($"Your EGN is valid!");
                if (currentAgeInYear < 0)
                {
                    currentAgeInYear *= -1;
                    var text1 = $"You are {sex}, that will born in {currentYear} year, on {int.Parse(day)}-{suffix} {currentMonth}.\n" +
                   $"You will born after {currentAgeInYear} years.";
                    Console.WriteLine(text1);
                }
                else
                {
                    var text2 = $"You are {sex}, born in {currentYear} year, on {int.Parse(day)}-{suffix} {currentMonth}.\n" +
                        $"You are on {currentAgeInYear} years old.";
                    Console.WriteLine(text2);
                }

            }
            else
            {
                Console.WriteLine($"Your EGN is not valid!");

            }
        }
    }
}
