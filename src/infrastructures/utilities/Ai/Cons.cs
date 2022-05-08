using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Utilities.Ai
{
    // Nilクラス（空リストを表す）
    internal class Nil : Cons
    {
        public Nil()
        {
            head = null;
            tail = this;
        }
    }

    // Consクラス（リストを構成するコンスセル）
    public class Cons : IComparable<Cons>
    {
        protected static Cons nil = new Nil();
        protected object head = null;
        protected Cons tail = nil;

        //　プロパティ宣言：リードオンリー、書き換え不可（関数型スタイルにおける副作用防止の意味も含め）
        public static Cons Nil
        { get { return nil; } }      // 空リスト

        public object Head
        { get { return head; } }     // 先頭要素
        public Cons Tail
        { get { return tail; } }       // 先頭以外の残りのリスト
        public object First
        { get { return head; } }        // 先頭要素
        public object Second
        { get { return tail.head; } }  // 2番目の要素

        public Cons()
        { }

        // Cons:	コンストラクタ，リストの作成
        //		a => (7, 8, 9)
        //		new Cons(1)			=> (1)
        //		new Cons(1, a)		=> (1, 7, 8, 9)
        //		new Cons(1, 2, a)	=> (1, 2, 7, 8, 9)
        public Cons(params object[] x)
        {
            head = x[0];
            var cons = this;
            var n = x.Length;
            for (var i = 1; i < n - 1; i++)
            {
                cons.tail = new Cons();
                cons = cons.tail;
                cons.head = x[i];
            }
            if (n > 1) cons.tail = (Cons)x[n - 1];
        }

        // Equals:		等しいか
        //		a => (1, 2, (3)),	b => (1, 2, (3))
        //		a.Equals(b) => true
        public override bool Equals(object x)
        {
            if (x == null) return false;
            else if (this is Nil && x is Nil) return true;
            else if (this is Cons && head == null && tail == Nil && x is Nil) return true;
            else if (this is Nil && x is Cons && ((Cons)x).head == null && ((Cons)x).tail == Nil) return true;
            else if (this is Nil || x is Nil) return false;
            else if (this is Cons && x is Cons)
            {
                var a = this;
                var b = (Cons)x;
                if (a.head == null && b.head == null || a.head.Equals(b.head)) return a.tail.Equals(b.tail);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        // Cons.Of:	リストの作成
        //		Cons.Of(1, 2, 3)	 => (1, 2, 3)
        public static Cons Of(params object[] x)
        {
            var n = x.Length;
            var cons = Nil;
            for (var i = n - 1; i >= 0; i--) cons = new Cons(x[i], cons);
            return cons;
        }

        // Cons.Range:	連続数値リストの作成
        //		Cons.Range(1, 4) => (1, 2, 3)
        public static Cons Range(int from, int to)
        {
            return from == to ? Nil : new Cons(from, Range(from + 1, to));
        }

        // Cons.Fill:	初期値リストの作成
        //		Cons.Fill(3, 0) => (0, 0, 0)
        public static Cons Fill(object x, int n)
        {
            if (n == 0) return Cons.Nil;
            else return new Cons(x, Cons.Fill(x, n - 1));
        }

        // MakeIntArray2:		二次元配列（整数）の作成
        //		Cons.MakeIntArray2(3, 3, 0) => { {0, 0, 0}, {0, 0, 0}, {0, 0, 0} }
        public static int[,] MakeIntArray2(int n, int m, int val)
        {
            var a = new int[n, m];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < m; j++) a[i, j] = val;
            return a;
        }

        // MakeIntArray2:		二次元配列（文字）の作成
        //		Cons.MakeIntArray2(3, 3, 'a') => { {'a', 'a', 'a'}, {'a', 'a', 'a'}, {'a', 'a', 'a'} }
        public static char[,] MakeCharArray2(int n, int m, char val)
        {
            var a = new char[n, m];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < m; j++) a[i, j] = val;
            return a;
        }

        // Cons.FromArray:	配列からの変換
        //		array => {1, 2, 3}
        //		Cons.FromArray(array) => (1, 2, 3)
        public static Cons FromArray<T>(T[] x)
        {
            var cons = Nil;
            var n = x.Length;
            for (var i = n - 1; i >= 0; i--) cons = new Cons(x[i], cons);
            return cons;
        }

        // Cons.FromArray2:	二次元配列からの変換
        //		array => {{1, 2, 3}, {4, 5, 6}}
        //		Cons.FromArray2(array) => ((1, 2, 3), (4, 5, 6))
        public static Cons FromArray2<T>(T[,] x)
        {
            var consR = Nil;
            var r = x.GetLength(0);
            var c = x.GetLength(1);
            for (var i = r - 1; i >= 0; i--)
            {
                var consC = Nil;
                for (var j = c - 1; j >= 0; j--) consC = new Cons(x[i, j], consC);
                consR = new Cons(consC, consR);
            }
            return consR;
        }

        // Cons.FromList:	List型からの変換
        //		list => [1, 2, 3]
        //		Cons.FromList(list) => (1, 2, 3)
        public static Cons FromList<T>(List<T> x)
        {
            var cons = Nil;
            var n = x.Count;
            for (var i = n - 1; i >= 0; i--) cons = new Cons(x[i], cons);
            return cons;
        }

        // ToArray:	配列への変換
        //		a => (1, 2, 3)
        //		a.ToArray() => {1, 2, 3}
        public object[] ToArray()
        {
            return (object[])ToList().ToArray();
        }

        // ToList:	List型への変換
        //		a => (1, 2, 3)
        //		a.ToList() => (1, 2, 3)
        public List<object> ToList()
        {
            var list = new List<object>();
            var c = this;
            while (c != Nil)
            {
                list.Add(c.head);
                c = c.tail;
            }
            return list;
        }

        public static bool IsNumber(object x)
        {
            return x is sbyte || x is byte || x is short || x is ushort || x is int ||
                x is uint || x is long || x is ulong || x is float || x is double || x is decimal;
        }

        // CompareTo:		比較
        //		a => (1, 2, 3),	b => (1, 2, 4)
        //		a.CompareTo(b) => -1,		b.CompareTo(a) => 1,	a.CompareTo(a) => 0
        public int CompareTo(Cons x)
        {
            if (x == null) return 1;
            else if (this is Nil && x is Nil) return 0;
            else if (this is Nil) return -1;
            else if (x is Nil) return 1;
            else if (this is Cons && x is Cons)
            {
                var a = this;
                var b = (Cons)x;
                if (a.head == null && b.head == null || a.head.Equals(b.head))
                {
                    return a.tail.CompareTo(b.tail);
                }
                else if (IsNumber(a.head) && IsNumber(b.head))
                {
                    var aa = (double)a.head;
                    var bb = (double)b.head;
                    return aa < bb ? -1 : aa > bb ? 1 : a.tail.CompareTo(b.tail);
                }
                else if (a.head is string && b.head is string)
                {
                    var aa = (string)a.head;
                    var bb = (string)b.head;
                    var cmp = aa.CompareTo(bb);
                    return cmp < 0 ? -1 : cmp > 0 ? 1 : a.tail.CompareTo(b.tail);
                }
                else
                {
                    var cmp = a.head.ToString().CompareTo(b.head.ToString());
                    return cmp < 0 ? -1 : cmp > 0 ? 1 : a.tail.CompareTo(b.tail);
                }
            }
            return 0;
        }

        // ToString:		文字列化
        //		a => (1, 2, (3))
        //		a.ToString() => "(1, 2, (3))"
        public override string ToString()
        {
            return "(" + ToString1() + ")";
        }

        private string ToString1()
        {
            return (head is Cons ? head.ToString()
                            : head is string ? "\"" + head.ToString() + "\"" : head)
                + (tail != Nil ? ", " + tail.ToString1() : "");
        }

        // MkString:		区切り付き文字列化
        //		a => (1, 2, 3)
        //		a.MkString(":") => "1:2:3"
        public string MkString(string delim)
        {
            var sb = new StringBuilder();
            var c = this;
            while (c != Nil)
            {
                if (c != this) sb.Append(delim);
                sb.Append(c.head);
                c = c.tail;
            }
            return sb.ToString();
        }

        // Split:		区切り文字で文字列を分割しリストにする
        //		Cons.Split("a,b,c", ',') => ("1", "2", "3")
        public static Cons Split(string s, char delim)
        {
            return Cons.FromArray(s.Split(delim));
        }

        // Print, Println:	コンソール出力
        //		a => (1, 2, (3))
        //		a.Print() => 出力: (1, 2, (3))
        //		a.Println() => 出力: (1, 2, (3)) 改行
        public void Print()
        {
            Console.Write(ToString());
        }

        public void Println()
        {
            Console.WriteLine(ToString());
        }

        // Length:		リストの長さ
        //		a => (1, 2, 3)
        //		a.Length() => 3
        public int Length()
        {
            if (this == Nil) return 0;
            else return 1 + tail.Length();
        }

        // Get:		要素アクセス（object型で返す，結果利用はキャストが必要）
        //		a => (1, 2, 3)
        //		a.Get(0) => 1	・・・ object型，x = 5 + (int)a.Get(0)
        public object Get(int i)
        {
            if (i == 0) return head;
            else return tail.Get(i - 1);
        }

        // GetI:		要素アクセス（int型で返す）
        //		a => (1, 2, 3)
        //		a.GetI(0) => 1	・・・int型，x = 5 + a.Get(0)
        public int GetI(int i)
        {
            if (i == 0) return (int)head;
            else return tail.GetI(i - 1);
        }

        // GetS:		要素アクセス（string型で返す）
        //		a => ("1", "2", "3")
        //		a.GetS(0) => "1"	・・・ string型
        public string GetS(int i)
        {
            if (i == 0) return (string)head;
            else return tail.GetS(i - 1);
        }

        // GetB:		要素アクセス（bool型で返す）
        //		a => (true, false, false)
        //		a.GetB(0) => true	・・・ bool型
        public bool GetB(int i)
        {
            if (i == 0) return (bool)head;
            else return tail.GetB(i - 1);
        }

        // GetC:	要素アクセス（Cons型で返す）
        //		a => ((1, 2), (3))
        //		a.GetC(0) => (1, 2)	・・・ Cons型
        public Cons GetC(int i)
        {
            if (i == 0) return (Cons)head;
            else return tail.GetC(i - 1);
        }

        // Append:		リストの連結
        //		a => (1, 2, 3), b => (4, 5),
        //		a.Append(b) => (1, 2, 3, 4, 5)
        public Cons Append(Cons x)
        {
            return (this == Nil) ? x : new Cons(head, tail.Append(x));
        }

        // Add:		リスト末尾への追加
        //		a => (1, 2, 3), b => 4,
        //		a.Add(b) => (1, 2, 3, 4)
        public Cons Add(object x)
        {
            return Append(new Cons(x));
        }

        // Reverse:		リスト逆順化
        //		a => (1, 2, 3)
        //		a.Reverse() => (3, 2, 1)
        public Cons Reverse()
        {
            return (this == Nil) ? this : tail.Reverse().Add(head);
        }

        // Sorted:		リスト整列
        //		a => (2, 1, 3)
        //		a.Sorted() => (1, 2, 3)
        public Cons Sorted()
        {
            var a = ToArray();
            Array.Sort(a);
            return Cons.FromArray(a);
        }

        // Diff:		リスト要素の差集合
        //		a => (1, 2, 3), b => (2, 5)
        //		a.Diff(b) => (1, 3)
        public Cons Diff(Cons x)
        {
            if (x == Nil) return this;
            else return Diff1(x.head).Diff(x.tail);
        }

        private Cons Diff1(object x)
        {
            if (this == Nil) return Nil;
            else if (head.Equals(x)) return tail;
            else return new Cons(head, tail.Diff1(x));
        }

        // Find:		リスト要素の検索
        //		a => (1, 2, 3)
        //		a.Find(2) => 2,	a.Find(4) => null
        public object Find(object x)
        {
            if (this == Nil) return null;
            else if (head.Equals(x)) return x;
            else return tail.Find(x);
        }

        // Contains:		要素が含まれるか
        //		a => (1, 2, 3)
        //		a.Contains(2) => true
        public bool Contains(object x)
        {
            if (this == Nil) return false;
            else return head.Equals(x) ? true : tail.Contains(x);
        }

        // Count:		要素のカウント
        //		a => (1, 2, 3, 3)
        //		a.Count(3) => 2
        public int Count(object x)
        {
            if (this == Nil) return 0;
            else return (head.Equals(x) ? 1 : 0) + tail.Count(x);
        }

        // Sum:		要素の合計
        //		a => (1, 2, 3)
        //		a.Sum() => 6
        public int Sum()
        {
            if (this == Nil) return 0;
            else return (int)head + tail.Sum();
        }

        // Foreach:		順次処理
        //		a => (1, 2, 3)
        //		a.Foreach(x => Console.Write("{0} ", x)) => 出力: 1 2 3
        public void Foreach<T>(Action<T> fun)
        {
            if (this == Nil) return;
            else
            {
                fun((T)head);
                tail.Foreach(fun);
            }
        }

        // Map:		順次処理（リストで返す）
        //		a => (1, 2, 3)
        //		a.Map((int x) => x * 2) => (2, 4, 6)
        public Cons Map<T, R>(Func<T, R> fun)
        {
            if (this == Nil) return Nil;
            else return new Cons(fun((T)head), tail.Map(fun));
        }

        // FlatMap:		順次処理（リスト要素を結合して返す）
        //		a => ((1, 2, 3), (4, 5))
        //		a.FlatMap((Cons x) => x) => (1, 2, 3, 4, 5)
        public Cons FlatMap<T>(Func<T, Cons> fun)
        {
            if (this == Nil) return Nil;
            else return fun((T)head).Append(tail.FlatMap(fun));
        }

        // Forall:		すべて条件を満たすか
        //		a => (1, 2, 3, 4)
        //		a.Forall((int x) => x < 5) => true
        public bool Forall<T>(Predicate<T> fun)
        {
            if (this == Nil) return true;
            else return fun((T)head) ? tail.Forall(fun) : false;
        }

        // Exists:		ひとつでも条件を満たすか
        //		a => (1, 2, 3, 4)
        //		a.Exists((int x) => x > 3) => true
        public bool Exists<T>(Predicate<T> fun)
        {
            if (this == Nil) return false;
            else return fun((T)head) ? true : tail.Exists(fun);
        }

        // Count:	条件でカウント
        //		a => (1, 2, 3, 4)
        //		a.Count((int x) => x % 2 == 0) => 2
        public int Count<T>(Predicate<T> fun)
        {
            if (this == Nil) return 0;
            else return (fun((T)head) ? 1 : 0) + tail.Count(fun);
        }

        // filter:		条件でフィルタリング
        //		a => (1, 2, 3, 4)
        //		a.Filter((int x) => x % 2 == 0) => (2, 4)
        public Cons Filter<T>(Predicate<T> fun)
        {
            if (this == Nil) return Nil;
            else return fun((T)head) ? new Cons(head, tail.Filter(fun)) : tail.Filter(fun);
        }

        // FindPos:		条件で要素位置を検索
        //		a => (1, 2, 3, 4)
        //		a.FindPos((int x) => x % 3 == 0) => 2, a.FindPos((int x) => x == 0) => -1
        public int FindPos<T>(Predicate<T> fun)
        {
            if (this == Nil) return -1;
            else if (fun((T)head)) return 0;
            else
            {
                int pos = tail.FindPos(fun);
                return pos == -1 ? -1 : pos + 1;
            }
        }

        // Split:		条件でリストを分割
        //		a => (1, 2, 3, 4)
        //		a.Split((int x) => x == 3) => ((1, 2), ( 4))
        private Cons SplitLeft(int pos)
        {
            return pos <= 0 ? Nil : new Cons(head, tail.SplitLeft(pos - 1));
        }

        private Cons SplitRight(int pos)
        {
            return pos <= 0 ? this : tail.SplitRight(pos - 1);
        }

        public Cons Split<T>(Predicate<T> fun)
        {
            var pos = FindPos(fun);
            return Cons.Of(SplitLeft(pos), SplitRight(pos + 1));
        }

        public static string Rep(string s, int n)
        {
            return string.Concat(Enumerable.Repeat(s, n));
        }

        // 動作テスト用（別プロジェクトからCons.Test();で実行できる）
        public static void Test()
        {
            Console.WriteLine("Cons.Nil.Equals(Cons.Nil)\t= " + Cons.Nil.Equals(Cons.Nil));
            Console.WriteLine("new Cons().Equals(new Cons())\t= " + new Cons().Equals(new Cons()));
            Console.WriteLine("new Cons().Equals(Cons.Nil)\t= " + new Cons().Equals(Cons.Nil));
            Console.WriteLine("Cons.Nil.Equals(new Cons())\t= " + Cons.Nil.Equals(new Cons()));

            var a = Cons.Of(1, 2, 3);
            var b = Cons.Of(2, 2, "3");
            var c = Cons.Of(Cons.Of(1, 2, 3), Cons.Of(4, 5), Cons.Of(6));
            Console.WriteLine("Nil\t= " + Nil);
            Console.WriteLine("a\t= " + a);
            Console.WriteLine("b\t= " + b);
            Console.WriteLine("c\t= " + c);
            Console.WriteLine("a.head\t= " + a.head);
            Console.WriteLine("a.tail\t= " + a.tail);
            Console.WriteLine("Cons.Of(1, 2, 3)\t= " + Cons.Of(1, 2, 3));
            Console.WriteLine("Cons.Range(1, 5)\t= " + Cons.Range(1, 5));

            var e = new int[] { 1, 2, 3 };
            var d = new List<int>() { 1, 2, 3 };
            Console.WriteLine("Cons.FromArray(e)\t= " + Cons.FromArray(e));
            Console.WriteLine("Cons.FromList(d)\t= " + Cons.FromList(d));

            Console.WriteLine("a.Length()\t= " + a.Length());
            Console.WriteLine("a.Get(0)\t= " + a.Get(0));
            Console.WriteLine("a.Get(1)\t= " + a.Get(1));
            Console.WriteLine("a.Append(b)\t= " + a.Append(b));
            Console.WriteLine("a.Add(9)\t= " + a.Add(9));
            Console.WriteLine("a.Reverse()\t= " + a.Reverse());
            Console.WriteLine("a.Equals(c.head)\t= " + a.Equals(c.head));
            Console.WriteLine("c.Find(a)\t= " + c.Find(a));
            Console.WriteLine("a.Diff(b)\t= " + a.Diff(b));
            Console.WriteLine("b.Count(2)\t= " + b.Count(2));
            Console.WriteLine("a.Count((int x) => x < 3)\t= " + a.Count((int x) => x < 3));
            Console.WriteLine("a.Forall((int x) => x < 4)\t= " + a.Forall((int x) => x < 4));
            Console.WriteLine("a.Exists((int x) => x > 1)\t= " + a.Exists((int x) => x > 1));
            Console.Write("a.Foreach(x => Console.Write(\"{0} \", x))\t= ");
            a.Foreach((int x) => Console.Write("{0} ", x)); Console.WriteLine();
            Console.WriteLine("a.Map((int x) => x * 2))\t= " + a.Map((int x) => x * 2));
            Console.WriteLine("c.FlatMap((Cons x) => x)\t= " + c.FlatMap((Cons x) => x));
            Console.WriteLine("a.Filter((int x) => x % 2 == 1))\t= " + a.Filter((int x) => x % 2 == 1));
            Console.WriteLine("a.Split((int x) => x == 2)\t= " + a.Split((int x) => x == 2));
        }
    }
}