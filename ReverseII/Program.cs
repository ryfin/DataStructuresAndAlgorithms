using System;

namespace ReverseII
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            return val.ToString();
        }

        public void Print()
        {
            ListNode current = this;
            while (current != null)
            {
                Console.Write(current);
                current = current.next;
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))));
            head.Print();
            ReverseBetween(head, 1, 6).Print();
         //   ReverseBetween(new ListNode(1), 2, 4).Print();
        }

        static ListNode ReverseBetween(ListNode head, int start, int stop)
        {
            if(head == null || start == stop)
            {
                return head;
            }

            ListNode current = head;
            ListNode prev = null;
            ListNode before = null;
            ListNode last = null;
            int i = 1;
            for (; i < start && current != null; i++)
            {
                before = current;
                current = current.next;
            }
            last = current;
            while (current != null && i <= stop)
            {
                ListNode next = current.next;
                current.next = prev;
                prev = current;
                current = next;
                i++;
            }
            last.next = current;
            if (before == null)
            {
                return prev;
            }

            before.next = prev;

            return head;
        }
    }
}
