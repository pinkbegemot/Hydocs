///
/// Palindrome
///

///1.

string strRev, strReal = null;
Console.WriteLine("Enter the string..");  
strReal = Console.ReadLine();  
char[] tmpChar = strReal.ToCharArray();
Array.Reverse(tmpChar);  
strRev=new string (tmpChar);  

if(strReal.Equals(strRev, StringComparison.OrdinalIgnoreCase))  
{  
    Console.WriteLine("The string is pallindrome");  
}  
else  
{  
    Console.WriteLine("The string is not pallindrome");  
}  
    Console.ReadLine();  
  /// <summary>
  /// 2 without a built-in func
  /// </summary>
  /// <param name="strVal"></param>
  /// <returns></returns>

private static bool chkPallindrome(string strVal)
{
    try
    {
        int min = 0;
        int max = strVal.Length - 1;
        while (true)
        {
            if (min > max)
                return true;
            char minChar = strVal[min];
            char maxChar = strVal[max];
            if (char.ToLower(minChar) != char.ToLower(maxChar))
            {
                return false;
            }
            min++;
            max--;
        }
    }
    catch (Exception)
    {

        throw;
    }
}  

////////////////////////////

///Chars in a string
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
  
namespace FindCountCharOccurance
{
    class Program
    {
        static void Main(string[] args)
        {
            string strOccur, strChar = null;
            Console.WriteLine("Enter the string in which you need to find the count of a char occurance");
            strOccur = Console.ReadLine();

            Console.WriteLine("Enter the char to be searched..");
            strChar = Console.ReadLine();
            int intCnt = strOccur.Length - strOccur.Replace(strChar, string.Empty).Length;
            Console.WriteLine("Count of occurance is " + intCnt);
            Console.ReadLine();
        }
    }
}

///Other solutions
string str = "abcdaab";

//Solution 1 - remove the character, and compare its length.
int result1 = str.Length - str.Replace("a", "").Length;

//Solution 2 - split the string into an array using the character as a delimiter
int result2 = str.Split('a').Length - 1;

//Solution 3 - use the LINQ 'Count' extension method
int result3 = str.ToCharArray().Count(c => c == 'a');

/////////////////////
using System;


namespace IdentityAPI.Results
{

 public class Node
    {
        public Node next;
        public Object data;
    }

    public class LinkedList
    {
        private Node head;
        public void printAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }

        public void AddFirst(Object data)
        {
            Node toAdd = new Node();
            toAdd.data = data;
            toAdd.next = head;
            head = toAdd;
        }

        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
            }
        }


        //Events

        public class Metronome
        {
            public event TickHandler TickEvent;
            public EventArgs e = null;
            public delegate void TickHandler(Metronome m, EventArgs e);
            public void Start()
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(3000);
                    TickEvent?.Invoke(this, e);
                }
            }
        }
        public class Listener
        {
            public void Subscribe(Metronome m)
            {
                m.TickEvent += new Metronome.TickHandler(HeardIt);
            }

            private void HeardIt(Metronome m, EventArgs e)
            {
                System.Console.WriteLine("HEARD IT");
            }
        }
        class Test
        {
            static void Main()
            {
                Metronome m = new Metronome();
                Listener l = new Listener();
                l.Subscribe(m);
                m.Start();
            }
        }
       




    }


    }