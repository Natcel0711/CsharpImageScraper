using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Net;
using System;
using System.Drawing.Imaging;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        IWebDriver driver = new FirefoxDriver(@"Driver Path");
        driver.Navigate().GoToUrl("https://www.google.com/");
        Thread.Sleep(2000);
        IWebElement ele = driver.FindElement(By.ClassName("gLFyf"));
        ele.SendKeys("C#");
        Thread.Sleep(2000);
        IWebElement ele1 = driver.FindElement(By.ClassName("gNO89b"));
        ele1.Click();
        Thread.Sleep(3000);
        Console.WriteLine(driver.Title);
        var links = driver.FindElements(By.LinkText("Imágenes")).ToList();
        links[0].Click();
        Thread.Sleep(3000);
        IWebElement smallpic = driver.FindElement(By.ClassName("rg_i"));
        smallpic.Click();
        Thread.Sleep(3000);
        IWebElement bigpic = driver.FindElement(By.ClassName("n3VNCb"));
        Console.WriteLine(bigpic.GetAttribute("src"));
        Thread.Sleep(3000);
        SaveImage(bigpic.GetAttribute("src"), "*Path*", ImageFormat.Png);
        driver.Close();

        void SaveImage(string imageUrl, string filename, ImageFormat format)
        {
            WebClient client = new();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }
    }
}