using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public interface IMailer {
        decimal? Delivered { get; set; }
        decimal? UniqueOpens { get; set; }
        decimal? UniqueClicks { get; set; }
        decimal? SpamReports { get; set; }
        decimal? Bounces { get; set; }
        decimal? Unsubscribed { get; set; }
    }
}
