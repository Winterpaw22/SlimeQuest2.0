using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class windowCreator
    {
        public static void CreateWindow(Windows window)
        {
            Console.SetCursorPosition(window.XStart, window.YStart);
            for (int i = window.XStart; i <= window.XEnd; i++)
            {
                Console.Write("=");//Forward pointing double arrow
            }

            Console.SetCursorPosition(window.XStart, window.YEnd);
            for (int i = window.XStart; i <= window.XEnd; i++)
            {
                Console.Write("=");//Backward pointing double arrow
            }

            Console.SetCursorPosition(window.XStart, window.YStart);
            for (int i = window.YStart; i <= window.YEnd; i++)
            {
                Console.SetCursorPosition(window.XStart, i);
                Console.Write("|");//Fan UP 0488 circle 2021 double dagger (like fence)
                
            }

            Console.SetCursorPosition(window.XEnd, window.YStart);
            for (int i = window.YStart; i <= window.YEnd; i++)
            {
                Console.SetCursorPosition(window.XEnd, i);
                Console.Write("|");//Fan DOWN 
                
            }
        }
        /// <summary>
        /// wraps text using a list of strings
        /// Original code from Mike Ward's website
        /// http://mike-ward.net/2009/07/19/word-wrap-in-a-console-app-c/
        /// Adapted to format for text boxes
        /// </summary>
        /// <param name="text">text to wrap</param>
        /// <param name="textAreaWidth">length of each line</param>
        /// <param name="leftMargin">left margin</param>
        /// <returns>list of lines as strings</returns>
        //public static List<string> MessageBoxWordWrap(string text, int textAreaWidth)
        //{
        //    var lines = new List<string>();

        //    string[] paragraphs = Regex.Split(text, "\n");

        //    foreach (string paragraph in paragraphs)
        //    {
        //        int start = 0, end;

        //        //
        //        // removes formatting characters
        //        //
        //        text = Regex.Replace(text, @"\s", " ").Trim();

        //        while ((end = start + textAreaWidth) < paragraph.Length)
        //        {
        //            while (paragraph[end] != ' ' && end > start)
        //                end -= 1;

        //            if (end == start)
        //                end = start + textAreaWidth;

        //            string textLine = paragraph.Substring(start, end - start);

        //            lines.Add(textLine);
        //            start = end + 1;
        //        }

        //        if (start < paragraph.Length)
        //            lines.Add(paragraph.Substring(start));
        //    }

        //    return lines;
        //}

       
    }
}
