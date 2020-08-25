using System.Globalization;

namespace SJ.One_Core.Models.LocalityViewModels
{
    public class NewLocalityViewModel
    {
        private string localityName;
        public int RegionId { get; set; }
        public string Name
        {
            get => localityName;
            set
            {
                var textInfo = new CultureInfo("ru-RU").TextInfo;
                localityName = textInfo.ToTitleCase(value);
            }
        }
    }
}
