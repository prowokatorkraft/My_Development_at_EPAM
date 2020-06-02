using System;
using System.Text;

namespace MyLibrary
{
    public sealed class MyString : IComparable<MyString>
    {
        char[] str;
        public int Length
        {
            get
            {
                return str.Length;
            }
        }

        public MyString(string str)
        {
            this.str = str.ToCharArray();
        }

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();

            foreach (var item in str)
            {
                temp.Append(item);
            }

            return temp.ToString();
        }
        public static int Compare(MyString firstString, MyString secondString)
        {
            if (firstString.Length > secondString.Length)
            {
                return 1;
            }
            else if (firstString.Length < secondString.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public int CompareTo(MyString other)
        {
            if (Length > other.str.Length)
            {
                return 1;
            }
            else if (Length < other.str.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public bool IsChar(char simbol)
        {
            foreach (var item in str)
            {
                if (item == simbol)
                {
                    return true;
                }
            }
            return false;
        }
        public int RemoveTo(char simbol)
        {
            StringBuilder builder = new StringBuilder(str.ToString());

            builder.Replace();
        }

        public static MyString operator +(MyString firstString, MyString secondString)
        {
            return new MyString(firstString.ToString() + secondString.ToString());
        }
    }
}
