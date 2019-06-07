using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REngine
{
    public class BinTreeNode<T>
    {
        private BinTreeNode<T> left;
        private T info;
        private BinTreeNode<T> right;


        public BinTreeNode(T x)
        {
            this.left = null;
            this.info = x;
            this.right = null;
        }
        public BinTreeNode(BinTreeNode<T> left, T x, BinTreeNode<T> right)
        {
            this.left = left;
            this.info = x;
            this.right = right;
        }


        public T GetInfo()
        {
            return this.info;
        }
        public void SetInfo(T x)
        {
            this.info = x;
        }
        public BinTreeNode<T> GetLeft()
        {
            return this.left;
        }
        public BinTreeNode<T> GetRight()
        {
            return this.right;
        }
        public void SetLeft(BinTreeNode<T> tree)
        {
            this.left = tree;
        }
        public void SetRight(BinTreeNode<T> tree)
        {
            this.right = tree;
        }
        public override string ToString()
        {
            return this.info.ToString();
        }
    }
}
