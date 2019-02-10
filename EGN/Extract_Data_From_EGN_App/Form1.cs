using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extract_Data_From_EGN_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var input = this.textBox1.Text;
            var year = "";
            var month = "";
            var day = "";
            var valid1 = "";
            var valid2 = "";
            var sex = "";
            var total = 0;
            var region = "";
            for (int g = 0; g < input.Length - 1; g++)
            {
                if (g > 5)
                {

                    region += (input[g]);
                }
            }
            //=>
            var numRegio = int.Parse(region);

            var currentRegio = "";

            if (numRegio >= 0 && numRegio <= 43)
            {
                currentRegio = "Благоевград";
            }
            if (numRegio >= 44 && numRegio <= 93)
            {
                currentRegio = "Бургас";
            }
            if (numRegio >= 94 && numRegio <= 139)
            {
                currentRegio = "Варна";
            }
            if (numRegio >= 140 && numRegio <= 169)
            {
                currentRegio = "Велико Търново";
            }
            if (numRegio >= 170 && numRegio <= 183)
            {
                currentRegio = "Видин";
            }
            if (numRegio >= 184 && numRegio <= 217)
            {
                currentRegio = "Враца";
            }
            if (numRegio >= 218 && numRegio <= 233)
            {
                currentRegio = "Габрово";
            }
            if (numRegio >= 234 && numRegio <= 281)
            {
                currentRegio = "Кърджали";
            }
            if (numRegio >= 282 && numRegio <= 301)
            {
                currentRegio = "Кюстендил";
            }
            if (numRegio >= 302 && numRegio <= 319)
            {
                currentRegio = "Ловеч";
            }
            if (numRegio >= 320 && numRegio <= 341)
            {
                currentRegio = "Монтана";
            }
            if (numRegio >= 342 && numRegio <= 377)
            {
                currentRegio = "Пазарджик";
            }
            if (numRegio >= 378 && numRegio <= 395)
            {
                currentRegio = "Перник";
            }
            if (numRegio >= 396 && numRegio <= 435)
            {
                currentRegio = "Плевен";
            }
            if (numRegio >= 436 && numRegio <= 501)
            {
                currentRegio = "Пловдив";
            }
            if (numRegio >= 502 && numRegio <= 501)
            {
                currentRegio = "Пловдив";
            }
            if (numRegio >= 502 && numRegio <= 527)
            {
                currentRegio = "Разград";
            }
            if (numRegio >= 528 && numRegio <= 555)
            {
                currentRegio = "Русе";
            }
            if (numRegio >= 556 && numRegio <= 575)
            {
                currentRegio = "Силистра";
            }
            if (numRegio >= 576 && numRegio <= 601)
            {
                currentRegio = "Сливен";
            }
            if (numRegio >= 602 && numRegio <= 623)
            {
                currentRegio = "Смолян";
            }
            if (numRegio >= 624 && numRegio <= 721)
            {
                currentRegio = "София - град";
            }
            if (numRegio >= 722 && numRegio <= 751)
            {
                currentRegio = "София - област";
            }
            if (numRegio >= 752 && numRegio <= 789)
            {
                currentRegio = "Стара загора";
            }
            if (numRegio >= 790 && numRegio <= 821)
            {
                currentRegio = "Добрич (Толбухин)";
            }
            if (numRegio >= 822 && numRegio <= 843)
            {
                currentRegio = "Търговище";
            }
            if (numRegio >= 844 && numRegio <= 871)
            {
                currentRegio = "Хасково";
            }
            if (numRegio >= 872 && numRegio <= 903)
            {
                currentRegio = "Шумен";
            }
            if (numRegio >= 904 && numRegio <= 925)
            {
                currentRegio = "Ямбол";
            }
            if (numRegio >= 926 && numRegio <= 999)
            {
                currentRegio = "Друг/Неизвестен";
            }
            //
            var last = input[input.Length - 1];
            int[] numChec = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            for (int r = 0; r < input.Length - 1; r++)
            {
                var temp = int.Parse(input[r].ToString()) * numChec[r];
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
                this.richTextBox1.Text = $"Your EGN is valid!";
                if (currentAgeInYear < 0)
                {
                    currentAgeInYear *= -1;
                    var text1 = $"You are {sex}, that will born in {currentYear} year, on {int.Parse(day)}-{suffix} {currentMonth}, in {currentRegio}\n" +
                   $"You will born after {currentAgeInYear-1} years.";
                    this.richTextBox1.Text = text1;
                }
                else
                {
                    if (dateNow.Month>= dateT.Month && dateNow.Day >= dateT.Day)
                    {
                        currentAgeInYear*=1;
                    }
                    else
                    {
                        currentAgeInYear--;
                    }
                    var text2 = $"You are {sex}, born in {currentYear} year, on {int.Parse(day)}-{suffix} {currentMonth}, in {currentRegio}\n" +
                        $"You are on {currentAgeInYear} years old.";
                    this.richTextBox1.Text = text2;
                }

            }
            else
            {
                this.richTextBox1.Text =$"Your EGN is not valid!";

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
            this.textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void simpleAppFromEmoNikolovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is simple app that extract data from EGN. Desing and implement by Emo Nikolov" +Environment.NewLine+
                            "Version 1.3"+
                            "For more info: https://sites.google.com/site/emorznikolov/za-men");
        }
    }
}
