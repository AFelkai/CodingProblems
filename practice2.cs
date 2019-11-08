public class Solution {
    public string MostCommonWord(string paragraph, string[] banned) {
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
        
        while(skippableChars.IndexOf(nextChar) != -1)
        {
            paragraph.Substring(1);
            nextChar = Char.ToLower(paragraph[0]);
        }
            
        while(skippableChars.IndexOf(nextChar) == -1)
        {
            word += nextChar;
            paragraph.Substring(1);
            nextChar = Char.ToLower(paragraph[0]);
        }
        
        return word;
    }

    public static void Main(string[] args)
    {
        Solution s = new Solution();

        solution.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", ["hit"]);
    }

    public class Solution {
    public void DuplicateZeros(int[] arr) {
        
        foreach(int i in arr) {
            if(i == 0) {
                foreach(int j = i in arr) {
                    if(j+1 <= arr.length()) {
                        arr[j+1] = arr[j];
                    }
                }
                arr[i] = 0;
            }
        }       
    }   
}
