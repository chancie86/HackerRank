namespace HackerRank.OneWeekPreparationKit.Day5
{
    public static class MergeTwoSortedLinkedLists
    {
        static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            var result = new SinglyLinkedList();

            while (head1 != null
                || head2 != null)
            {
                if (head1 == null)
                {
                    result.InsertNode(head2.data);
                    head2 = head2.next;
                }
                else if (head2 == null)
                {
                    result.InsertNode(head1.data);
                    head1 = head1.next;
                }
                else
                {
                    if (head1.data < head2.data)
                    {
                        result.InsertNode(head1.data);
                        head1 = head1.next;
                    }
                    else
                    {
                        result.InsertNode(head2.data);
                        head2 = head2.next;
                    }
                }
            }

            return result.head;
        }

        private class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        private class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }
    }
}
