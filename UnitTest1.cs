using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Task1
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            List<int> res = GetIntegersFromList(new List<object>() { 1, 2, 3, "a", "b", 4 });
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 2, 3, 4 }));
        }
        [Test]
        public void Test2()
        {
            List<int> res = GetIntegersFromList(new List<object>() { "a", "b", "c" });
            Assert.That(res, Is.EqualTo(new List<int>()));
        }
        [Test]
        public void Test3()
        {
            List<int> res = GetIntegersFromList(new List<object>() { 1, 2, 3 });
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 2, 3 }));
        }
        [Test]
        public void Test4()
        {
            List<int> res = GetIntegersFromList(new List<object>());
            Assert.That(res, Is.EqualTo(new List<int>()));
        }


        public List<int> GetIntegersFromList(List<object> list)
        {
            int temp = 0;
            var newList = new List<int>();
            foreach (var element in list)
            {
                if (element.GetType() == temp.GetType())
                {
                    newList.Add((int)element);
                }
            }
            return newList;
        }
    }
}


namespace Task2
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            object res = first_non_repeating_letter("QwertYqwert");
            Assert.That(res, Is.EqualTo('Y'));
        }
        [Test]
        public void Test2()
        {
            object res = first_non_repeating_letter("qwertyqwerty");
            Assert.That(res, Is.EqualTo(null));
        }


        public object first_non_repeating_letter(string str)
        {
            char res = ' ';
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                char temp = arr[i];
                int counter = 1;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (char.ToUpper(arr[j]) == char.ToUpper(temp) && j != i) counter++;
                }
                if (counter == 1)
                {
                    res = temp;
                    break;
                }
            }
            if (res == ' ') return null;
            else return res;
        }
    }
}


namespace Task3
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            int res = DigitalRoot(16);
            Assert.That(res, Is.EqualTo(7));
        }
        [Test]
        public void Test2()
        {
            int res = DigitalRoot(493193);
            Assert.That(res, Is.EqualTo(2));
        }


        public int DigitalRoot(int value)
        {
            List<int> arr = new List<int>();
            while (true)
            {
                arr.Add(value % 10);
                value = value / 10;
                if (value < 10)
                {
                    arr.Add(value);
                    break;
                }
            }
            value = arr.Sum();
            if (value >= 10) value = DigitalRoot(value);
            return value;
        }

    }
}


namespace Task4
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int res = Foo(arr, 5);
            Assert.That(res, Is.EqualTo(3));
        }
        [Test]
        public void Test2()
        {
            int[] arr = { 5, 5, 5 };
            int res = Foo(arr, 7);
            Assert.That(res, Is.EqualTo(0));
        }
        [Test]
        public void Test3()
        {
            int[] arr = { };
            int res = Foo(arr, 2);
            Assert.That(res, Is.EqualTo(0));
        }
        [Test]
        public void Test4()
        {
            int[] arr = { -1, 6, 8, 9 };
            int res = Foo(arr, 5);
            Assert.That(res, Is.EqualTo(1));
        }


        public int Foo(int[] arr, int target)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int temp = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (temp + arr[j] == target) counter++;
                }
            }
            return counter;
        }

    }
}


namespace Task5
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string res = Foo("Bob:Miligan;Shon:Bim;Connor:Bim");
            Assert.That(res, Is.EqualTo("(BIM, CONNOR)(BIM, SHON)(MILIGAN, BOB)"));
        }
        [Test]
        public void Test2()
        {
            string res = Foo("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill");
            Assert.That(res, Is.EqualTo("(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"));
        }


        public string Foo(string str)
        {
            string result = "";

            char[] separators = { ':', ';' };
            string[] arr = str.Split(separators);
            List<string[]> arr2 = new List<string[]>();
            for (int i = 0; i < arr.Length; i += 2)
            {
                string[] temp = { arr[i + 1].ToUpper(), arr[i].ToUpper() };
                arr2.Add(temp);
            }

            var arr3 = arr2.OrderBy(element => element[0]).ThenBy(element => element[1]);

            foreach (var element in arr3)
            {
                result += "(" + element[0] + ", " + element[1] + ")";
            }
            return result;
        }

    }
}


namespace ExtraTask1
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            int res = nextBigger(2017);
            Assert.That(res, Is.EqualTo(2071));
        }
        [Test]
        public void Test2()
        {
            int res = nextBigger(20749543);
            Assert.That(res, Is.EqualTo(20753449));
        }
        [Test]
        public void Test3()
        {
            int res = nextBigger(9);
            Assert.That(res, Is.EqualTo(-1));
        }
        [Test]
        public void Test4()
        {
            int res = nextBigger(531);
            Assert.That(res, Is.EqualTo(-1));
        }


        public int nextBigger(int number)
        {
            if (number < 10) return -1;
            int result = 0;

            int number2 = number;

            List<int> list = new List<int>();
            while (number >= 10)
            {
                list.Add(number % 10);
                number = number / 10;
                if (number < 10) list.Add(number);
            }
            list.Reverse();

            int i = list.Count - 1;
            while (i >= 1)
            {
                if (list[i - 1] < list[i]) break;
                else i--;
            }
            if (i == 0) return -1;

            for (int j = list.Count - 1; j >= i; j--)
            {
                int temp = list[j];
                if (temp > list[i - 1])
                {
                    int temp2 = list[i - 1];
                    list[i - 1] = temp;
                    list[j] = temp2;
                    break;
                }
            }

            for (int j = i; j < list.Count; j++)
            {
                for (int k = i; k < list.Count - 1; k++)
                {
                    if (list[k] > list[k + 1])
                    {
                        int temp = list[k];
                        list[k] = list[k + 1];
                        list[k + 1] = temp;
                    }
                }
            }

            for (int j = 0; j < list.Count; j++)
            {
                result += (int)(list[j] * Math.Pow(10, list.Count - j - 1));
            }

            return result;
        }

    }
}