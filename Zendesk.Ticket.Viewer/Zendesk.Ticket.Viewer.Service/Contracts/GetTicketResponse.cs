using System;
using System.Collections.Generic;

namespace Zendesk.Ticket.Viewer.Service
{
    public class GetTicketResponse
    {
        public string URL { get; set; }
        public int? Id { get; set; }
        public int? ExternalId { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string RawSubject { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Recipient { get; set; }
        public string RequesterId { get; set; }
        public string SubmitterId { get; set; }
        public string AssigneeId { get; set; }
        public string OrganizationId { get; set; }
        public string GroupId { get; set; }
        public List<string> CollaboratorIds { get; } = new List<string>();
        public List<string> FollowerIds { get; } = new List<string>();
        public List<string> EmailCCIds { get; } = new List<string>();
        public string ForumTopicId { get; set; }
        public string ProblemId { get; set; }
        public bool HasIncidents { get; set; }
        public bool IsPublic { get; set; }
        public string DueAt { get; set; }
        public List<string> Tags { get; } = new List<string>();
        public List<string> CustomFields { get; } = new List<string>();
        public List<string> SharingAgreementIds { get; } = new List<string>();
        public List<string> Fields { get; } = new List<string>();
        public List<string> FollowupIds { get; } = new List<string>();
        public string SatisfactionRating { get; set; }
        public string TicketFormId { get; set; }
        public string BrandId { get; set; }
        public bool AllowChannelBack { get; set; }
        public bool AllowAttachments { get; set; }
    }
}
