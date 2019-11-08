using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        Solution s = new Solution();

        //s.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new string[] {"hit"});

        //s.DuplicateZeros(new int[] { 1, 0, 2, 3, 0, 4, 5, 0 });

        //s.MinDominoRotations(new int[] { 2, 1, 2, 4, 2, 2 }, new int[] { 5, 2, 6, 2, 3, 2 });

        //s.NumJewelsInStones2("aA", "aAAbbbb");

        //s.TrimBST(new TreeNode(5).left = new TreeNode(3).right = new TreeNode(10), 4, 8);

        //s.SortedSquares(new int[] { -4, -1, 0, 3, 10 });

        s.CustomSortString("cba", "abcd");

    }

    public string MostCommonWord(string paragraph, string[] banned)
    {
        //List paragraphInArray = new List<string>();
        string skippableChars = " !?',;.";

        string word = NextWord(paragraph, skippableChars);

        Console.WriteLine(word);

        return "";
    }

    public string NextWord(string paragraph, string skippableChars)
    {
        string word = "";
        char nextChar = Char.ToLower(paragraph[0]);

        while (skippableChars.IndexOf(nextChar) != -1)
        {
            paragraph.Substring(1);
            nextChar = Char.ToLower(paragraph[0]);
        }

        while (skippableChars.IndexOf(nextChar) == -1)
        {
            word += nextChar;
            paragraph.Substring(1);
            nextChar = Char.ToLower(paragraph[0]);
        }

        return word;
    }

    public void DuplicateZeros(int[] arr)
    {

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 0)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    arr[j] = arr[j - 1];
                }
                if (i + 1 < arr.Length)
                    arr[i + 1] = 0;
                i++;
            }
        }
    }

    public int MinDominoRotations(int[] A, int[] B)
    {

        int[] buckets = new int[6];
        int magicNumber = 0;
        int magicNumberCount = 0;
        int aCount = 0;
        int bCount = 0;
        int magicRow;

        for (int i = 0; i < A.Length; i++) //count all occurences of each number in the dominoes
        {
            if (A[i] == B[i]) buckets[A[i] - 1]++;
            else
            {
                buckets[A[i] - 1]++;
                buckets[B[i] - 1]++;
            }
        }

        magicNumberCount = buckets.Max();
        magicNumber = buckets.ToList().IndexOf(magicNumberCount) + 1;

        if (magicNumberCount == A.Length)
        {
            for (int i = 0; i < A.Length; i++) //See if we need to flip on A or B
            {
                if (A[i] == magicNumber) aCount++;
                if (B[i] == magicNumber) bCount++;
            }
            magicRow = (aCount >= bCount) ? 0 : 1;

            return A.Length - Math.Max(aCount, bCount);
        }
        return -1;
    }

    public int NumJewelsInStones(string J, string S)
    {

        int[] buckets = new int[52];
        int answer = 0;

        string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for (int s = 0; s < S.Length; s++)
        {
            buckets[alphabet.IndexOf(S[s])]++;
        }

        foreach (char c in J)
        {
            answer += buckets[alphabet.IndexOf(c)];
        }

        return answer;
    }

    public int NumJewelsInStones2(string J, string S)
    {

        int answer = 0;
        int index;

        char[] s = S.ToCharArray();

        foreach (char c in J)
        {
            index = 0;
            while (index != -1)
            {
                index = Array.IndexOf(s, c);
                if (index != -1)
                {
                    answer++;
                    s[index] = '0';
                }
            }
        }

        return answer;
    }

    public int[] SortedSquares(int[] A)
    {

        int[] B = new int[A.Length];
        for (int a = 0; a < A.Length; a++)
        {
            if (A[a] < 0)
                A[a] = A[a] - 2 * A[a];
        }
        for (int i = 0; i < B.Length; i++)
        {
            B[i] = (int)Math.Pow(A[i], 2);
        }

        QuickSort(B, 0, A.Length - 1);

        return B;
    }

    public void QuickSort(int[] A, int left, int right)
    {

        int i = left;
        int j = right;
        int temp;
        int pivot = A[(left + right) / 2];

        while (i <= j)
        {

            while (A[i] < pivot)
                i++;
            while (A[j] > pivot)
                j--;

            if (i <= j)
            { //Swap
                temp = A[i];
                A[i] = A[j];
                A[j] = temp;
                i++;
                j--;
            }
        }

        if (left < j)
            QuickSort(A, left, j);
        if (i < right)
            QuickSort(A, i, right);
    }

    public string CustomSortString(string S, string T)
    {
        int val;
        char temp;

        char[] t = T.ToCharArray();

        for (int i = 0; i < S.Length; i++)
        {
            val = Array.IndexOf(t, S[i]);

            if (val >= 0)
            {
                temp = t[i];
                t[i] = t[val];
                t[val] = temp;
            }
        }
        return new string(t);
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public TreeNode TrimBST(TreeNode root, int L, int R)
    {

        if (root != null)
        {
            if (root.val > R || root.val < L)
            { //if outside bounds
                if (root.right != null)
                    root = root.right;
                else root = null;

            }
            return TrimBST(root.left, L, R);
            return TrimBST(root.right, L, R);
        }

        return root;
    }

}