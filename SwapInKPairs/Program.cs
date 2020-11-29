using System;

namespace SwapInKPairs
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
            ListNode head2 = Reverse(head);
            head2.Print();
        }

        static ListNode SwapInK(ListNode head, int k)
        {
            ListNode current = head.next;
            ListNode prev = current;
            ListNode next = current.next;

            return head;
        }

        static ListNode Reverse(ListNode head)
        {
            ListNode current = head;
            ListNode prev = null;

            while (current != null)
            {
                ListNode next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }
    }
}
