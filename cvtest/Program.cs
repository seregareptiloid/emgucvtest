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
            Image<Gray, Single> defaultImage = new Image<Gray, Single>(@"C:\Users\shabir\source\repos\cvtest\cvtest\data\Default.png");
            Image<Gray, Single> imageToShow = changedImage.Copy();
            using (Image<Gray, Single> result = changedImage.MatchTemplate(templateImage, matchingType))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                if (maxValues[0] > 0.999)
                {
                    Console.WriteLine("Changed image True");
                }
                else
                {
                    Console.WriteLine("Changed image False");
                }
            }

            using (Image<Gray, Single> result = defaultImage.MatchTemplate(templateImage, matchingType))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                if (maxValues[0] > 0.999)
                {
                    Console.WriteLine("Unchanged image True");
                }
                else
                {
                    Console.WriteLine("Unchanged image False");
                }
            }
        }
    }
}