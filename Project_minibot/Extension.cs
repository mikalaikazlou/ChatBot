namespace Project_minibot
{
    static class MyExtension
    {
        public static string CutString(this string str)
        {
            str = str.Substring(0, str.Length);
            return str = "\n...................";
        }
    }
}