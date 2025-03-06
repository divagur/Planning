using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{

    public struct VolumeCalcResult
    {
        public decimal OrderPalleteAmount;
        public decimal OrderVolume;
        public decimal OrderWeight;
        public decimal TotalVolume;
        public decimal TotalWeight;
        public decimal PalleteAmount;
        public decimal HeightTotal;
        public string ErrorMessage;
        public bool IsError;
    }
    public class VolumeCalc
    {

        public decimal PalletWeight { get; set; }
        public decimal PalletWidth { get; set; }
        public decimal PalletHeight { get; set; }
        public decimal PalletVolume { get; set; }
        public decimal PalleteDimensions { get; set; }

        public List<VolumeCalcProduct> volumeCalcProducts;

        public VolumeCalcResult volumeCalcResult;

        public bool Calculate()
        {


            volumeCalcResult.OrderWeight = 0.0m;
            volumeCalcResult.OrderVolume = 0.0m;
            volumeCalcResult.OrderPalleteAmount = 0.0m;

            volumeCalcResult.TotalWeight = 0.0m;
            volumeCalcResult.TotalVolume = 0.0m;
            volumeCalcResult.PalleteAmount = 0.0m;
            volumeCalcResult.HeightTotal = 0.0m;

            if (volumeCalcProducts == null || volumeCalcProducts.Count == 0)
            {
               
                volumeCalcResult.IsError = true;
                volumeCalcResult.ErrorMessage = "Не задан список продукции";
                return false;
            }
                
            volumeCalcResult.IsError = false;
            volumeCalcResult.ErrorMessage = "";
            try
            {
                volumeCalcResult.OrderWeight = volumeCalcProducts.Sum(i => i.TotalWeight);
                volumeCalcResult.OrderVolume = volumeCalcProducts.Sum(i => i.TotalVolume);
                volumeCalcResult.OrderPalleteAmount = volumeCalcResult.OrderVolume / PalleteDimensions;

                volumeCalcResult.TotalWeight = Math.Round(volumeCalcResult.OrderWeight + volumeCalcResult.OrderPalleteAmount * PalletWeight,1);
                volumeCalcResult.TotalVolume = Math.Round(volumeCalcResult.OrderVolume + volumeCalcResult.OrderPalleteAmount * PalletVolume,1);
                volumeCalcResult.PalleteAmount = Math.Ceiling(volumeCalcResult.TotalVolume / PalleteDimensions) * 1.1m;
                volumeCalcResult.HeightTotal = volumeCalcProducts.Max(i => i.Height) + PalletHeight + 0.1m;
            }
            catch(Exception ex)
            {
                volumeCalcResult.IsError = true;
                volumeCalcResult.ErrorMessage = ex.Message;
            }

            

            return true;
        }
    }
}
