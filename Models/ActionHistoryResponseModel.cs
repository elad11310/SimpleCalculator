using System.ComponentModel.DataAnnotations;

namespace SimpleCalculator.Models
{
    public class ActionHistoryResponseModel
    {


        public int? MonthActions { get; set; }

        public List<ActionHistory> LastThreeActions { get; set; }

        public string MostPopular { get; set; }

    }
}
