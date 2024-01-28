using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tesseract;
using static System.Net.Mime.MediaTypeNames;

namespace LethalSheet
{
    
    public class Screenshot
    {
        public static Bitmap GetScreenshot(Rectangle bounds)
        {
            // create bitmap
            var bmp = new Bitmap(bounds.Width, bounds.Height);

            // copy screen
            using var g = Graphics.FromImage(bmp);
            g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);

            // no memory leak :)
            g.Dispose();

            // return
            return bmp;
        }

        public static String RemoveLetters(String s)
        {
            return Regex.Replace(s.Replace("?", "7").Replace("‘3", "9"), "[^.0-9]", "");
        }

        public static String GetCollectedScrap(out Bitmap bmp)
        {
            // get screenshot
            bmp = GetScreenshot(new Rectangle(822, 790, 111, 50));
            var result = Tesseract(bmp);

            return RemoveLetters(result);
        }

        public static String GetNewQuota(out Bitmap bmp)
        {
            // get screenshot
            bmp = GetScreenshot(new Rectangle(730, 578, 460, 150));

            var result = Tesseract(bmp);

            return RemoveLetters(result);
        }

        public static String GetSoldAmount(out Bitmap bmp)
        {
            // get screenshot
            bmp = GetScreenshot(new Rectangle(1525, 718, 143, 50));
            var result = Tesseract(bmp);

            return RemoveLetters(result);
        }

        private static String Tesseract(Bitmap bmp)
        {
            String result = string.Empty;

            // idfk don't judge me with this code, I just stole it from their example code
            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.TesseractOnly))
                {
                    using (var page = engine.Process(bmp))
                    {
                        result = page.GetText();
                        Debug.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

                        Debug.WriteLine("Text (GetText): \r\n{0}", result);
                        Debug.WriteLine("Text (iterator):");
                        using (var iter = page.GetIterator())
                        {
                            iter.Begin();

                            do
                            {
                                do
                                {
                                    do
                                    {
                                        do
                                        {
                                            if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                            {
                                                Debug.WriteLine("<BLOCK>");
                                            }

                                            Debug.Write(iter.GetText(PageIteratorLevel.Word));
                                            Debug.Write(" ");

                                            if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                            {
                                                //Debug.WriteLine();
                                            }
                                        } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                        if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                        {
                                            //Debug.WriteLine();
                                        }
                                    } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                            } while (iter.Next(PageIteratorLevel.Block));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Debug.WriteLine("Unexpected Error: " + e.Message);
                Debug.WriteLine("Details: ");
                Debug.WriteLine(e.ToString());
            }

            return result;
        }
    }
}
