using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
namespace cvtest
{
    class Program
    {

        static void Main()
        {
            Emgu.CV.CvEnum.TemplateMatchingType matchingType = Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed;
            Image<Gray, Single> templateImage = new Image<Gray, Single>(@"C:\Users\shabir\source\repos\cvtest\cvtest\data\Template.png");
            Image<Gray, Single> changedImage = new Image<Gray, Single>(@"C:\Users\shabir\source\repos\cvtest\cvtest\data\Changed.png");
            Image<Gray, Single> imageToShow = changedImage.Copy();
            using (Image<Gray, Single> result = changedImage.MatchTemplate(templateImage, matchingType))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                if (maxValues[0] > 0.999)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Rectangle match = new Rectangle(maxLocations[0], templateImage.Size);
                    imageToShow.Draw(match, new Gray(), 3);
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }
    }
}