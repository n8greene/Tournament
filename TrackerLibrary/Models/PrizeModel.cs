using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// represens what the prize is for the given place
/// </summary>

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        /// <summary>
        /// the unique identifer for the prize
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the numeric identifier for the place (2 for second place etc)
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// The frendly name for the place (second place, first runner up etc)
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// the number that reporesents the percentage of the overall take or zero if not used. 
        /// The perentage is a fraction of 1 (so 0.5 for 50 percent)
        /// </summary>
        public double PrizePercentage { get; set; }
        /// <summary>
        /// The fixed amount this place earns or zero if it is not used. 
        /// </summary>
        public decimal PrizeAmount { get; set; }

        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName; //that one's easy cause it already text

            //the other's need to be converted from string to thier respective data types
            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;

        }
    }
}
