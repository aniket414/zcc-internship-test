using System;
using System.Collections.Generic;

namespace Zendesk.Ticket.Viewer.Data
{
    public class Ticket
    {
        public string url { get; set; }
        public int? id { get; set; }
        public int? external_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string type { get; set; }
        public string subject { get; set; }
        public string raw_subject { get; set; }
        public string description { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public string recipient { get; set; }
        public string requester_id { get; set; }
        public string submitter_id { get; set; }
        public string assignee_id { get; set; }
        public string organization_id { get; set; }
        public string group_id { get; set; }
        public List<string> collaborator_ids { get; } = new List<string>();
        public List<string> follower_ids { get; } = new List<string>();
        public List<string> email_cc_ids { get; } = new List<string>();
        public string forum_topic_id { get; set; }
        public string problem_id { get; set; }
        public bool has_incidents { get; set; }
        public bool is_public { get; set; }
        public string due_at { get; set; }
        public List<string> tags { get; } = new List<string>();
        public List<string> custom_fields { get; } = new List<string>();
        public List<string> sharing_agreement_ids { get; } = new List<string>();
        public List<string> fields { get; } = new List<string>();
        public List<string> followup_ids { get; } = new List<string>();
        public string satisfaction_rating { get; set; }
        public string ticket_form_id { get; set; }
        public string brand_id { get; set; }
        public bool allow_channelback { get; set; }
        public bool allow_attachments { get; set; }
    }

    public class TicketResponse
    {
        public Ticket ticket { get; set; }
    }
}
