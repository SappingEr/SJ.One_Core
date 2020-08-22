using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SJ.One_Core.Models
{
    public class SportEvent : BaseEntity
    {
        public bool Show { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndRegDate { get; set; }
        public int LocalityId { get; set; }
        public Locality Locality { get; set; }
        public List<Document> EventDocuments { get; set; }
        public List<EventImage> EventPhotos { get; set; }
        public List<Event_Tag> Tags { get; set; }
        public List<Race> RacesEvent { get; set; }
    }
}
