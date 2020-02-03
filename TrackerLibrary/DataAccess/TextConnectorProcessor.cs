using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

// Load the text file
//convert text to List<PrizeModel>
// Find the max ID
// add the new record with the new id (max plus 1)
//Convert the prizes to a list<string>
//save the list<string> to text file


namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName) //we are feeding "PrizeModels.csv" into this method
        {

            return $"{ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        // Load the text file

        public static List<string> LoadFile(this string file) //List<string> represents all the lines in the text file
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        //convert text to List<PrizeModel>
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(','); //split the line at the comma and add to an array called cols

                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]); //this is going to crash if it does not contain a number and that's ok
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }
            return output;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (PrizeModel p in models) //loop through every line in list of models and write to csv
            {
                lines.Add($"{ p.Id },{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}"); //order is important, this is a row on the CSV
            }

            File.WriteAllLines(fileName.FullFilePath(),lines);
        }
    }
    
}
