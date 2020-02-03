using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector: IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";


        //TODO - Wire up the CreatePrize for the textfiles.
        public PrizeModel CreatePrize(PrizeModel model) //with storing data in text files we have to do more work. No fancy database to rely on
        {
            // Load the text file
            //convert text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels(); //in one line here we have list of prize model from text file

            //Find the max ID
            int currentID = 1; // 1 is default in case this is the first time
            if (prizes.Count>0)
            {
                currentID = prizes.OrderByDescending(x => x.Id).First().Id + 1; //finds id of highest in list and adds 1 to it. 
            }

            model.Id = currentID;

            // add the new record with the new id (max plus 1)
            prizes.Add(model);

            //Convert the prizes to a list<string>
            //save the list<string> to text file
            prizes.SaveToPrizeFile(PrizesFile); //this will overwrite the file already there

            return model; //so we have this particular record in case we need to refer to it with an id (set above)

        }

        
    }
}
