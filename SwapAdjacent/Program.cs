using System;

namespace SwapAdjacent
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))));
            Print(head);
            var head2 = SwapInPairsInternal(head);
            Print(head2);
        }

        static void Print(ListNode head)
        {
            ListNode current = head;
            while(current != null)
            {
                Console.Write(current.val + "->");
                current = current.next;
            }
            Console.WriteLine();
        }


        static ListNode SwapInPairsInternal(ListNode head)
        {
            ListNode current = head;
            if (current == null || current.next == null)
            {
                return head;
            }
            ListNode next = current.next;
            current.next = next.next;
            next.next = current;
            current.next = SwapInPairsInternal(current.next);
            return next;
        }
    }
}
