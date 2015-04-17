﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class ScreenShot : Helper
    {
        internal void TakeScreenshot(string saveLocation)
        {
            var ssdriver = TestController.CurrentDriver as ITakesScreenshot;
            if (ssdriver == null) return;
            var screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation, ImageFormat.Png);
        }

        public void TakeFullScreenshot(string saveLocation)
        {
            // Get the Total Size of the Document
            var totalWidth = (int)SeleniumHelper.EvalScript<long>("return document.width");
            var totalHeight = (int)SeleniumHelper.EvalScript<long>("return document.height");

            // Get the Size of the Viewport
            var viewportWidth = (int)SeleniumHelper.EvalScript<long>("return document.body.clientWidth");
            var viewportHeight = (int)SeleniumHelper.EvalScript<long>("return document.body.clientHeight");

            // Split the Screen in multiple Rectangles
            var rectangles = new List<Rectangle>();
            // Loop until the Total Height is reached
            for (var i = 0; i < totalHeight; i += viewportHeight)
            {
                var newHeight = viewportHeight;
                // Fix if the Height of the Element is too big
                if (i + viewportHeight > totalHeight)
                {
                    newHeight = totalHeight - i;
                }
                // Loop until the Total Width is reached
                for (var ii = 0; ii < totalWidth; ii += viewportWidth)
                {
                    var newWidth = viewportWidth;
                    // Fix if the Width of the Element is too big
                    if (ii + viewportWidth > totalWidth)
                    {
                        newWidth = totalWidth - ii;
                    }

                    // Create and add the Rectangle
                    var currRect = new Rectangle(ii, i, newWidth, newHeight);
                    rectangles.Add(currRect);
                }
            }

            // Build the Image
            var stitchedImage = new Bitmap(totalWidth, totalHeight);
            // Get all Screenshots and stitch them together
            Rectangle previous = Rectangle.Empty;
            foreach (var rectangle in rectangles)
            {
                // Calculate the Scrolling (if needed)
                if (previous != Rectangle.Empty)
                {
                    var xDiff = rectangle.Right - previous.Right;
                    var yDiff = rectangle.Bottom - previous.Bottom;
                    // Scroll
                    SeleniumHelper.RunScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                    System.Threading.Thread.Sleep(200);
                }

                // Take Screenshot
                var screenshot = ((ITakesScreenshot)TestController.CurrentDriver).GetScreenshot();

                // Build an Image out of the Screenshot
                Image screenshotImage;
                using (var memStream = new MemoryStream(screenshot.AsByteArray))
                {
                    screenshotImage = Image.FromStream(memStream);
                }

                // Calculate the Source Rectangle
                var sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);

                // Copy the Image
                using (var graphics = Graphics.FromImage(stitchedImage))
                {
                    graphics.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                }

                // Set the Previous Rectangle
                previous = rectangle;
            }
            stitchedImage.Save(saveLocation, ImageFormat.Png);
        }

    }
}