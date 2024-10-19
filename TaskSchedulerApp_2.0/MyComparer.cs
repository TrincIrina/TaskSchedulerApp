using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using TaskSchedulerApp.Model;

namespace TaskSchedulerApp_2._0
{
    public class MyComparer : IComparer
    {
        public MyComparer()
        {
        }

        public MyComparer(ListSortDirection sortDirection)
        {
            SortDirection = sortDirection;
        }

        public ListSortDirection SortDirection { get; set; }

        public int Compare(object obj1, object obj2)
        {
            string text1 = (obj1 as Deal)?.Priority.ToString();
            string text2 = (obj2 as Deal)?.Priority.ToString();
            if (text1 == null || text2 == null)
            {
                return 0;
            }

            // находит позицию "i", в которой разные символы
            // пример: text1 = "HD156"
            // пример: text2 = "HD1789"
            // результат: i = 3 ^
            var i = 0;
            while (i < text1.Length && i < text2.Length && text1[i] == text2[i])
            {
                i++;
            }

            // составляет числа (от позиции "i" и до цифры)
            // пример: strNumber1 = "56" strNumber2 = "789"
            var strNumber1 = new string(text1.Substring(i).ToList().
                TakeWhile(c => Char.IsDigit(c)).ToArray());
            var strNumber2 = new string(text2.Substring(i).ToList().
                TakeWhile(c => Char.IsDigit(c)).ToArray());

            // сравнивать как числа
            if (int.TryParse(strNumber1, out var number1) && int.TryParse(strNumber2, out var number2))
            {
                return SortDirection == ListSortDirection.Ascending ? 
                    number1.CompareTo(number2) : 
                    number2.CompareTo(number1);
            }

            // сравнивать в виде строк
            return SortDirection == ListSortDirection.Ascending ? 
                text1.CompareTo(text2) : 
                text2.CompareTo(text1);
        }
    }
}