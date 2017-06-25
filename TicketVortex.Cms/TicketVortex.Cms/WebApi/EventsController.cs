using System.Collections.Generic;
using TicketVortex.Cms.Model.Models;
using Umbraco.Web.WebApi;

namespace TicketVortex.Cms.WebApi
{
    public class EventsController : UmbracoApiController
    {
        public IEnumerable<Event> GetAllEvents()
        {
            return new List< Event>();
        }

        public Event GetEvent(int umbracoNodeId)
        {
            return new Event();
        }

        public IEnumerable<EventDate> GetEventDates(int eventUmbracoNodeId)
        {
            return new List<EventDate>();
        }

        public EventDate GetEventDate()
        {
            return new EventDate();
        }
    }
}