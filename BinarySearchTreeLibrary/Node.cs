namespace BinarySearchTreeLibrary
{
    public class Node<T>
    {
        public Node(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        public T Data { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }
    }
}
