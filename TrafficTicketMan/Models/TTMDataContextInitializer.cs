using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class TTMDataContextInitializer : DropCreateDatabaseIfModelChanges<TTMDataContext>
    {
    }
}