using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Schemas.Elements.Learnings
{
    /// <summary>
    /// Nilクラス（空リストを表す）
    /// </summary>
    internal class Nil : ConsCell
    {
        public Nil()
        {
            head = null;
            tail = this;
        }
    }

    /// <summary>
    /// Consクラス（リストを構成するコンスセル）
    /// </summary>
    public class ConsCell : IComparable<ConsCell>
    {
        #region フィールド

        protected static ConsCell nil = new Nil();
        protected object head = null;
        protected ConsCell tail = nil;

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// 空リスト
        /// </summary>
        public static ConsCell Nil { get { return nil; } }

        /// <summary>
        /// 先頭要素
        /// </summary>
        public object Head { get { return head; } }

        /// <summary>
        /// 先頭以外の残りのリスト
        /// </summary>
        public ConsCell Tail { get { return tail; } }

        /// <summary>
        /// 先頭要素
        /// </summary>
        public object First { get { return head; } }

        /// <summary>
        /// 2番目の要素
        /// </summary>
        public object Second { get { return tail.head; } }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConsCell()
        { }

        /// <summary>
        /// コンストラクター，リストの作成
        /// a => (7, 8, 9)
        /// new Cons(1)			=> (1)
        ///	new Cons(1, a)		=> (1, 7, 8, 9)
        ///	new Cons(1, 2, a)	=> (1, 2, 7, 8, 9)
        /// </summary>
        /// <param name="x"></param>
        public ConsCell(params object[] x)
        {
            head = x[0];
            var cons = this;
            var n = x.Length;
            for (var i = 1; i < n - 1; i++)
            {
                cons.tail = new ConsCell();
                cons = cons.tail;
                cons.head = x[i];
            }
            if (n > 1) cons.tail = (ConsCell)x[n - 1];
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 等しいか
        /// a => (1, 2, (3)),	b => (1, 2, (3))
        ///	a.Equals(b) => true
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public override bool Equals(object x)
        {
            if (x == null) return false;
            else if (this is Nil && x is Nil) return true;
            else if (this is ConsCell && head == null && tail == Nil && x is Nil) return true;
            else if (this is Nil && x is ConsCell && ((ConsCell)x).head == null && ((ConsCell)x).tail == Nil) return true;
            else if (this is Nil || x is Nil) return false;
            else if (this is ConsCell && x is ConsCell)
            {
                var a = this;
                var b = (ConsCell)x;
                if (a.head == null && b.head == null || a.head.Equals(b.head)) return a.tail.Equals(b.tail);
            }
            return false;
        }

        /// <summary>
        /// ハッシュコード取得
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// リストの作成
        /// Cons.Of(1, 2, 3)	 => (1, 2, 3)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ConsCell Of(params object[] x)
        {
            var n = x.Length;
            var cons = Nil;
            for (var i = n - 1; i >= 0; i--) cons = new ConsCell(x[i], cons);
            return cons;
        }

        /// <summary>
        /// 連続数値リストの作成
        /// Cons.Range(1, 4) => (1, 2, 3)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ConsCell Range(int from, int to)
        {
            return from == to ? Nil : new ConsCell(from, Range(from + 1, to));
        }

        /// <summary>
        /// 初期値リストの作成
        /// Cons.Fill(3, 0) => (0, 0, 0)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ConsCell Fill(object x, int n)
        {
            if (n == 0) return Nil;
            else return new ConsCell(x, Fill(x, n - 1));
        }

        /// <summary>
        /// 二次元配列（整数）の作成
        /// Cons.MakeIntArray2(3, 3, 0) => { {0, 0, 0}, {0, 0, 0}, {0, 0, 0} }
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int[,] MakeIntArray2(int n, int m, int val)
        {
            var a = new int[n, m];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < m; j++) a[i, j] = val;
            return a;
        }

        /// <summary>
        /// 二次元配列（文字）の作成
        /// Cons.MakeIntArray2(3, 3, 'a') => { {'a', 'a', 'a'}, {'a', 'a', 'a'}, {'a', 'a', 'a'} }
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static char[,] MakeCharArray2(int n, int m, char val)
        {
            var a = new char[n, m];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < m; j++) a[i, j] = val;
            return a;
        }

        /// <summary>
        /// 配列からの変換
        /// array => {1, 2, 3}
        ///	Cons.FromArray(array) => (1, 2, 3)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ConsCell FromArray<T>(T[] x)
        {
            var cons = Nil;
            var n = x.Length;
            for (var i = n - 1; i >= 0; i--) cons = new ConsCell(x[i], cons);
            return cons;
        }

        /// <summary>
        /// 二次元配列からの変換
        /// array => {{1, 2, 3}, {4, 5, 6}}
        ///	Cons.FromArray2(array) => ((1, 2, 3), (4, 5, 6))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ConsCell FromArray2<T>(T[,] x)
        {
            var consR = Nil;
            var r = x.GetLength(0);
            var c = x.GetLength(1);
            for (var i = r - 1; i >= 0; i--)
            {
                var consC = Nil;
                for (var j = c - 1; j >= 0; j--) consC = new ConsCell(x[i, j], consC);
                consR = new ConsCell(consC, consR);
            }
            return consR;
        }

        /// <summary>
        /// List型からの変換
        /// list => [1, 2, 3]
        ///	Cons.FromList(list) => (1, 2, 3)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ConsCell FromList<T>(List<T> x)
        {
            var cons = Nil;
            var n = x.Count;
            for (var i = n - 1; i >= 0; i--) cons = new ConsCell(x[i], cons);
            return cons;
        }

        /// <summary>
        /// 配列への変換
        /// a => (1, 2, 3)
        //	a.ToArray() => {1, 2, 3}
        /// </summary>
        /// <returns></returns>
        public object[] ToArray()
        {
            return ToList().ToArray();
        }

        /// <summary>
        /// List型への変換
        ///		a => (1, 2, 3)
        ///		a.ToList() => (1, 2, 3)
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 値型判定
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsNumber(object x)
        {
            return x is sbyte || x is byte || x is short || x is ushort || x is int ||
                x is uint || x is long || x is ulong || x is float || x is double || x is decimal;
        }

        /// <summary>
        /// 比較
        ///		a => (1, 2, 3),	b => (1, 2, 4)
        ///		a.CompareTo(b) => -1,		b.CompareTo(a) => 1,	a.CompareTo(a) => 0
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int CompareTo(ConsCell x)
        {
            if (x == null) return 1;
            else if (this is Nil && x is Nil) return 0;
            else if (this is Nil) return -1;
            else if (x is Nil) return 1;
            else if (this is ConsCell && x is ConsCell)
            {
                var a = this;
                var b = x;
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

        /// <summary>
        /// 文字列化
        ///		a => (1, 2, (3))
        ///		a.ToString() => "(1, 2, (3))"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + ToString1() + ")";
        }

        private string ToString1()
        {
            return (head is ConsCell ? head.ToString()
                            : head is string ? "\"" + head.ToString() + "\"" : head)
                + (tail != Nil ? ", " + tail.ToString1() : "");
        }

        /// <summary>
        /// 区切り付き文字列化
        ///		a => (1, 2, 3)
        ///		a.MkString(":") => "1:2:3"
        /// </summary>
        /// <param name="delim"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 区切り文字で文字列を分割しリストにする
        ///		Cons.Split("a,b,c", ',') => ("1", "2", "3")
        /// </summary>
        /// <param name="s"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public static ConsCell Split(string s, char delim)
        {
            return FromArray(s.Split(delim));
        }

        /// <summary>
        /// コンソール出力
        ///		a => (1, 2, (3))
        ///		a.Print() => 出力: (1, 2, (3))
        /// </summary>
        public void Print()
        {
            Console.Write(ToString());
        }

        /// <summary>
        /// コンソール出力
        ///		a => (1, 2, (3))
        ///		a.Println() => 出力: (1, 2, (3)) 改行
        /// </summary>
        public void Println()
        {
            Console.WriteLine(ToString());
        }

        /// <summary>
        /// リストの長さ
        ///		a => (1, 2, 3)
        ///		a.Length() => 3
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            if (this == Nil) return 0;
            else return 1 + tail.Length();
        }

        /// <summary>
        /// 要素アクセス（object型で返す，結果利用はキャストが必要）
        ///		a => (1, 2, 3)
        ///		a.Get(0) => 1	・・・ object型，x = 5 + (int)a.Get(0)
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public object Get(int i)
        {
            if (i == 0) return head;
            else return tail.Get(i - 1);
        }

        /// <summary>
        /// 要素アクセス（int型で返す）
        ///		a => (1, 2, 3)
        ///		a.GetI(0) => 1	・・・int型，x = 5 + a.Get(0)
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int GetToInt(int i)
        {
            if (i == 0) return (int)head;
            else return tail.GetToInt(i - 1);
        }

        /// <summary>
        /// 要素アクセス（string型で返す）
        ///		a => ("1", "2", "3")
        ///		a.GetS(0) => "1"	・・・ string型
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetToString(int i)
        {
            if (i == 0) return (string)head;
            else return tail.GetToString(i - 1);
        }

        /// <summary>
        /// 要素アクセス（bool型で返す）
        ///		a => (true, false, false)
        ///		a.GetB(0) => true	・・・ bool型
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool GetToBool(int i)
        {
            if (i == 0) return (bool)head;
            else return tail.GetToBool(i - 1);
        }

        /// <summary>
        /// 要素アクセス（Cons型で返す）
        ///		a => ((1, 2), (3))
        ///		a.GetC(0) => (1, 2)	・・・ Cons型
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ConsCell GetToCons(int i)
        {
            if (i == 0) return (ConsCell)head;
            else return tail.GetToCons(i - 1);
        }

        /// <summary>
        /// リストの連結
        ///		a => (1, 2, 3), b => (4, 5),
        ///		a.Append(b) => (1, 2, 3, 4, 5)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ConsCell Append(ConsCell x)
        {
            return this == Nil ? x : new ConsCell(head, tail.Append(x));
        }

        /// <summary>
        /// リスト末尾への追加
        ///		a => (1, 2, 3), b => 4,
        ///		a.Add(b) => (1, 2, 3, 4)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ConsCell Add(object x)
        {
            return Append(new ConsCell(x));
        }

        /// <summary>
        /// リスト逆順化
        ///		a => (1, 2, 3)
        ///		a.Reverse() => (3, 2, 1)
        /// </summary>
        /// <returns></returns>
        public ConsCell Reverse()
        {
            return this == Nil ? this : tail.Reverse().Add(head);
        }

        /// <summary>
        /// リスト整列
        ///		a => (2, 1, 3)
        ///		a.Sorted() => (1, 2, 3)
        /// </summary>
        /// <returns></returns>
        public ConsCell Sorted()
        {
            var a = ToArray();
            Array.Sort(a);
            return FromArray(a);
        }

        /// <summary>
        /// リスト要素の差集合
        ///		a => (1, 2, 3), b => (2, 5)
        ///		a.Diff(b) => (1, 3)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ConsCell Diff(ConsCell x)
        {
            if (x == Nil) return this;
            else return Diff1(x.head).Diff(x.tail);
        }

        private ConsCell Diff1(object x)
        {
            if (this == Nil) return Nil;
            else if (head.Equals(x)) return tail;
            else return new ConsCell(head, tail.Diff1(x));
        }

        /// <summary>
        /// リスト要素の検索
        ///		a => (1, 2, 3)
        ///		a.Find(2) => 2,	a.Find(4) => null
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public object Find(object x)
        {
            if (this == Nil) return null;
            else if (head.Equals(x)) return x;
            else return tail.Find(x);
        }

        /// <summary>
        /// 要素が含まれるか
        ///		a => (1, 2, 3)
        ///		a.Contains(2) => true
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool Contains(object x)
        {
            if (this == Nil) return false;
            else return head.Equals(x) ? true : tail.Contains(x);
        }

        /// <summary>
        /// 要素のカウント
        ///		a => (1, 2, 3, 3)
        ///		a.Count(3) => 2
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Count(object x)
        {
            if (this == Nil) return 0;
            else return (head.Equals(x) ? 1 : 0) + tail.Count(x);
        }

        /// <summary>
        /// 要素の合計
        ///		a => (1, 2, 3)
        ///		a.Sum() => 6
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            if (this == Nil) return 0;
            else return (int)head + tail.Sum();
        }

        /// <summary>
        /// 順次処理
        ///		a => (1, 2, 3)
        ///		a.Foreach(x => Console.Write("{0} ", x)) => 出力: 1 2 3
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        public void Foreach<T>(Action<T> action)
        {
            if (this == Nil) return;
            else
            {
                action((T)head);
                tail.Foreach(action);
            }
        }

        /// <summary>
        /// 順次処理（リストで返す）
        ///		a => (1, 2, 3)
        ///		a.Map((int x) => x * 2) => (2, 4, 6)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public ConsCell Map<T, R>(Func<T, R> func)
        {
            if (this == Nil) return Nil;
            else return new ConsCell(func((T)head), tail.Map(func));
        }

        /// <summary>
        /// 順次処理（リスト要素を結合して返す）
        ///		a => ((1, 2, 3), (4, 5))
        ///		a.FlatMap((Cons x) => x) => (1, 2, 3, 4, 5)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public ConsCell FlatMap<T>(Func<T, ConsCell> func)
        {
            if (this == Nil) return Nil;
            else return func((T)head).Append(tail.FlatMap(func));
        }

        /// <summary>
        /// すべて条件を満たすか
        ///		a => (1, 2, 3, 4)
        ///		a.Forall((int x) => x < 5) => true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <returns></returns>
        public bool Forall<T>(Predicate<T> func)
        {
            if (this == Nil) return true;
            else return func((T)head) ? tail.Forall(func) : false;
        }

        /// <summary>
        /// ひとつでも条件を満たすか
        ///		a => (1, 2, 3, 4)
        ///		a.Exists((int x) => x > 3) => true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <returns></returns>
        public bool Exists<T>(Predicate<T> fun)
        {
            if (this == Nil) return false;
            else return fun((T)head) ? true : tail.Exists(fun);
        }

        /// <summary>
        /// 条件でカウント
        ///		a => (1, 2, 3, 4)
        ///		a.Count((int x) => x % 2 == 0) => 2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <returns></returns>
        public int Count<T>(Predicate<T> fun)
        {
            if (this == Nil) return 0;
            else return (fun((T)head) ? 1 : 0) + tail.Count(fun);
        }

        /// <summary>
        /// 条件でフィルタリング
        ///		a => (1, 2, 3, 4)
        ///		a.Filter((int x) => x % 2 == 0) => (2, 4)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <returns></returns>
        public ConsCell Filter<T>(Predicate<T> fun)
        {
            if (this == Nil) return Nil;
            else return fun((T)head) ? new ConsCell(head, tail.Filter(fun)) : tail.Filter(fun);
        }

        /// <summary>
        /// 条件で要素位置を検索
        ///		a => (1, 2, 3, 4)
        ///		a.FindPos((int x) => x % 3 == 0) => 2, a.FindPos((int x) => x == 0) => -1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <returns></returns>
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
        private ConsCell SplitLeft(int pos)
        {
            return pos <= 0 ? Nil : new ConsCell(head, tail.SplitLeft(pos - 1));
        }

        private ConsCell SplitRight(int pos)
        {
            return pos <= 0 ? this : tail.SplitRight(pos - 1);
        }

        public ConsCell Split<T>(Predicate<T> fun)
        {
            var pos = FindPos(fun);
            return Of(SplitLeft(pos), SplitRight(pos + 1));
        }

        /// <summary>
        /// 繰り返し結合
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Repeat(string s, int n)
        {
            return string.Concat(Enumerable.Repeat(s, n));
        }

        /// <summary>
        /// 動作テスト用（別プロジェクトからCons.Test();で実行できる）
        /// </summary>
        public static void Test()
        {
            Console.WriteLine("Cons.Nil.Equals(Cons.Nil)\t= " + Nil.Equals(Nil));
            Console.WriteLine("new Cons().Equals(new Cons())\t= " + new ConsCell().Equals(new ConsCell()));
            Console.WriteLine("new Cons().Equals(Cons.Nil)\t= " + new ConsCell().Equals(Nil));
            Console.WriteLine("Cons.Nil.Equals(new Cons())\t= " + Nil.Equals(new ConsCell()));

            var a = Of(1, 2, 3);
            var b = Of(2, 2, "3");
            var c = Of(Of(1, 2, 3), Of(4, 5), Of(6));
            Console.WriteLine("Nil\t= " + Nil);
            Console.WriteLine("a\t= " + a);
            Console.WriteLine("b\t= " + b);
            Console.WriteLine("c\t= " + c);
            Console.WriteLine("a.head\t= " + a.head);
            Console.WriteLine("a.tail\t= " + a.tail);
            Console.WriteLine("Cons.Of(1, 2, 3)\t= " + Of(1, 2, 3));
            Console.WriteLine("Cons.Range(1, 5)\t= " + Range(1, 5));

            var e = new int[] { 1, 2, 3 };
            var d = new List<int>() { 1, 2, 3 };
            Console.WriteLine("Cons.FromArray(e)\t= " + FromArray(e));
            Console.WriteLine("Cons.FromList(d)\t= " + FromList(d));

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
            Console.WriteLine("c.FlatMap((Cons x) => x)\t= " + c.FlatMap((ConsCell x) => x));
            Console.WriteLine("a.Filter((int x) => x % 2 == 1))\t= " + a.Filter((int x) => x % 2 == 1));
            Console.WriteLine("a.Split((int x) => x == 2)\t= " + a.Split((int x) => x == 2));
        }

        #endregion メソッド

    }
}